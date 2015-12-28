using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using alpha.personal.XMLEngine.CustomizeException;
using alpha.personal.XMLEngine.Enumeration;

namespace alpha.personal.XMLEngine.Data
{
    public class XmlOperate
    {
        private IList<XmlDocument> xmlDocList = new List<XmlDocument>();

        /// <summary>
        /// 创建XmlDocument对象
        /// </summary>
        /// <param name="xmlFilePath">数据文件路径</param>
        /// <param name="xmlFileOpType">文件相关操作类型</param>
        /// <param name="datetime">账目年月</param>
        public XmlOperate(string xmlFilePath, XmlFileOpType xmlFileOpType, DateTime datetime)
        {
            init(xmlFilePath, xmlFileOpType, datetime);
        }

        /// <summary>
        /// 创建XmlDocument对象
        /// </summary>
        /// <param name="xmlFilePathList">数据文件路径</param>
        /// <param name="xmlFileOpType">文件相关操作类型</param>
        /// <param name="datetime">账目年月</param>
        public XmlOperate(IList<string> xmlFilePathList, XmlFileOpType xmlFileOpType, DateTime datetime)
        {
            foreach (string item in xmlFilePathList)
            {
                init(item, xmlFileOpType, datetime);
            }
        }
        /// <summary>
        /// 取得数据对象
        /// </summary>
        /// <returns>返回的XmlDocument对象</returns>
        public XmlDocument Get()
        {
            return xmlDocList[0];
        }

        /// <summary>
        /// 取得数据对象
        /// </summary>
        /// <returns>返回的XmlDocument对象</returns>
        public IList<XmlDocument> GetList()
        {
            return xmlDocList;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        public void Save()
        {
            foreach (XmlDocument item in xmlDocList)
            {
                item.Save(System.Environment.CurrentDirectory + "\\" + item.DocumentElement.GetAttribute("path"));
            }
        }

        #region 私有方法

        /// <summary>
        /// 初始化Document对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件路径</param>
        /// <param name="xmlFileOpType">文件相关操作类型</param>
        /// <param name="datetime">账目年月</param>
        private void init(string xmlFilePath, XmlFileOpType xmlFileOpType, DateTime datetime)
        {
            FileInfo xmlfile = new FileInfo(xmlFilePath);
            if (xmlfile.Exists)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFilePath);
                xmlDocList.Add(xmldoc);
            }
            else
            {
                if (xmlFileOpType == XmlFileOpType.不存在则创建)
                {
                    XmlDocument xmldoc = new XmlDocument();
                    XmlElement xe = xmldoc.CreateElement("datas");
                    xe.SetAttribute("date", datetime.ToString("yyyy-MM"));
                    xe.SetAttribute("path", ResolvePath(xmlFilePath));
                    xmldoc.InsertBefore(xmldoc.CreateXmlDeclaration("1.0", "utf-8", null), xmldoc.DocumentElement);
                    xmldoc.AppendChild(xe);
                    xmldoc.Save(xmlfile.FullName);
                    xmlDocList.Add(xmldoc);
                }
            }
        }

        /// <summary>
        /// 切割数据文件路径
        /// </summary>
        /// <param name="path">数据文件完整的路径</param>
        /// <returns>相对执行文件的数据路径</returns>
        private string ResolvePath(string path)
        {
            int index = path.LastIndexOf("Data");
            if (index <= 0)
            {
                return null;
            }
            string x = path.Substring(index);
            return x.Replace("\\","/");
        }

        #endregion
    }
}
