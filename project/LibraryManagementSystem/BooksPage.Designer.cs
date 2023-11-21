﻿namespace LibraryManagementSystem {
    partial class BooksPage {
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
            this.booksView = new System.Windows.Forms.DataGridView();
            this.borrowBtn = new System.Windows.Forms.Button();
            this.bookshelfBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).BeginInit();
            this.SuspendLayout();
            // 
            // booksView
            // 
            this.booksView.AllowUserToOrderColumns = true;
            this.booksView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksView.Location = new System.Drawing.Point(76, 66);
            this.booksView.Name = "booksView";
            this.booksView.RowHeadersWidth = 51;
            this.booksView.RowTemplate.Height = 27;
            this.booksView.Size = new System.Drawing.Size(627, 311);
            this.booksView.TabIndex = 0;
            // 
            // borrowBtn
            // 
            this.borrowBtn.Location = new System.Drawing.Point(199, 12);
            this.borrowBtn.Name = "borrowBtn";
            this.borrowBtn.Size = new System.Drawing.Size(99, 48);
            this.borrowBtn.TabIndex = 1;
            this.borrowBtn.Text = "借阅";
            this.borrowBtn.UseVisualStyleBackColor = true;
            this.borrowBtn.Click += new System.EventHandler(this.borrowBtnClick);
            // 
            // bookshelfBtn
            // 
            this.bookshelfBtn.Location = new System.Drawing.Point(453, 12);
            this.bookshelfBtn.Name = "bookshelfBtn";
            this.bookshelfBtn.Size = new System.Drawing.Size(99, 48);
            this.bookshelfBtn.TabIndex = 2;
            this.bookshelfBtn.Text = "书架";
            this.bookshelfBtn.UseVisualStyleBackColor = true;
            this.bookshelfBtn.Click += new System.EventHandler(this.bookshelfBtnClick);
            // 
            // BooksPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bookshelfBtn);
            this.Controls.Add(this.borrowBtn);
            this.Controls.Add(this.booksView);
            this.Name = "BooksPage";
            this.Text = "BooksPage";
            this.Load += new System.EventHandler(this.PageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.booksView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView booksView;
        private System.Windows.Forms.Button borrowBtn;
        private System.Windows.Forms.Button bookshelfBtn;
    }
}