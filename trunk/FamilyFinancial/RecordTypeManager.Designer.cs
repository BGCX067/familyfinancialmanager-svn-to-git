namespace alpha.personal.FamilyFinancial.UI
{
    partial class RecordTypeManager
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
            this.listRecordType = new System.Windows.Forms.ListView();
            this.menuRecordType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModifyRecordType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddRecordType = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddRecordType = new System.Windows.Forms.Button();
            this.btnDeleteRecordType = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuRecordType.SuspendLayout();
            this.SuspendLayout();
            // 
            // listRecordType
            // 
            this.listRecordType.CheckBoxes = true;
            this.listRecordType.ContextMenuStrip = this.menuRecordType;
            this.listRecordType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listRecordType.Location = new System.Drawing.Point(12, 12);
            this.listRecordType.MultiSelect = false;
            this.listRecordType.Name = "listRecordType";
            this.listRecordType.Size = new System.Drawing.Size(610, 309);
            this.listRecordType.TabIndex = 0;
            this.listRecordType.UseCompatibleStateImageBehavior = false;
            this.listRecordType.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listRecordType_DrawColumnHeader);
            this.listRecordType.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listRecordType_ItemChecked);
            this.listRecordType.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listRecordType_DrawItem);
            this.listRecordType.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listRecordType_ColumnWidthChanging);
            // 
            // menuRecordType
            // 
            this.menuRecordType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModifyRecordType,
            this.menuAddRecordType});
            this.menuRecordType.Name = "menuRecordType";
            this.menuRecordType.Size = new System.Drawing.Size(185, 48);
            this.menuRecordType.Opening += new System.ComponentModel.CancelEventHandler(this.menuRecordType_Opening);
            // 
            // menuModifyRecordType
            // 
            this.menuModifyRecordType.Name = "menuModifyRecordType";
            this.menuModifyRecordType.Size = new System.Drawing.Size(184, 22);
            this.menuModifyRecordType.Text = "修改当前类型";
            this.menuModifyRecordType.Click += new System.EventHandler(this.menuModifyRecordType_Click);
            // 
            // menuAddRecordType
            // 
            this.menuAddRecordType.Name = "menuAddRecordType";
            this.menuAddRecordType.Size = new System.Drawing.Size(184, 22);
            this.menuAddRecordType.Text = "为当前项添加子类型";
            this.menuAddRecordType.Click += new System.EventHandler(this.menuAddRecordType_Click);
            // 
            // btnAddRecordType
            // 
            this.btnAddRecordType.Location = new System.Drawing.Point(12, 327);
            this.btnAddRecordType.Name = "btnAddRecordType";
            this.btnAddRecordType.Size = new System.Drawing.Size(100, 23);
            this.btnAddRecordType.TabIndex = 2;
            this.btnAddRecordType.Text = "增加收支类型";
            this.btnAddRecordType.UseVisualStyleBackColor = true;
            this.btnAddRecordType.Click += new System.EventHandler(this.btnAddRecordType_Click);
            // 
            // btnDeleteRecordType
            // 
            this.btnDeleteRecordType.Location = new System.Drawing.Point(118, 327);
            this.btnDeleteRecordType.Name = "btnDeleteRecordType";
            this.btnDeleteRecordType.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteRecordType.TabIndex = 3;
            this.btnDeleteRecordType.Text = "删除选中项";
            this.btnDeleteRecordType.UseVisualStyleBackColor = true;
            this.btnDeleteRecordType.Click += new System.EventHandler(this.btnDeleteRecordType_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(522, 327);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RecordTypeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this.btnDeleteRecordType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddRecordType);
            this.Controls.Add(this.listRecordType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecordTypeManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收支类型管理";
            this.Load += new System.EventHandler(this.RecordTypeManager_Load);
            this.menuRecordType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listRecordType;
        private System.Windows.Forms.ContextMenuStrip menuRecordType;
        private System.Windows.Forms.ToolStripMenuItem menuAddRecordType;
        private System.Windows.Forms.ToolStripMenuItem menuModifyRecordType;
        private System.Windows.Forms.Button btnAddRecordType;
        private System.Windows.Forms.Button btnDeleteRecordType;
        private System.Windows.Forms.Button btnCancel;
    }
}