using System.Collections.Generic;
using System.IO;
using System.Xml;
using alpha.personal.XMLEngine.ConfigModule;
using alpha.personal.XMLEngine.CustomizeException;
using System;

namespace alpha.personal.XMLEngine.Data
{
    /// <summary>
    /// 记录类型的业务方法
    /// </summary>
    public class RecordTypeBiz
    {
        private XmlDocument xmldoc = new XmlDocument();
        /// <summary>
        /// 初始化记录类型
        /// </summary>
        public RecordTypeBiz()
        {
            FileInfo xmlfile = new FileInfo(System.Environment.CurrentDirectory + "\\Data\\RecordType.xml");
            if (xmlfile.Exists)
            {
                xmldoc.Load(System.Environment.CurrentDirectory + "\\Data\\RecordType.xml");
            }
            else
            {
                xmldoc.InsertBefore(xmldoc.CreateXmlDeclaration("1.0", "utf-8", null), xmldoc.DocumentElement);
                xmldoc.AppendChild(xmldoc.CreateElement("RecordType"));
                xmldoc.Save(xmlfile.FullName);
            }
        }

        /// <summary>
        /// 获取所有记录类型
        /// </summary>
        /// <returns>记录类型集合</returns>
        public IList<RecordType> GetList()
        {
            IList<RecordType> rtlist = new List<RecordType>();
            XmlNodeList xnl = xmldoc.DocumentElement.ChildNodes;

            foreach (XmlElement item in xnl)
            {
                rtlist.Add(Get(item));
            }

            return rtlist;
        }

        /// <summary>
        /// 获取指定ID的记录类型
        /// </summary>
        /// <param name="id">指定ID</param>
        /// <returns>取得的记录类型对象</returns>
        public RecordType Get(int id)
        {
            XmlNode xn = xmldoc.DocumentElement.SelectSingleNode("/RecordType/type[@id=" + id.ToString() + "]");
            if (xn == null)
            {
                return null;
            }
            else
            {
                return Get((XmlElement)xn);
            }
        }

        /// <summary>
        /// 取得指定父类型的所有子类型
        /// </summary>
        /// <param name="parentId">父类型ID</param>
        /// <returns>取得的子类型集合</returns>
        public IList<RecordType> GetByParent(int parentId)
        {
            IList<RecordType> rtlist = new List<RecordType>();
            XmlNodeList xnl = xmldoc.DocumentElement.SelectNodes("/RecordType/type/parent[text()='" + parentId.ToString() + "']");
            XmlElement temp = null;
            foreach (XmlElement item in xnl)
            {
                temp = (XmlElement)item.ParentNode;
                rtlist.Add(Get(temp));
            }

            return rtlist;
        }

        private RecordType Get(XmlElement type)
        {
            RecordType rt = new RecordType();
            rt.Id = Convert.ToInt32(type.GetAttribute("id"));
            rt.Parent = type.FirstChild.FirstChild.Value == "0" ? null : Get(Convert.ToInt32(type.FirstChild.FirstChild.Value));
            rt.Name = type.FirstChild.NextSibling.FirstChild.Value;
            rt.Description = type.LastChild.FirstChild.Value;

            return rt;
        }

        /// <summary>
        /// 创建记录类型
        /// </summary>
        /// <param name="recordType">要创建的记录类型对象</param>
        public void Create(RecordType recordType)
        {
            XmlNode xn = xmldoc.DocumentElement.SelectSingleNode("/RecordType/type/name[text()='" + recordType.Name + "']");
            if (xn != null)
            {
                throw new RecordTypeIsExistException("记录类型已存在！");
            }
            else
            {
                XmlElement type = xmldoc.CreateElement("type");
                recordType.Id = ++Config.RecordTypeCount;
                Config.RecordTypeCount = recordType.Id;
                type.SetAttribute("id", recordType.Id.ToString());

                XmlElement parent = xmldoc.CreateElement("parent");
                XmlText parenttx = xmldoc.CreateTextNode(recordType.Parent != null ? recordType.Parent.Id.ToString() : "0");
                parent.AppendChild(parenttx);

                XmlElement name = xmldoc.CreateElement("name");
                XmlText nametx = xmldoc.CreateTextNode(recordType.Name);
                name.AppendChild(nametx);

                XmlElement description = xmldoc.CreateElement("description");
                XmlCDataSection descriptiontx = xmldoc.CreateCDataSection(recordType.Description);
                description.AppendChild(descriptiontx);

                type.AppendChild(parent);
                type.AppendChild(name);
                type.AppendChild(description);
                xmldoc.DocumentElement.AppendChild(type);

                xmldoc.Save(System.Environment.CurrentDirectory + "\\Data\\RecordType.xml");
            }
        }

        /// <summary>
        /// 更新记录类型
        /// </summary>
        /// <param name="recordType">需要更新的记录类型对象</param>
        public void Update(RecordType recordType)
        {
            XmlNode xn = xmldoc.DocumentElement.SelectSingleNode("/RecordType/type[@id=" + recordType.Id.ToString() + "]");
            if (xn == null)
            {
                throw new RecordTypeIsExistException("记录类型不存在！");
            }
            else
            {
                xn.FirstChild.FirstChild.Value = recordType.Parent != null ? recordType.Parent.Id.ToString() : "0";
                xn.FirstChild.NextSibling.FirstChild.Value = recordType.Name;
                xn.LastChild.FirstChild.Value = recordType.Description;
                xmldoc.Save(System.Environment.CurrentDirectory + "\\Data\\RecordType.xml");
            }
        }

        /// <summary>
        /// 删除记录类型(包括子类型)
        /// </summary>
        /// <param name="recordType">要删除的记录类型ID</param>
        public void Delete(int recordType)
        {
            XmlNode xn = xmldoc.DocumentElement.SelectSingleNode("/RecordType/type[@id=" + recordType.ToString() + "]");
            if (xn != null)
            {
                xmldoc.DocumentElement.RemoveChild(xn);
                xmldoc.Save(System.Environment.CurrentDirectory + "\\Data\\RecordType.xml");

                XmlNodeList xnl = xmldoc.DocumentElement.SelectNodes("/RecordType/type/parent[text()='" + recordType.ToString() + "']");
                XmlElement temp;
                foreach (XmlElement item in xnl)
                {
                    temp = (XmlElement)item.ParentNode;
                    Delete(Get(Convert.ToInt32(temp.GetAttribute("id"))));
                }
            }
        }

        /// <summary>
        /// 删除记录类型(包括子类型)
        /// </summary>
        /// <param name="recordType">要删除的记录类型对象</param>
        public void Delete(RecordType recordType)
        {
            Delete(recordType.Id);
        }
    }
}
