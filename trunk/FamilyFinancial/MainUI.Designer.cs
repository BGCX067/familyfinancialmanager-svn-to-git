namespace alpha.personal.FamilyFinancial.UI
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ItemList = new System.Windows.Forms.ListView();
            this.menuItemSelect = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.queryStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.queryEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxUnits = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxRecordType = new System.Windows.Forms.ComboBox();
            this.currentBalance = new System.Windows.Forms.Label();
            this.labItemList = new System.Windows.Forms.Label();
            this.btnRecordTypeManage = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.menuItemSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemList
            // 
            this.ItemList.ContextMenuStrip = this.menuItemSelect;
            this.ItemList.Location = new System.Drawing.Point(127, 40);
            this.ItemList.MultiSelect = false;
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(845, 510);
            this.ItemList.TabIndex = 0;
            this.ItemList.UseCompatibleStateImageBehavior = false;
            this.ItemList.View = System.Windows.Forms.View.Details;
            this.ItemList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ItemList_DrawColumnHeader);
            this.ItemList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ItemList_DrawItem);
            this.ItemList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ItemList_ColumnClick);
            this.ItemList.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ItemList_ColumnWidthChanging);
            // 
            // menuItemSelect
            // 
            this.menuItemSelect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModify,
            this.menuDelete});
            this.menuItemSelect.Name = "menuItemSelect";
            this.menuItemSelect.Size = new System.Drawing.Size(121, 48);
            this.menuItemSelect.Opening += new System.ComponentModel.CancelEventHandler(this.menuItemSelect_Opening);
            // 
            // menuModify
            // 
            this.menuModify.Name = "menuModify";
            this.menuModify.Size = new System.Drawing.Size(120, 22);
            this.menuModify.Text = "修改(&M)";
            this.menuModify.Click += new System.EventHandler(this.menuModify_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(120, 22);
            this.menuDelete.Text = "删除(&D)";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(9, 40);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(110, 23);
            this.btnStatistics.TabIndex = 1;
            this.btnStatistics.Text = "重新统计余额";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "起始时间：";
            // 
            // queryStartDate
            // 
            this.queryStartDate.Location = new System.Drawing.Point(187, 10);
            this.queryStartDate.Name = "queryStartDate";
            this.queryStartDate.Size = new System.Drawing.Size(175, 20);
            this.queryStartDate.TabIndex = 4;
            this.queryStartDate.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "截止时间：";
            // 
            // queryEndDate
            // 
            this.queryEndDate.Location = new System.Drawing.Point(426, 10);
            this.queryEndDate.Name = "queryEndDate";
            this.queryEndDate.Size = new System.Drawing.Size(175, 20);
            this.queryEndDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "单位：";
            // 
            // cboxUnits
            // 
            this.cboxUnits.FormattingEnabled = true;
            this.cboxUnits.Items.AddRange(new object[] {
            "日",
            "月",
            "年"});
            this.cboxUnits.Location = new System.Drawing.Point(645, 9);
            this.cboxUnits.Name = "cboxUnits";
            this.cboxUnits.Size = new System.Drawing.Size(35, 21);
            this.cboxUnits.TabIndex = 8;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(927, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(45, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "类型：";
            // 
            // cboxRecordType
            // 
            this.cboxRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRecordType.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxRecordType.FormattingEnabled = true;
            this.cboxRecordType.Location = new System.Drawing.Point(721, 9);
            this.cboxRecordType.Name = "cboxRecordType";
            this.cboxRecordType.Size = new System.Drawing.Size(200, 21);
            this.cboxRecordType.TabIndex = 11;
            // 
            // currentBalance
            // 
            this.currentBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.currentBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentBalance.Location = new System.Drawing.Point(9, 9);
            this.currentBalance.Margin = new System.Windows.Forms.Padding(0);
            this.currentBalance.Name = "currentBalance";
            this.currentBalance.Size = new System.Drawing.Size(110, 25);
            this.currentBalance.TabIndex = 13;
            this.currentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labItemList
            // 
            this.labItemList.BackColor = System.Drawing.Color.White;
            this.labItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labItemList.Location = new System.Drawing.Point(127, 40);
            this.labItemList.Name = "labItemList";
            this.labItemList.Size = new System.Drawing.Size(845, 510);
            this.labItemList.TabIndex = 14;
            this.labItemList.Text = "正在加载，请稍等...";
            this.labItemList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labItemList.Visible = false;
            // 
            // btnRecordTypeManage
            // 
            this.btnRecordTypeManage.Location = new System.Drawing.Point(9, 70);
            this.btnRecordTypeManage.Name = "btnRecordTypeManage";
            this.btnRecordTypeManage.Size = new System.Drawing.Size(110, 23);
            this.btnRecordTypeManage.TabIndex = 15;
            this.btnRecordTypeManage.Text = "账目类型管理";
            this.btnRecordTypeManage.UseCompatibleTextRendering = true;
            this.btnRecordTypeManage.UseVisualStyleBackColor = true;
            this.btnRecordTypeManage.Click += new System.EventHandler(this.btnRecordTypeManage_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Location = new System.Drawing.Point(9, 120);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(110, 23);
            this.btnAddRecord.TabIndex = 16;
            this.btnAddRecord.Text = "增加收支记录";
            this.btnAddRecord.UseVisualStyleBackColor = true;
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(9, 526);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Location = new System.Drawing.Point(9, 150);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(110, 23);
            this.btnDeleteRecord.TabIndex = 18;
            this.btnDeleteRecord.Text = "删除选中记录";
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecordTypeManage);
            this.Controls.Add(this.btnAddRecord);
            this.Controls.Add(this.currentBalance);
            this.Controls.Add(this.cboxRecordType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.cboxUnits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.queryEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.ItemList);
            this.Controls.Add(this.labItemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Family Financial";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.menuItemSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ItemList;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker queryStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker queryEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxUnits;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxRecordType;
        private System.Windows.Forms.Label currentBalance;
        private System.Windows.Forms.Label labItemList;
        private System.Windows.Forms.Button btnRecordTypeManage;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip menuItemSelect;
        private System.Windows.Forms.ToolStripMenuItem menuModify;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.Button btnDeleteRecord;

    }
}