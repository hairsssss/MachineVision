
namespace TBRan事件
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMean = new System.Windows.Forms.Label();
            this.btnSaveRawImage = new System.Windows.Forms.Button();
            this.btnSaveDealImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(12, 12);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(969, 717);
            this.cogRecordDisplay1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(1003, 257);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(488, 472);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(1034, 53);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(75, 23);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "加载图片";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1044, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "最大值：";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(1103, 119);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(11, 12);
            this.lblMax.TabIndex = 3;
            this.lblMax.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1044, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "最小值：";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(1103, 141);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(11, 12);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1044, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "平均值：";
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(1103, 164);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(11, 12);
            this.lblMean.TabIndex = 3;
            this.lblMean.Text = "0";
            // 
            // btnSaveRawImage
            // 
            this.btnSaveRawImage.Location = new System.Drawing.Point(1140, 53);
            this.btnSaveRawImage.Name = "btnSaveRawImage";
            this.btnSaveRawImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRawImage.TabIndex = 4;
            this.btnSaveRawImage.Text = "保存原图";
            this.btnSaveRawImage.UseVisualStyleBackColor = true;
            this.btnSaveRawImage.Click += new System.EventHandler(this.btnSaveRawImage_Click);
            // 
            // btnSaveDealImage
            // 
            this.btnSaveDealImage.Location = new System.Drawing.Point(1236, 53);
            this.btnSaveDealImage.Name = "btnSaveDealImage";
            this.btnSaveDealImage.Size = new System.Drawing.Size(110, 23);
            this.btnSaveDealImage.TabIndex = 4;
            this.btnSaveDealImage.Text = "保存处理后的图片";
            this.btnSaveDealImage.UseVisualStyleBackColor = true;
            this.btnSaveDealImage.Click += new System.EventHandler(this.btnSaveDealImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1173, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 741);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveDealImage);
            this.Controls.Add(this.btnSaveRawImage);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Name = "FrmMain";
            this.Text = "加载图片测试";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMean;
        private System.Windows.Forms.Button btnSaveRawImage;
        private System.Windows.Forms.Button btnSaveDealImage;
        private System.Windows.Forms.Label label3;
    }
}

