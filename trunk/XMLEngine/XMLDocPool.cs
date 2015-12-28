using System.Collections.Generic;
using System.Xml;

namespace alpha.personal.XMLEngine
{
    /// <summary>
    /// XmlDocument对象池
    /// </summary>
    public class XMLDocPool
    {
        private static XMLDocPool _xmlDocPool;

        private XMLDocPool() { }

        /// <summary>
        /// 初始化XmlDoc对象池
        /// </summary>
        /// <returns></returns>
        public static XMLDocPool Instance
        {
            get
            {
                if (_xmlDocPool == null)
                {
                    _xmlDocPool = new XMLDocPool();
                }
                return _xmlDocPool;
            }
        }

        private Stack<XmlDocument> waitXmlDoc = new Stack<XmlDocument>();
        /// <summary>
        /// 获取一个XmlDocument对象
        /// </summary>
        /// <returns>XmlDocument对象</returns>
        public XmlDocument GetXmlDoc()
        {
            lock (typeof(XMLDocPool))
            {
                if (waitXmlDoc.Count == 0)
                {
                    waitXmlDoc.Push(new XmlDocument());
                }
                currentObjNum++;
                return waitXmlDoc.Pop();
            }
        }

        /// <summary>
        /// XmlDocument对象使用完毕，送回对象池
        /// </summary>
        /// <param name="overXmlDoc">使用完毕的XmlDocument对象</param>
        public void Return(XmlDocument overXmlDoc)
        {
            waitXmlDoc.Push(overXmlDoc);
            currentObjNum--;
        }

        /// <summary>
        /// 属性
        /// </summary>
        #region

        private int currentObjNum = 0;
        /// <summary>
        /// 当前使用中的对象个数
        /// </summary>
        public int CurrentObjNum
        {
            get { return currentObjNum; }
            set { currentObjNum = value; }
        }

        #endregion
    }
}
