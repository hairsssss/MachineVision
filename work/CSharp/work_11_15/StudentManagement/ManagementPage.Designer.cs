using System.Windows.Forms;
using System;

namespace StudentManagement {
    partial class ManagementPage {
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
            this.AddBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.AgeLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.NameIpt = new System.Windows.Forms.TextBox();
            this.AgeIpt = new System.Windows.Forms.TextBox();
            this.HeightIpt = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.RemoveIpt = new System.Windows.Forms.TextBox();
            this.SortByAgeBtn = new System.Windows.Forms.Button();
            this.SortByHeightBtn = new System.Windows.Forms.Button();
            this.DefaultSortBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(168, 12);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(119, 85);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "添加";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddStudentClick);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Location = new System.Drawing.Point(769, 12);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(119, 85);
            this.RemoveBtn.TabIndex = 1;
            this.RemoveBtn.Text = "删除";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveStudentClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(154, 323);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(779, 284);
            this.dataGridView1.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(181, 139);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(37, 15);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "姓名";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(181, 188);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(37, 15);
            this.GenderLabel.TabIndex = 4;
            this.GenderLabel.Text = "性别";
            // 
            // AgeLabel
            // 
            this.AgeLabel.AutoSize = true;
            this.AgeLabel.Location = new System.Drawing.Point(546, 142);
            this.AgeLabel.Name = "AgeLabel";
            this.AgeLabel.Size = new System.Drawing.Size(37, 15);
            this.AgeLabel.TabIndex = 5;
            this.AgeLabel.Text = "年龄";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(546, 191);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(37, 15);
            this.HeightLabel.TabIndex = 6;
            this.HeightLabel.Text = "身高";
            // 
            // NameIpt
            // 
            this.NameIpt.Location = new System.Drawing.Point(252, 129);
            this.NameIpt.Name = "NameIpt";
            this.NameIpt.Size = new System.Drawing.Size(271, 25);
            this.NameIpt.TabIndex = 7;
            // 
            // AgeIpt
            // 
            this.AgeIpt.Location = new System.Drawing.Point(617, 129);
            this.AgeIpt.Name = "AgeIpt";
            this.AgeIpt.Size = new System.Drawing.Size(271, 25);
            this.AgeIpt.TabIndex = 9;
            this.AgeIpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // HeightIpt
            // 
            this.HeightIpt.Location = new System.Drawing.Point(617, 178);
            this.HeightIpt.Name = "HeightIpt";
            this.HeightIpt.Size = new System.Drawing.Size(271, 25);
            this.HeightIpt.TabIndex = 10;
            this.HeightIpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(252, 184);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 19);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "男";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(348, 184);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 19);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "女";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RemoveIpt
            // 
            this.RemoveIpt.Location = new System.Drawing.Point(483, 59);
            this.RemoveIpt.Multiline = true;
            this.RemoveIpt.Name = "RemoveIpt";
            this.RemoveIpt.Size = new System.Drawing.Size(118, 38);
            this.RemoveIpt.TabIndex = 16;
            this.RemoveIpt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // SortByAgeBtn
            // 
            this.SortByAgeBtn.Location = new System.Drawing.Point(333, 245);
            this.SortByAgeBtn.Name = "SortByAgeBtn";
            this.SortByAgeBtn.Size = new System.Drawing.Size(100, 44);
            this.SortByAgeBtn.TabIndex = 17;
            this.SortByAgeBtn.Text = "按年龄排序";
            this.SortByAgeBtn.UseVisualStyleBackColor = true;
            this.SortByAgeBtn.Click += new System.EventHandler(this.SortByAge);
            // 
            // SortByHeightBtn
            // 
            this.SortByHeightBtn.Location = new System.Drawing.Point(483, 245);
            this.SortByHeightBtn.Name = "SortByHeightBtn";
            this.SortByHeightBtn.Size = new System.Drawing.Size(100, 44);
            this.SortByHeightBtn.TabIndex = 18;
            this.SortByHeightBtn.Text = "按身高排序";
            this.SortByHeightBtn.UseVisualStyleBackColor = true;
            this.SortByHeightBtn.Click += new System.EventHandler(this.SortByHeight);
            // 
            // DefaultSortBtn
            // 
            this.DefaultSortBtn.Location = new System.Drawing.Point(631, 245);
            this.DefaultSortBtn.Name = "DefaultSortBtn";
            this.DefaultSortBtn.Size = new System.Drawing.Size(105, 44);
            this.DefaultSortBtn.TabIndex = 19;
            this.DefaultSortBtn.Text = "默认排序";
            this.DefaultSortBtn.UseVisualStyleBackColor = true;
            this.DefaultSortBtn.Click += new System.EventHandler(this.DefaultSortClick);
            // 
            // ManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1085, 727);
            this.Controls.Add(this.DefaultSortBtn);
            this.Controls.Add(this.SortByHeightBtn);
            this.Controls.Add(this.SortByAgeBtn);
            this.Controls.Add(this.RemoveIpt);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.HeightIpt);
            this.Controls.Add(this.AgeIpt);
            this.Controls.Add(this.NameIpt);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.AgeLabel);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.AddBtn);
            this.Name = "ManagementPage";
            this.Text = "ManagementPage";
            this.Load += new System.EventHandler(this.smsPageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button RemoveBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Label AgeLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox NameIpt;
        private System.Windows.Forms.TextBox AgeIpt;
        private System.Windows.Forms.TextBox HeightIpt;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private TextBox RemoveIpt;
        private Button SortByAgeBtn;
        private Button SortByHeightBtn;
        private Button DefaultSortBtn;
    }
}