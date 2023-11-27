namespace work_11_16 {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.nameBox = new System.Windows.Forms.GroupBox();
            this.nameIpt = new System.Windows.Forms.TextBox();
            this.contryBox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.HobbyBox = new System.Windows.Forms.GroupBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.nameBox.SuspendLayout();
            this.contryBox.SuspendLayout();
            this.HobbyBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Controls.Add(this.nameIpt);
            this.nameBox.Location = new System.Drawing.Point(12, 12);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(776, 62);
            this.nameBox.TabIndex = 0;
            this.nameBox.TabStop = false;
            this.nameBox.Text = "姓名";
            // 
            // nameIpt
            // 
            this.nameIpt.Location = new System.Drawing.Point(57, 24);
            this.nameIpt.Name = "nameIpt";
            this.nameIpt.Size = new System.Drawing.Size(275, 25);
            this.nameIpt.TabIndex = 0;
            // 
            // contryBox
            // 
            this.contryBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.contryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contryBox.Controls.Add(this.radioButton3);
            this.contryBox.Controls.Add(this.radioButton2);
            this.contryBox.Controls.Add(this.radioButton1);
            this.contryBox.Location = new System.Drawing.Point(12, 95);
            this.contryBox.Name = "contryBox";
            this.contryBox.Size = new System.Drawing.Size(776, 89);
            this.contryBox.TabIndex = 1;
            this.contryBox.TabStop = false;
            this.contryBox.Text = "国家";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(363, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 19);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "日本";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.ChangeContry);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(213, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "美国";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ChangeContry);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(62, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "中国";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.ChangeContry);
            // 
            // HobbyBox
            // 
            this.HobbyBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.HobbyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HobbyBox.Controls.Add(this.selectAllCheckBox);
            this.HobbyBox.Controls.Add(this.checkedListBox1);
            this.HobbyBox.Location = new System.Drawing.Point(12, 233);
            this.HobbyBox.Name = "HobbyBox";
            this.HobbyBox.Size = new System.Drawing.Size(776, 158);
            this.HobbyBox.TabIndex = 2;
            this.HobbyBox.TabStop = false;
            this.HobbyBox.Text = "爱好";
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(384, 65);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(59, 19);
            this.selectAllCheckBox.TabIndex = 1;
            this.selectAllCheckBox.Text = "全选";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.Click += new System.EventHandler(this.SelectAllItems);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "打游戏",
            "看电影",
            "敲代码",
            "睡觉",
            "听歌",
            "旅游"});
            this.checkedListBox1.Location = new System.Drawing.Point(75, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(149, 124);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckSelect);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(282, 427);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(173, 55);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "提交";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.SubmitClick);
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 521);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.HobbyBox);
            this.Controls.Add(this.contryBox);
            this.Controls.Add(this.nameBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FormLoad);
            this.nameBox.ResumeLayout(false);
            this.nameBox.PerformLayout();
            this.contryBox.ResumeLayout(false);
            this.contryBox.PerformLayout();
            this.HobbyBox.ResumeLayout(false);
            this.HobbyBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameBox;
        private System.Windows.Forms.GroupBox contryBox;
        private System.Windows.Forms.GroupBox HobbyBox;
        private System.Windows.Forms.TextBox nameIpt;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
    }
}