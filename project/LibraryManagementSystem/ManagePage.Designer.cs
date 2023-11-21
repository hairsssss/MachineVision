namespace LibraryManagementSystem {
    partial class ManagePage {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.booksView2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.booksView3 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.countIpt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.publishingHouseIpt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.authorIpt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bookIpt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksView3)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 488);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.booksView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "图书库";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // booksView2
            // 
            this.booksView2.AllowUserToAddRows = false;
            this.booksView2.AllowUserToDeleteRows = false;
            this.booksView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksView2.Location = new System.Drawing.Point(21, 17);
            this.booksView2.Name = "booksView2";
            this.booksView2.ReadOnly = true;
            this.booksView2.RowHeadersWidth = 51;
            this.booksView2.RowTemplate.Height = 27;
            this.booksView2.Size = new System.Drawing.Size(731, 410);
            this.booksView2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.booksView3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "借阅记录";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // booksView3
            // 
            this.booksView3.AllowUserToAddRows = false;
            this.booksView3.AllowUserToDeleteRows = false;
            this.booksView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksView3.Location = new System.Drawing.Point(19, 24);
            this.booksView3.Name = "booksView3";
            this.booksView3.ReadOnly = true;
            this.booksView3.RowHeadersWidth = 51;
            this.booksView3.RowTemplate.Height = 27;
            this.booksView3.Size = new System.Drawing.Size(731, 410);
            this.booksView3.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.countIpt);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.publishingHouseIpt);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.authorIpt);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.bookIpt);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 459);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "新增书籍";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // countIpt
            // 
            this.countIpt.Location = new System.Drawing.Point(231, 263);
            this.countIpt.Name = "countIpt";
            this.countIpt.Size = new System.Drawing.Size(347, 25);
            this.countIpt.TabIndex = 10;
            this.countIpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CountIptKeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "数量：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 58);
            this.button1.TabIndex = 8;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SubmitBtnClick);
            // 
            // publishingHouseIpt
            // 
            this.publishingHouseIpt.Location = new System.Drawing.Point(231, 187);
            this.publishingHouseIpt.Name = "publishingHouseIpt";
            this.publishingHouseIpt.Size = new System.Drawing.Size(347, 25);
            this.publishingHouseIpt.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "出版社：";
            // 
            // authorIpt
            // 
            this.authorIpt.Location = new System.Drawing.Point(231, 119);
            this.authorIpt.Name = "authorIpt";
            this.authorIpt.Size = new System.Drawing.Size(347, 25);
            this.authorIpt.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "作者：";
            // 
            // bookIpt
            // 
            this.bookIpt.Location = new System.Drawing.Point(231, 50);
            this.bookIpt.Name = "bookIpt";
            this.bookIpt.Size = new System.Drawing.Size(347, 25);
            this.bookIpt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "书名：";
            // 
            // ManagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 521);
            this.Controls.Add(this.tabControl1);
            this.Name = "ManagePage";
            this.Text = "ManagePage";
            this.Load += new System.EventHandler(this.PageLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.booksView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.booksView3)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView booksView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView booksView3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox publishingHouseIpt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox authorIpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bookIpt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countIpt;
        private System.Windows.Forms.Label label4;
    }
}