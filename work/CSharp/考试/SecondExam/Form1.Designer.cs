namespace SecondExam {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mouseBtn = new System.Windows.Forms.Button();
            this.catBtn = new System.Windows.Forms.Button();
            this.peopleBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mouseBtn
            // 
            this.mouseBtn.Location = new System.Drawing.Point(156, 95);
            this.mouseBtn.Name = "mouseBtn";
            this.mouseBtn.Size = new System.Drawing.Size(94, 57);
            this.mouseBtn.TabIndex = 0;
            this.mouseBtn.Text = "老鼠";
            this.mouseBtn.UseVisualStyleBackColor = true;
            this.mouseBtn.Click += new System.EventHandler(this.MouseBtn_click);
            // 
            // catBtn
            // 
            this.catBtn.Location = new System.Drawing.Point(320, 95);
            this.catBtn.Name = "catBtn";
            this.catBtn.Size = new System.Drawing.Size(94, 57);
            this.catBtn.TabIndex = 1;
            this.catBtn.Text = "猫咪";
            this.catBtn.UseVisualStyleBackColor = true;
            // 
            // peopleBtn
            // 
            this.peopleBtn.Location = new System.Drawing.Point(497, 95);
            this.peopleBtn.Name = "peopleBtn";
            this.peopleBtn.Size = new System.Drawing.Size(94, 57);
            this.peopleBtn.TabIndex = 2;
            this.peopleBtn.Text = "人";
            this.peopleBtn.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.MouseVoice);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.Location = new System.Drawing.Point(156, 186);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 53);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(70, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "解说：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.peopleBtn);
            this.Controls.Add(this.catBtn);
            this.Controls.Add(this.mouseBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PageLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button mouseBtn;
        private System.Windows.Forms.Button catBtn;
        private System.Windows.Forms.Button peopleBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}

