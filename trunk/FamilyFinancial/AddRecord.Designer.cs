namespace alpha.personal.FamilyFinancial.UI
{
    partial class AddRecord
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
            this.dateRecordDate = new System.Windows.Forms.DateTimePicker();
            this.radioIsIncome = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioIsSpend = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecordType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCompleteAndExit = new System.Windows.Forms.Button();
            this.btnCompleteAndContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "收支日期：";
            // 
            // dateRecordDate
            // 
            this.dateRecordDate.Location = new System.Drawing.Point(74, 11);
            this.dateRecordDate.Name = "dateRecordDate";
            this.dateRecordDate.Size = new System.Drawing.Size(200, 20);
            this.dateRecordDate.TabIndex = 1;
            // 
            // radioIsIncome
            // 
            this.radioIsIncome.AutoSize = true;
            this.radioIsIncome.Checked = true;
            this.radioIsIncome.Location = new System.Drawing.Point(317, 11);
            this.radioIsIncome.Name = "radioIsIncome";
            this.radioIsIncome.Size = new System.Drawing.Size(49, 17);
            this.radioIsIncome.TabIndex = 2;
            this.radioIsIncome.TabStop = true;
            this.radioIsIncome.Text = "收入";
            this.radioIsIncome.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型：";
            // 
            // radioIsSpend
            // 
            this.radioIsSpend.AutoSize = true;
            this.radioIsSpend.Location = new System.Drawing.Point(367, 11);
            this.radioIsSpend.Name = "radioIsSpend";
            this.radioIsSpend.Size = new System.Drawing.Size(49, 17);
            this.radioIsSpend.TabIndex = 4;
            this.radioIsSpend.Text = "支出";
            this.radioIsSpend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "收支类型：";
            // 
            // txtRecordType
            // 
            this.txtRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRecordType.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRecordType.FormattingEnabled = true;
            this.txtRecordType.Location = new System.Drawing.Point(74, 42);
            this.txtRecordType.Name = "txtRecordType";
            this.txtRecordType.Size = new System.Drawing.Size(200, 21);
            this.txtRecordType.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "金额：";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(317, 42);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(75, 20);
            this.txtMoney.TabIndex = 8;
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "说　　明：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(74, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(338, 98);
            this.txtDescription.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "元";
            // 
            // btnCompleteAndExit
            // 
            this.btnCompleteAndExit.Location = new System.Drawing.Point(336, 181);
            this.btnCompleteAndExit.Name = "btnCompleteAndExit";
            this.btnCompleteAndExit.Size = new System.Drawing.Size(75, 23);
            this.btnCompleteAndExit.TabIndex = 12;
            this.btnCompleteAndExit.Text = "完成";
            this.btnCompleteAndExit.UseVisualStyleBackColor = true;
            this.btnCompleteAndExit.Click += new System.EventHandler(this.btnCompleteAndExit_Click);
            // 
            // btnCompleteAndContinue
            // 
            this.btnCompleteAndContinue.Location = new System.Drawing.Point(193, 181);
            this.btnCompleteAndContinue.Name = "btnCompleteAndContinue";
            this.btnCompleteAndContinue.Size = new System.Drawing.Size(137, 23);
            this.btnCompleteAndContinue.TabIndex = 13;
            this.btnCompleteAndContinue.Text = "完成并继续添加下一条";
            this.btnCompleteAndContinue.UseVisualStyleBackColor = true;
            this.btnCompleteAndContinue.Click += new System.EventHandler(this.btnCompleteAndContinue_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(335, 180);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 15;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // AddRecord
            // 
            this.AcceptButton = this.btnCompleteAndContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(427, 212);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCompleteAndContinue);
            this.Controls.Add(this.btnCompleteAndExit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRecordType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioIsSpend);
            this.Controls.Add(this.radioIsIncome);
            this.Controls.Add(this.dateRecordDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRecord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "增加收支记录";
            this.Load += new System.EventHandler(this.AddRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateRecordDate;
        private System.Windows.Forms.RadioButton radioIsIncome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioIsSpend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtRecordType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCompleteAndExit;
        private System.Windows.Forms.Button btnCompleteAndContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnModify;
    }
}