using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using alpha.personal.XMLEngine.Data;

namespace alpha.personal.FamilyFinancial.UI
{
    public partial class AddRecordType : Form
    {
        private RecordTypeBiz rtb;

        public AddRecordType()
        {
            InitializeComponent();
        }

        #region 初始化数据
        private void AddRecordType_Load(object sender, EventArgs e)
        {
            rtb = new RecordTypeBiz();
            initRecordTypeList();
        }

        private void initRecordTypeList()
        {
            cboxRecordType.Items.Clear();
            cboxRecordType.Items.Add(new KeyValuePair<int, string>(0, "根类型"));
            boundRecordTypeList(0, "");
            cboxRecordType.ValueMember = "key";
            cboxRecordType.DisplayMember = "value";
            if (isCustomizeAdd)
            {
                for (int i = 0; i < cboxRecordType.Items.Count; i++)
                {
                    if (CustomizeId == ((KeyValuePair<int, string>)cboxRecordType.Items[i]).Key)
                    {
                        cboxRecordType.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                if (!isModify)
                    cboxRecordType.SelectedIndex = 0;
                else
                {
                    if (ModifyObj.Parent == null)
                        cboxRecordType.SelectedIndex = 0;
                    else
                        for (int i = 0; i < cboxRecordType.Items.Count; i++)
                        {
                            if (ModifyObj.Parent.Id == ((KeyValuePair<int, string>)cboxRecordType.Items[i]).Key)
                            {
                                cboxRecordType.SelectedIndex = i;
                                break;
                            }
                        }
                }
            }
        }

        private void boundRecordTypeList(int parentId, string temp)
        {
            IList<RecordType> rtlist = rtb.GetByParent(parentId);
            foreach (RecordType item in rtlist)
            {
                if (isModify && item.Id == ModifyObj.Id)
                {
                    continue;
                }
                cboxRecordType.Items.Add(new KeyValuePair<int, string>(item.Id, temp + "|--" + item.Name));
                boundRecordTypeList(item.Id, temp + "|  ");
            }
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region 修改
        private bool isModify = false;
        private RecordType ModifyObj = null;
        private bool isCustomizeAdd = false;
        private int customizeId = 0;
        public int CustomizeId
        {
            private get { return customizeId; }
            set
            {
                if (value > 0)
                {
                    isCustomizeAdd = true;
                    customizeId = value;
                }
            }
        }
        public void Modify(int recordTypeId)
        {
            rtb = new RecordTypeBiz();
            RecordType rt = rtb.Get(recordTypeId);
            if (rt != null)
            {
                this.Text = "修改收支记录类型";
                ModifyObj = rt;
                txtRecordTypeName.Text = rt.Name;
                txtDescription.Text = rt.Description;
                isModify = true;
            }
            else
            {
                MessageBox.Show("类型不存在！");
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region 添加
        private void btnAddComplete_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (isModify)
                {
                    ModifyObj.Description = txtDescription.Text.Trim();
                    ModifyObj.Name = txtRecordTypeName.Text.Trim();
                    ModifyObj.Parent = rtb.Get(((KeyValuePair<int, string>)cboxRecordType.SelectedItem).Key);
                    rtb.Update(ModifyObj);
                    MessageBox.Show("收支类型修改成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    RecordType newRecordType = new RecordType();
                    newRecordType.Description = txtDescription.Text.Trim();
                    newRecordType.Name = txtRecordTypeName.Text.Trim();
                    newRecordType.Parent = rtb.Get(((KeyValuePair<int, string>)cboxRecordType.SelectedItem).Key);
                    rtb.Create(newRecordType);
                    MessageBox.Show("收支类型添加成功！");
                    this.DialogResult = DialogResult.OK;
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool Check()
        {
            bool flag = true;

            if (string.IsNullOrEmpty(txtRecordTypeName.Text.Trim()))
            {
                flag = false;
            }

            return flag;
        }
        #endregion
    }
}
