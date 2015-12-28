namespace alpha.personal.FamilyFinancial.UI
{
    partial class AddRecordType
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboxRecordType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecordTypeName = new System.Windows.Forms.TextBox();
            this.btnAddComplete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "父  类  型 ：";
            // 
            // cboxRecordType
            // 
            this.cboxRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRecordType.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxRecordType.FormattingEnabled = true;
            this.cboxRecordType.Location = new System.Drawing.Point(74, 10);
            this.cboxRecordType.Name = "cboxRecordType";
            this.cboxRecordType.Size = new System.Drawing.Size(200, 21);
            this.cboxRecordType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "类型名称：";
            // 
            // txtRecordTypeName
            // 
            this.txtRecordTypeName.Location = new System.Drawing.Point(74, 46);
            this.txtRecordTypeName.Name = "txtRecordTypeName";
            this.txtRecordTypeName.Size = new System.Drawing.Size(200, 20);
            this.txtRecordTypeName.TabIndex = 3;
            // 
            // btnAddComplete
            // 
            this.btnAddComplete.Location = new System.Drawing.Point(128, 172);
            this.btnAddComplete.Name = "btnAddComplete";
            this.btnAddComplete.Size = new System.Drawing.Size(70, 23);
            this.btnAddComplete.TabIndex = 4;
            this.btnAddComplete.Text = "完成";
            this.btnAddComplete.UseVisualStyleBackColor = true;
            this.btnAddComplete.Click += new System.EventHandler(this.btnAddComplete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(74, 83);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 83);
            this.txtDescription.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "说　明　：";
            // 
            // AddRecordType
            // 
            this.AcceptButton = this.btnAddComplete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(285, 207);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddComplete);
            this.Controls.Add(this.txtRecordTypeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboxRecordType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRecordType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加收支类型";
            this.Load += new System.EventHandler(this.AddRecordType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxRecordType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecordTypeName;
        private System.Windows.Forms.Button btnAddComplete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
    }
}