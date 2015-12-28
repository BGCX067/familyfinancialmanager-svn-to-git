
namespace alpha.personal.XMLEngine.Data
{
    /// <summary>
    /// 账目记录类型
    /// </summary>
    public class RecordType
    {
        private int id;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private RecordType parent;
        /// <summary>
        /// 父级记录类型
        /// </summary>
        public RecordType Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        private string name;
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        /// <summary>
        /// 描述说明
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
