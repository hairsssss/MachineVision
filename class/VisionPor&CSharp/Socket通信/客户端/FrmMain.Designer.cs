
namespace 客户端
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Send = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.richTextBox_Send = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Receive = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Send
            // 
            this.button_Send.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Send.Location = new System.Drawing.Point(46, 352);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(95, 35);
            this.button_Send.TabIndex = 13;
            this.button_Send.Text = "发送数据";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Connect.Location = new System.Drawing.Point(46, 269);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(95, 35);
            this.button_Connect.TabIndex = 15;
            this.button_Connect.Text = "连接服务器";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // richTextBox_Send
            // 
            this.richTextBox_Send.Location = new System.Drawing.Point(373, 392);
            this.richTextBox_Send.Name = "richTextBox_Send";
            this.richTextBox_Send.Size = new System.Drawing.Size(440, 200);
            this.richTextBox_Send.TabIndex = 12;
            this.richTextBox_Send.Text = "";
            // 
            // richTextBox_Receive
            // 
            this.richTextBox_Receive.Location = new System.Drawing.Point(373, 64);
            this.richTextBox_Receive.Name = "richTextBox_Receive";
            this.richTextBox_Receive.Size = new System.Drawing.Size(440, 305);
            this.richTextBox_Receive.TabIndex = 11;
            this.richTextBox_Receive.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "接收区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "发送区";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 656);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.richTextBox_Send);
            this.Controls.Add(this.richTextBox_Receive);
            this.Name = "FrmMain";
            this.Text = "TCPClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.RichTextBox richTextBox_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Receive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

