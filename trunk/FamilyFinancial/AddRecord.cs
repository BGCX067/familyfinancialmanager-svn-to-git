using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using alpha.personal.XMLEngine.Data;

namespace alpha.personal.FamilyFinancial.UI
{
    public partial class AddRecord : Form
    {
        private RecordBiz rb;
        private RecordTypeBiz rtb;

        public AddRecord()
        {
            InitializeComponent();
        }

        #region 初始化数据
        private void AddRecord_Load(object sender, EventArgs e)
        {
            rb = new RecordBiz();
            rtb = new RecordTypeBiz();
            initRecordTypeList();
            if (isModify == true)
            {
                modify();
            }
        }

        private void initRecordTypeList()
        {
            txtRecordType.Items.Add(new KeyValuePair<int, string>(0, "所有类型"));
            boundRecordTypeList(0, "");
            txtRecordType.ValueMember = "key";
            txtRecordType.DisplayMember = "value";
            txtRecordType.SelectedIndex = 0;
        }

        private void boundRecordTypeList(int parentId, string temp)
        {
            IList<RecordType> rtlist = rtb.GetByParent(parentId);
            foreach (RecordType item in rtlist)
            {
                txtRecordType.Items.Add(new KeyValuePair<int, string>(item.Id, temp + "|--" + item.Name));
                boundRecordTypeList(item.Id, temp + "|  ");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region 添加数据
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            string moneytxt = txtMoney.Text.Trim();
            if (string.IsNullOrEmpty(moneytxt))
            {
                return;
            }
            double money;
            if (!double.TryParse(moneytxt, out money))
            {
                MessageBox.Show("金额只能是数字！");
                txtMoney.Undo();
            }
            else if (money < 0)
            {
                MessageBox.Show("金额只能是正数！");
                txtMoney.Undo();
            }
        }

        private void btnCompleteAndContinue_Click(object sender, EventArgs e)
        {
            if (Add())
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        private bool Add()
        {
            if (Check())
            {
                Record record = new Record();
                record.Date = dateRecordDate.Value;
                if (radioIsIncome.Checked)
                {
                    record.Income = Convert.ToDouble(txtMoney.Text.Trim());
                }
                else
                {
                    record.Spend = Convert.ToDouble(txtMoney.Text.Trim());
                }
                record.Type = rtb.Get(((KeyValuePair<int, string>)txtRecordType.SelectedItem).Key);
                record.Description = txtDescription.Text.Trim();
                rb.Create(record);
                MessageBox.Show("收支记录添加成功！");
                return true;
            }
            return false;
        }

        private bool Check()
        {
            bool flag = true;

            if (radioIsIncome.Checked == false && radioIsSpend.Checked == false)
            {
                flag = false;
                MessageBox.Show("请选择收入或支出！");
            }
            if (string.IsNullOrEmpty(txtMoney.Text.Trim()))
            {
                flag = false;
                MessageBox.Show("请输入正确的金额！");
            }
            if (txtRecordType.SelectedIndex == 0)
            {
                flag = false;
                MessageBox.Show("请选择具体的收支类型！");
            }

            return flag;
        }

        private void btnCompleteAndExit_Click(object sender, EventArgs e)
        {
            if (Add())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region 修改数据
        private int modifyRecordId;
        private DateTime modifyRecordDate;
        private bool isModify = false;
        private Record oldRecord;
        public void modify()
        {
            Record record = rb.Get(modifyRecordId, modifyRecordDate);
            oldRecord = record;

            dateRecordDate.Value = record.Date;
            if (record.Spend == 0)
            {
                radioIsIncome.Checked = true;
                radioIsSpend.Checked = false;
                txtMoney.Text = record.Income.ToString("n");
            }
            else
            {
                radioIsIncome.Checked = false;
                radioIsSpend.Checked = true;
                txtMoney.Text = record.Spend.ToString("n");
            }
            if (record.Type == null)
            {
                txtRecordType.SelectedIndex = 0;
            }
            else
            {

                for (int i = 0; i < txtRecordType.Items.Count; i++)
                {
                    if (((KeyValuePair<int, string>)txtRecordType.Items[i]).Key == record.Type.Id)
                    {
                        txtRecordType.SelectedIndex = i;
                        break;
                    }
                }
            }
            txtDescription.Text = record.Description;

            btnCompleteAndContinue.Visible = false;
            btnCompleteAndExit.Visible = false;
            btnCancel.Location = new Point(254, 180);
            this.AcceptButton = btnModify;
            this.Text = "修改收支记录";
        }
        public void Modify(int recordId,DateTime recordDate)
        {
            modifyRecordId = recordId;
            modifyRecordDate = recordDate;
            isModify = true;
            btnModify.Visible = true;
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                Record record = new Record();
                record.Date = dateRecordDate.Value;
                record.Id = modifyRecordId;
                if (radioIsIncome.Checked)
                {
                    record.Income = Convert.ToDouble(txtMoney.Text.Trim());
                }
                else
                {
                    record.Spend = Convert.ToDouble(txtMoney.Text.Trim());
                }
                record.Type = rtb.Get(((KeyValuePair<int, string>)txtRecordType.SelectedItem).Key);
                record.Description = txtDescription.Text.Trim();
                rb.Update(record, oldRecord);
                MessageBox.Show("收支记录修改成功！");
                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
