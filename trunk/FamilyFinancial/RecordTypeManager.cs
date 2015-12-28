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
    public partial class RecordTypeManager : Form
    {
        private RecordTypeBiz rtb;

        private bool isModify = false;
        /// <summary>
        /// 是否有修改
        /// </summary>
        public bool IsModify
        {
            get { return isModify; }
            set { isModify = value; }
        }

        public RecordTypeManager()
        {
            InitializeComponent();
        }

        #region 初始化数据
        private void RecordTypeManager_Load(object sender, EventArgs e)
        {
            rtb = new RecordTypeBiz();
            initListRecordType();
        }

        private void initListRecordType()
        {
            listRecordType.OwnerDraw = true;
            listRecordType.AllowColumnReorder = false;
            listRecordType.CheckBoxes = true;
            listRecordType.GridLines = true;
            listRecordType.FullRowSelect = true;
            listRecordType.View = View.Details;

            listRecordType.Clear();

            listRecordType.Columns.Add(null, 19, HorizontalAlignment.Left);
            listRecordType.Columns.Add(null, 0, HorizontalAlignment.Left);
            listRecordType.Columns.Add("类型名称", 70, HorizontalAlignment.Left);
            listRecordType.Columns.Add("描述说明", 100, HorizontalAlignment.Left);

            listRecordType.Items.Add(new ListViewItem(new string[] { "0", "0", "总类型", "包含所有收支类型" }));
            listRecordType.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);
            boundListRecordType(0, "");
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            listRecordType.SmallImageList = imgList;
        }

        private void boundListRecordType(int parentId, string temp)
        {
            IList<RecordType> rtlist = rtb.GetByParent(parentId);
            foreach (RecordType item in rtlist)
            {
                listRecordType.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.Parent == null ? "0" : item.Parent.Id.ToString(), temp + "|--" + item.Name, item.Description }));
                boundListRecordType(item.Id, temp + "|  ");
                listRecordType.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
                listRecordType.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.ColumnContent);

            }
        }

        private void listRecordType_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if (!e.Item.Checked)
            {
                e.Item.Checked = false;
            }
        }

        private void listRecordType_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void listRecordType_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listRecordType.Columns[e.ColumnIndex].Width;
        }

        private void menuRecordType_Opening(object sender, CancelEventArgs e)
        {
            if (listRecordType.SelectedItems.Count < 1 && listRecordType.CheckedItems.Count < 1)
            {
                e.Cancel = true;
            }
        }

        private void listRecordType_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == false)
            {
                foreach (ListViewItem item in listRecordType.Items)
                {
                    if (item.SubItems[0].Text == e.Item.SubItems[1].Text)
                    {
                        item.Checked = false;
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in listRecordType.Items)
                {
                    if (item.SubItems[1].Text == e.Item.SubItems[0].Text)
                    {
                        item.Checked = e.Item.Checked;
                    }
                }
            }
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 删除项
        private void btnDeleteRecordType_Click(object sender, EventArgs e)
        {
            if (listRecordType.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("删除类型将同时删除其子类型，确定继续吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string rtname = "收支类型\n";
                    foreach (ListViewItem item in listRecordType.CheckedItems)
                    {
                        rtb.Delete(Convert.ToInt32(item.SubItems[0].Text.Trim()));
                        rtname += item.SubItems[2].Text.Trim() + "\n";
                    }
                    initListRecordType();
                    MessageBox.Show(rtname + "删除成功！");
                    this.IsModify = true;
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的收支类型！");
            }
        }
        #endregion

        #region 添加项
        private void btnAddRecordType_Click(object sender, EventArgs e)
        {
            AddRecordType addrt = new AddRecordType();
            if (addrt.ShowDialog() != DialogResult.Cancel)
            {
                this.IsModify = true;
                rtb = new RecordTypeBiz();
                initListRecordType();
            }
        }

        private void menuAddRecordType_Click(object sender, EventArgs e)
        {
            AddRecordType addrt = new AddRecordType();
            addrt.CustomizeId = Convert.ToInt32(listRecordType.SelectedItems[0].SubItems[0].Text.Trim());
            if (addrt.ShowDialog() != DialogResult.Cancel)
            {
                this.IsModify = true;
                rtb = new RecordTypeBiz();
                initListRecordType();
            }
        }
        #endregion

        #region 修改项
        private void menuModifyRecordType_Click(object sender, EventArgs e)
        {
            AddRecordType addrt = new AddRecordType();
            if (listRecordType.SelectedItems.Count > 0)
            {
                if (listRecordType.SelectedItems[0].SubItems[0].Text.Trim() != "0")
                {
                    addrt.Modify(Convert.ToInt32(listRecordType.SelectedItems[0].SubItems[0].Text.Trim()));
                    if (addrt.ShowDialog() != DialogResult.Cancel)
                    {
                        this.IsModify = true;
                        rtb = new RecordTypeBiz();
                        initListRecordType();
                    }
                }
                else
                {
                    MessageBox.Show("不能修改总类型！");
                }
            }
        }
        #endregion
    }
}
