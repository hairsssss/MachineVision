namespace LibraryManagementSystem {
    partial class StudentPage {
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
            this.booksView1 = new System.Windows.Forms.DataGridView();
            this.returnBookBtn = new System.Windows.Forms.Button();
            this.signOutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksView1)).BeginInit();
            this.SuspendLayout();
            // 
            // booksView1
            // 
            this.booksView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksView1.Location = new System.Drawing.Point(75, 80);
            this.booksView1.Name = "booksView1";
            this.booksView1.RowHeadersWidth = 51;
            this.booksView1.RowTemplate.Height = 27;
            this.booksView1.Size = new System.Drawing.Size(669, 288);
            this.booksView1.TabIndex = 0;
            // 
            // returnBookBtn
            // 
            this.returnBookBtn.Location = new System.Drawing.Point(336, 12);
            this.returnBookBtn.Name = "returnBookBtn";
            this.returnBookBtn.Size = new System.Drawing.Size(97, 52);
            this.returnBookBtn.TabIndex = 1;
            this.returnBookBtn.Text = "归还";
            this.returnBookBtn.UseVisualStyleBackColor = true;
            this.returnBookBtn.Click += new System.EventHandler(this.returnBookBtnClick);
            // 
            // signOutBtn
            // 
            this.signOutBtn.Location = new System.Drawing.Point(689, 12);
            this.signOutBtn.Name = "signOutBtn";
            this.signOutBtn.Size = new System.Drawing.Size(99, 48);
            this.signOutBtn.TabIndex = 4;
            this.signOutBtn.Text = "退出登录";
            this.signOutBtn.UseVisualStyleBackColor = true;
            this.signOutBtn.Click += new System.EventHandler(this.SignOutBtnClick);
            // 
            // StudentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.signOutBtn);
            this.Controls.Add(this.returnBookBtn);
            this.Controls.Add(this.booksView1);
            this.Name = "StudentPage";
            this.Text = "图书管理系统";
            this.Load += new System.EventHandler(this.PageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.booksView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView booksView1;
        private System.Windows.Forms.Button returnBookBtn;
        private System.Windows.Forms.Button signOutBtn;
    }
}