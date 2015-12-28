using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using alpha.personal.XMLEngine.ConfigModule;
using alpha.personal.XMLEngine.Data;
using alpha.personal.XMLEngine.Enumeration;

namespace alpha.personal.FamilyFinancial.UI
{
    public partial class MainUI : Form
    {
        private RecordBiz rb;
        private RecordTypeBiz rtb;
        private ListViewColumnSorter lvwColumnSorter;

        public MainUI()
        {
            InitializeComponent();
        }

        #region 初始化数据
        private void MainUI_Load(object sender, EventArgs e)
        {
            lvwColumnSorter = new ListViewColumnSorter();
            ItemList.ListViewItemSorter = lvwColumnSorter;

            cboxUnits.SelectedIndex = 1;

            currentBalance.Text = "结余:￥" + Config.CurrentBalance.ToString("n");

            rb = new RecordBiz();
            rtb = new RecordTypeBiz();

            initRecordTypeList();
            cboxRecordType.SelectedIndex = 0;

            IList<Record> recordList = rb.GetByDate(DateTime.Now, DateTime.Now, 0, QueryType.月单位);
            initItemList(recordList);
        }

        private void initRecordTypeList()
        {
            cboxRecordType.Items.Clear();
            cboxRecordType.Items.Add(new KeyValuePair<int, string>(0, "所有类型"));
            boundRecordTypeList(0, "");
            cboxRecordType.ValueMember = "key";
            cboxRecordType.DisplayMember = "value";
        }

        private void boundRecordTypeList(int parentId, string temp)
        {
            IList<RecordType> rtlist = rtb.GetByParent(parentId);
            foreach (RecordType item in rtlist)
            {
                cboxRecordType.Items.Add(new KeyValuePair<int, string>(item.Id, temp + "|--" + item.Name));
                boundRecordTypeList(item.Id, temp + "|  ");
            }
        }

        private void initItemList(IList<Record> recordList)
        {
            ItemList.OwnerDraw = true;
            ItemList.AllowColumnReorder = false;
            ItemList.CheckBoxes = true;
            ItemList.GridLines = true;
            ItemList.FullRowSelect = true;

            ItemList.Columns.Add(null, 19, HorizontalAlignment.Left);
            ItemList.Columns.Add("日期", 70, HorizontalAlignment.Center);
            ItemList.Columns.Add("支出", 100, HorizontalAlignment.Right);
            ItemList.Columns.Add("收入", 100, HorizontalAlignment.Right);
            ItemList.Columns.Add("类型", 150, HorizontalAlignment.Left);
            ItemList.Columns.Add("说明", 200, HorizontalAlignment.Left);

            boundItemList(recordList);
        }

