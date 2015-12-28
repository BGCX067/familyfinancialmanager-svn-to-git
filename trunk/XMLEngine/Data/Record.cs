using System;

namespace alpha.personal.XMLEngine.Data
{
    public class Record
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

        private DateTime date;
        /// <summary>
        /// 账目日期
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private double spend;
        /// <summary>
        /// 花销数目，单位元(RMB)
        /// </summary>
        public double Spend
        {
            get { return spend; }
            set { spend = value; }
        }

        private double income;
        /// <summary>
        /// 收入数目，单位元(RMB)
        /// </summary>
        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        private RecordType type;
        /// <summary>
        /// 账目类型
        /// </summary>
        public RecordType Type
        {
            get { return type; }
            set { type = value; }
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
