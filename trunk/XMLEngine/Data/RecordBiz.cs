using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using alpha.personal.XMLEngine.ConfigModule;
using alpha.personal.XMLEngine.Enumeration;

namespace alpha.personal.XMLEngine.Data
{
    public class RecordBiz
    {
        /// <summary>
        /// 根据日期间隔取得记录
        /// </summary>
        /// <param name="startDate">起始日期(包含起始日期)</param>
        /// <param name="endDate">终止日期(包含终止日期)</param>
        /// <param name="recordTypeId">要查询的记录类型，不限制请传入0</param>
        /// <param name="queryType">查询类型</param>
        /// <returns>取得的记录集</returns>
        public IList<Record> GetByDate(DateTime startDate, DateTime endDate, int recordTypeId, QueryType queryType)
        {
            if (startDate.Date > endDate.Date && startDate.Year > DateTime.Now.Year && queryType == null)
            {
                return null;
            }

            IList<string> dataFileList = new List<string>();
            IList<Record> recordList = new List<Record>();

            if (queryType == QueryType.年单位)
            {
                int iCount = (endDate.Year - startDate.Year + 1) * 12;
                DateTime QuerySDate = new DateTime(startDate.Year, 1, 1);
                for (int i = 0; i <= iCount; i++)
                {
                    dataFileList.Add(System.Environment.CurrentDirectory + "\\Data\\" + QuerySDate.AddMonths(i).ToString(@"yyyy/MM") + ".xml");
                }
            }
            else if (queryType == QueryType.月单位 || queryType == QueryType.日单位)
            {
                int iCount = startDate.Year == endDate.Year ? endDate.Month - startDate.Month : (12 - startDate.Month + 1) + (endDate.Year - startDate.Year - 1) * 12 + endDate.Month;
                for (int i = 0; i <= iCount; i++)
                {
                    dataFileList.Add(System.Environment.CurrentDirectory + "\\Data\\" + startDate.AddMonths(i).ToString(@"yyyy/MM") + ".xml");
                }
            }

            XmlOperate op = new XmlOperate(dataFileList, XmlFileOpType.不创建, startDate);
            IList<XmlDocument> doclist = op.GetList();

            if (queryType == QueryType.年单位 || queryType == QueryType.月单位)
            {
                XmlNodeList tempList = null;
                if (recordTypeId == 0)
                {
                    foreach (XmlDocument item in doclist)
                    {
                        tempList = item.DocumentElement.ChildNodes;
                        foreach (XmlElement node in tempList)
                        {
                            recordList.Add(Get(node));
                        }
                    }
                }
                else
                {
                    foreach (XmlDocument item in doclist)
                    {
                        tempList = item.DocumentElement.ChildNodes;
                        Record record = null;
                        foreach (XmlElement node in tempList)
                        {
                            record = Get(node);
                            if (CheckTpye(recordTypeId, record.Type))
                            {
                                recordList.Add(record);
                            }
                        }
                    }
                }
            }
            else //queryType == QueryType.日单位
            {
                XmlNodeList tempList = null;
                if (recordTypeId == 0)
                {
                    foreach (XmlDocument item in doclist)
                    {
                        tempList = item.DocumentElement.ChildNodes;
                        Record record = null;
                        foreach (XmlElement node in tempList)
                        {
                            record = Get(node);
                            if (record.Date.Date >= startDate.Date && record.Date.Date <= endDate.Date)
                            {
                                recordList.Add(Get(node));
                            }
                        }
                    }
                }
                else
                {
                    foreach (XmlDocument item in doclist)
                    {
                        tempList = item.DocumentElement.ChildNodes;
                        Record record = null;
                        foreach (XmlElement node in tempList)
                        {
                            record = Get(node);
                            if (record.Date.Date >= startDate.Date && record.Date.Date <= endDate.Date && CheckTpye(recordTypeId, record.Type))
                            {
                                recordList.Add(Get(node));
                            }
                        }
                    }
                }
            }

            return recordList;
        }