        private void boundItemList(IList<Record> recordList)
        {
            foreach (Record item in recordList)
            {
                ItemList.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.Date.ToString("yyyy-MM-dd"), item.Spend == 0 ? "" : item.Spend.ToString("n"), item.Income == 0 ? "" : item.Income.ToString("n"), GetType(item.Type), item.Description }));
                ItemList.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
                ItemList.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 25);
            ItemList.SmallImageList = imgList;

            lvwColumnSorter.SortColumn = 1;
            lvwColumnSorter.Order = SortOrder.Descending;
            ItemList.Sort();
        }

        private string GetType(RecordType recordType)
        {
            if (recordType == null)
            {
                return "(无类型)";
            }
            string rt = recordType.Name;
            recordType = recordType.Parent;
            while (recordType != null)
            {
                rt = recordType.Name + ">>" + rt;
                recordType = recordType.Parent;
            }

            return rt;
        }

        private void ItemList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if (!e.Item.Checked)
            {
                e.Item.Checked = false;
            }
        }

        private void ItemList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
        private bool isSelectAll = false;
        private void ItemList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                foreach (ListViewItem item in ItemList.Items)
                {
                    item.Checked = !isSelectAll;
                }
                isSelectAll = !isSelectAll;
            }

            if (e.Column != 0 && e.Column != 5)
            {
                // 检查点击的列是不是现在的排序列.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // 重新设置此列的排序方法.
                    if (lvwColumnSorter.Order != SortOrder.Descending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // 设置排序列，默认为正向排序
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Descending;
                }

                // 用新的排序方法对ListView排序
                ItemList.Sort();
            }
        }

        private void ItemList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ItemList.Columns[e.ColumnIndex].Width;
        }
        #endregion

        #region 余额统计
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            currentBalance.Text = "正在统计...";
            Thread statistics = new Thread(StatisticsBalance);
            statistics.IsBackground = true;
            statistics.Start();
            btnStatistics.Enabled = false;
        }
        private void StatisticsBalance()
        {
            while (btnStatistics.Enabled != true)
            {
                Thread.Sleep(100);
                statisticsBalance();
            }
        }
        private delegate void StatisticsBalanceDelegate();
        private void statisticsBalance()
        {
            double balance = rb.StatisticsBalance();

            if (currentBalance.InvokeRequired)
            {
                StatisticsBalanceDelegate sb = new StatisticsBalanceDelegate(statisticsBalance);
                this.Invoke(sb);
            }
            else
            {
                currentBalance.Text = "结余:￥" + balance.ToString("n");
                btnStatistics.Enabled = true;
            }
        }
        #endregion

        #region 综合查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            ItemList.Enabled = false;
            labItemList.Visible = true;

            startDate = queryStartDate.Value;
            endDate = queryEndDate.Value;
            rtid = ((KeyValuePair<int, string>)cboxRecordType.SelectedItem).Key;
            qt = cboxUnits.SelectedItem.ToString() == "日" ? QueryType.日单位 : cboxUnits.SelectedItem.ToString() == "月" ? QueryType.月单位 : QueryType.年单位;

            Thread query = new Thread(QueryRecord);
            query.IsBackground = true;
            query.Start();
            queryStartDate.Enabled = false;
            queryEndDate.Enabled = false;
            cboxUnits.Enabled = false;
            cboxRecordType.Enabled = false; 
            btnQuery.Enabled = false;
        }
        private DateTime startDate, endDate;
        private int rtid = 0;
        private QueryType qt;
        private void QueryRecord()
        {

            while (ItemList.Enabled != true)
            {
                Thread.Sleep(5);
                queryRecord();
            }
        }
        private delegate void queryRecordDelegate();
        private void queryRecord()
        {
            IList<Record> recordList = rb.GetByDate(startDate, endDate, rtid, qt);

            if (ItemList.InvokeRequired)
            {
                queryRecordDelegate qrd = new queryRecordDelegate(queryRecord);
                this.Invoke(qrd);
            }
            else
            {
                ItemList.Clear();

                ItemList.Columns.Add(null, 19, HorizontalAlignment.Left);
                ItemList.Columns.Add("日期", 70, HorizontalAlignment.Center);
                ItemList.Columns.Add("支出", 100, HorizontalAlignment.Right);
                ItemList.Columns.Add("收入", 100, HorizontalAlignment.Right);
                ItemList.Columns.Add("类型", 150, HorizontalAlignment.Left);
                ItemList.Columns.Add("说明", 200, HorizontalAlignment.Left);

                foreach (Record item in recordList)
                {
                    ItemList.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.Date.ToString("yyyy-MM-dd"), item.Spend == 0 ? "" : item.Spend.ToString("n"), item.Income == 0 ? "" : item.Income.ToString("n"), GetType(item.Type), item.Description }));
                    ItemList.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.ColumnContent);
                    ItemList.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, 25);
                ItemList.SmallImageList = imgList;

                lvwColumnSorter.SortColumn = 1;
                lvwColumnSorter.Order = SortOrder.Descending;
                ItemList.Sort();

                ItemList.Enabled = true;
                queryStartDate.Enabled = true;
                queryEndDate.Enabled = true;
                cboxUnits.Enabled = true;
                cboxRecordType.Enabled = true;
                btnQuery.Enabled = true;
                labItemList.Visible = false;
            }
        }
        #endregion

        #region 刷新界面
        private void MainRefresh()
        {
            rb = new RecordBiz();
            rtb = new RecordTypeBiz();
            initRecordTypeList();
            cboxRecordType.SelectedIndex = rtid;
            btnQuery.PerformClick();
            btnStatistics.PerformClick();
        }
        #endregion

        #region 增加收支记录
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            if (addRecord.ShowDialog() != DialogResult.Cancel)
            {
                MainRefresh();
                if (addRecord.DialogResult == DialogResult.Retry)
                {
                    btnAddRecord_Click(sender, e);
                }
            }
        }
        #endregion

        #region 退出程序
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 修改、删除记录
        private void menuModify_Click(object sender, EventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.Modify(Convert.ToInt32(ItemList.SelectedItems[0].SubItems[0].Text.ToString()), Convert.ToDateTime(ItemList.SelectedItems[0].SubItems[1].Text.ToString()));
            if (addRecord.ShowDialog() != DialogResult.Cancel)
            {
                MainRefresh();
            }
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除后不可恢复，确定要删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Record record = new Record();
                record.Id = Convert.ToInt32(ItemList.SelectedItems[0].SubItems[0].Text.ToString());
                record.Date = Convert.ToDateTime(ItemList.SelectedItems[0].SubItems[1].Text.ToString());
                rb.Delete(record);
                MessageBox.Show("收支记录删除成功！");
                MainRefresh();
            }
        }
        #endregion

        #region 右键菜单设置
        private void menuItemSelect_Opening(object sender, CancelEventArgs e)
        {
            if (ItemList.SelectedItems.Count < 1)
            {
                e.Cancel = true;
            }
        }
        #endregion
        
        #region 类型管理
        private void btnRecordTypeManage_Click(object sender, EventArgs e)
        {
            RecordTypeManager rtm = new RecordTypeManager();
            rtm.ShowDialog();
            if (rtm.IsModify)
            {
                MainRefresh();
            }
        }
        #endregion

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (ItemList.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要删除的记录！");
            }
            else
            {
                if (MessageBox.Show("删除后不可恢复，确定要删除吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (ListViewItem item in ItemList.CheckedItems)
                    {
                        Record record = new Record();
                        record.Id = Convert.ToInt32(item.SubItems[0].Text.Trim());
                        record.Date = Convert.ToDateTime(item.SubItems[1].Text.Trim());
                        rb.Delete(record);
                    }
                    MessageBox.Show("收支记录删除成功！");
                    MainRefresh();
                }
            }
        }
    }
}
