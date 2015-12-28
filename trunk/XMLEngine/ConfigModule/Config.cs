using System;
using System.Xml;

namespace alpha.personal.XMLEngine.ConfigModule
{
    public class Config
    {
        private Config() { }

        /// <summary>
        /// 记录最大的编号
        /// </summary>
        public static int RecordCount
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                return Convert.ToInt32(doc.GetElementsByTagName("RecordCount")[0].FirstChild.Value);
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                doc.GetElementsByTagName("RecordCount")[0].FirstChild.Value = value.ToString();
                doc.Save(System.Environment.CurrentDirectory + "\\config.xml");
            }
        }

        /// <summary>
        /// 记录类型最大的编号
        /// </summary>
        public static int RecordTypeCount
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                return Convert.ToInt32(doc.GetElementsByTagName("RecordTypeCount")[0].FirstChild.Value);
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                doc.GetElementsByTagName("RecordTypeCount")[0].FirstChild.Value = value.ToString();
                doc.Save(System.Environment.CurrentDirectory + "\\config.xml");
            }
        }

        /// <summary>
        /// 当前结余
        /// </summary>
        public static double CurrentBalance
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                return Convert.ToDouble(doc.GetElementsByTagName("CurrentBalance")[0].FirstChild.Value);
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                doc.GetElementsByTagName("CurrentBalance")[0].FirstChild.Value = value.ToString();
                doc.Save(System.Environment.CurrentDirectory + "\\config.xml");
            }
        }

        /// <summary>
        /// 账目起始时间
        /// </summary>
        public static DateTime StartDate
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                return Convert.ToDateTime(doc.GetElementsByTagName("StartDate")[0].FirstChild.Value);
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\config.xml");
                doc.GetElementsByTagName("StartDate")[0].FirstChild.Value = value.ToString("yyyy-MM-dd");
                doc.Save(System.Environment.CurrentDirectory + "\\config.xml");
            }
        }
    }
}