        /// <summary>
        /// 获取指定ID的记录对象
        /// </summary>
        /// <param name="id">记录ID</param>
        /// <param name="date">账目的日期，要求精确到月</param>
        /// <returns>返回的记录对象</returns>
        public Record Get(int id, DateTime date)
        {
            XmlOperate op = new XmlOperate(System.Environment.CurrentDirectory + "\\Data\\" + date.ToString(@"yyyy/MM") + ".xml", XmlFileOpType.不创建, date);
            XmlDocument doc = op.Get();
            XmlNode xn = doc.DocumentElement.SelectSingleNode("/datas/data[@id=" + id.ToString() + "]");
            if (xn != null)
            {
                return Get((XmlElement)xn);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 统计结余
        /// </summary>
        /// <returns>当前结余</returns>
        public double StatisticsBalance()
        {
            double balance = 0;

            IList<Record> all = GetByDate(Config.StartDate, DateTime.Now, 0, QueryType.日单位);
            foreach (Record item in all)
            {
                balance += item.Income;
                balance -= item.Spend;
            }
            Config.CurrentBalance = balance;

            return balance;
        }

        /// <summary>
        /// 统计某时段、某类型的结余
        /// </summary>
        /// <param name="startDate">起始时间(包含起始时间)</param>
        /// <param name="endDate">结束时间(包含结束时间)</param>
        /// <param name="recordTypeId">类型ID</param>
        /// <returns>取得的结余</returns>
        public double StatisticsBalance(DateTime startDate, DateTime endDate, int recordTypeId)
        {
            double balance = 0;

            IList<Record> all = GetByDate(startDate, endDate, recordTypeId, QueryType.日单位);
            foreach (Record item in all)
            {
                balance += item.Income;
                balance -= item.Spend;
            }

            return balance;
        }

        /// <summary>
        /// 检查记录是否属于指定记录类型
        /// </summary>
        /// <param name="recordTypeId">记录类型ID</param>
        /// <param name="recordType">要检查的记录所对应的记录对象</param>
        /// <returns>返回值：true 属于; false 不属于</returns>
        private bool CheckTpye(int recordTypeId, RecordType recordType)
        {
            return recordType == null ? false : recordTypeId == recordType.Id ? true : recordType.Parent == null ? false : CheckTpye(recordTypeId, recordType.Parent);
        }

        /// <summary>
        /// 获取指定data节点对应的记录对象
        /// </summary>
        /// <param name="datadoc">data节点</param>
        /// <returns>对应的记录对象</returns>
        private Record Get(XmlElement datadoc)
        {
            Record record = new Record();
            
            record.Id = Convert.ToInt32(datadoc.GetAttribute("id"));
            XmlNode xn=datadoc.FirstChild;
            record.Date = Convert.ToDateTime(xn.FirstChild.Value);
            xn = xn.NextSibling;
            record.Spend = Convert.ToDouble(xn.FirstChild.Value);
            xn = xn.NextSibling;
            record.Income = Convert.ToDouble(xn.FirstChild.Value);
            xn = xn.NextSibling;
            record.Type = new RecordTypeBiz().Get(Convert.ToInt32(xn.FirstChild.Value));
            xn = xn.NextSibling;
            record.Description = xn.FirstChild.Value;

            return record;
        }

        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="record">要添加的账目记录</param>
        public void Create(Record record)
        {
            DirectoryInfo rd = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Data\\" + record.Date.ToString("yyyy"));
            if (!rd.Exists)
            {
                rd.Create();
            }
            XmlOperate op = new XmlOperate(System.Environment.CurrentDirectory + "\\Data\\" + record.Date.ToString(@"yyyy/MM") + ".xml", XmlFileOpType.不存在则创建, record.Date);
            XmlDocument doc = op.Get();
            record.Id = ++Config.RecordCount;
            Config.RecordCount = record.Id;
            if (record.Date < Config.StartDate)
            {
                Config.StartDate = record.Date;
            }
            
            {
                XmlElement data = doc.CreateElement("data");
                data.SetAttribute("id", record.Id.ToString());

                XmlElement date = doc.CreateElement("date");
                XmlText datetx = doc.CreateTextNode(record.Date.ToString("yyyy-MM-dd"));
                date.AppendChild(datetx);

                XmlElement spend = doc.CreateElement("spend");
                XmlText spendtx = doc.CreateTextNode(record.Spend.ToString("n"));
                spend.AppendChild(spendtx);

                XmlElement income = doc.CreateElement("income");
                XmlText incometx = doc.CreateTextNode(record.Income.ToString("n"));
                income.AppendChild(incometx);

                XmlElement type = doc.CreateElement("type");
                XmlText typetx = doc.CreateTextNode(record.Type == null ? "0" : record.Type.Id.ToString());
                type.AppendChild(typetx);

                XmlElement description = doc.CreateElement("description");
                XmlCDataSection descriptiontx = doc.CreateCDataSection(record.Description);
                description.AppendChild(descriptiontx);

                data.AppendChild(date);
                data.AppendChild(spend);
                data.AppendChild(income);
                data.AppendChild(type);
                data.AppendChild(description);

                XmlNode xn = doc.DocumentElement.SelectSingleNode("/datas/data/date[substring(text(),9,2)>'" + record.Date.ToString("dd") + "']");
                if (xn != null)
                {
                    doc.DocumentElement.InsertBefore(data, xn.ParentNode);
                }
                else
                {
                    doc.DocumentElement.AppendChild(data);
                }
            }

            op.Save();

            Config.CurrentBalance = Config.CurrentBalance - record.Spend + record.Income;
        }

        /// <summary>
        /// 更新账目记录
        /// </summary>
        /// <param name="record">要更新的账目记录</param>
        /// <param name="oldDate">更新前的账目记录副本</param>
        public void Update(Record newRecord, Record oldRecord)
        {
            if (newRecord.Date < Config.StartDate)
            {
                Config.StartDate = newRecord.Date;
            }
            if (newRecord.Date.Year == oldRecord.Date.Year && newRecord.Date.Month == oldRecord.Date.Month)
            {
                XmlOperate op = new XmlOperate(System.Environment.CurrentDirectory + "\\Data\\" + newRecord.Date.ToString(@"yyyy/MM") + ".xml", XmlFileOpType.不创建, newRecord.Date);
                XmlDocument doc = op.Get();
                XmlElement data = (XmlElement)doc.DocumentElement.SelectSingleNode("/datas/data[@id=" + newRecord.Id.ToString() + "]");
                data.RemoveAll();
                data.SetAttribute("id", newRecord.Id.ToString());

                XmlElement date = doc.CreateElement("date");
                XmlText datetx = doc.CreateTextNode(newRecord.Date.ToString("yyyy-MM-dd"));
                date.AppendChild(datetx);

                XmlElement spend = doc.CreateElement("spend");
                XmlText spendtx = doc.CreateTextNode(newRecord.Spend.ToString("n"));
                spend.AppendChild(spendtx);

                XmlElement income = doc.CreateElement("income");
                XmlText incometx = doc.CreateTextNode(newRecord.Income.ToString("n"));
                income.AppendChild(incometx);

                XmlElement type = doc.CreateElement("type");
                XmlText typetx = doc.CreateTextNode(newRecord.Type.Id.ToString());
                type.AppendChild(typetx);

                XmlElement description = doc.CreateElement("description");
                XmlCDataSection descriptiontx = doc.CreateCDataSection(newRecord.Description);
                description.AppendChild(descriptiontx);

                data.AppendChild(date);
                data.AppendChild(spend);
                data.AppendChild(income);
                data.AppendChild(type);
                data.AppendChild(description);

                op.Save();

                Config.CurrentBalance = Config.CurrentBalance - oldRecord.Income + oldRecord.Spend + newRecord.Income - newRecord.Spend;
            }
            else
            {
                Delete(oldRecord);
                Create(newRecord);
            }
        }

        /// <summary>
        /// 删除账目记录
        /// </summary>
        /// <param name="record">要删除的账目记录</param>
        public void Delete(Record record)
        {
            XmlOperate op = new XmlOperate(System.Environment.CurrentDirectory + "\\Data\\" + record.Date.ToString(@"yyyy/MM") + ".xml", XmlFileOpType.不创建, record.Date);
            XmlDocument doc = op.Get();
            XmlNode xn = doc.DocumentElement.SelectSingleNode("/datas/data[@id=" + record.Id.ToString() + "]");
            if (xn != null)
            {
                doc.DocumentElement.RemoveChild(xn);
                op.Save();
            }

            Config.CurrentBalance = Config.CurrentBalance + record.Spend - record.Income;
        }
    }
}
