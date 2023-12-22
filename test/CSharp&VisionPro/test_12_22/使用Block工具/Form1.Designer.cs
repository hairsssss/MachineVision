namespace 使用Block工具 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exposureIpt = new System.Windows.Forms.TextBox();
            this.floatBtn = new System.Windows.Forms.Button();
            this.openBlockBtn = new System.Windows.Forms.Button();
            this.detectionBtn = new System.Windows.Forms.Button();
            this.readImageBtn = new System.Windows.Forms.Button();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.exposureBtn = new System.Windows.Forms.Button();
            this.takePhotoBtn = new System.Windows.Forms.Button();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.exposureIpt);
            this.groupBox1.Controls.Add(this.floatBtn);
            this.groupBox1.Controls.Add(this.openBlockBtn);
            this.groupBox1.Controls.Add(this.detectionBtn);
            this.groupBox1.Controls.Add(this.readImageBtn);
            this.groupBox1.Controls.Add(this.saveImageBtn);
            this.groupBox1.Controls.Add(this.exposureBtn);
            this.groupBox1.Controls.Add(this.takePhotoBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // exposureIpt
            // 
            this.exposureIpt.Location = new System.Drawing.Point(134, 90);
            this.exposureIpt.Name = "exposureIpt";
            this.exposureIpt.Size = new System.Drawing.Size(108, 25);
            this.exposureIpt.TabIndex = 7;
            // 
            // floatBtn
            // 
            this.floatBtn.Location = new System.Drawing.Point(23, 358);
            this.floatBtn.Name = "floatBtn";
            this.floatBtn.Size = new System.Drawing.Size(97, 35);
            this.floatBtn.TabIndex = 6;
            this.floatBtn.Text = "浮动显示";
            this.floatBtn.UseVisualStyleBackColor = true;
            this.floatBtn.Click += new System.EventHandler(this.floatBtn_Click);
            // 
            // openBlockBtn
            // 
            this.openBlockBtn.Location = new System.Drawing.Point(23, 301);
            this.openBlockBtn.Name = "openBlockBtn";
            this.openBlockBtn.Size = new System.Drawing.Size(97, 35);
            this.openBlockBtn.TabIndex = 5;
            this.openBlockBtn.Text = "打开TB";
            this.openBlockBtn.UseVisualStyleBackColor = true;
            this.openBlockBtn.Click += new System.EventHandler(this.openBlockBtn_Click);
            // 
            // detectionBtn
            // 
            this.detectionBtn.Location = new System.Drawing.Point(23, 249);
            this.detectionBtn.Name = "detectionBtn";
            this.detectionBtn.Size = new System.Drawing.Size(97, 35);
            this.detectionBtn.TabIndex = 4;
            this.detectionBtn.Text = "检测";
            this.detectionBtn.UseVisualStyleBackColor = true;
            this.detectionBtn.Click += new System.EventHandler(this.detectionBtn_Click);
            // 
            // readImageBtn
            // 
            this.readImageBtn.Location = new System.Drawing.Point(23, 190);
            this.readImageBtn.Name = "readImageBtn";
            this.readImageBtn.Size = new System.Drawing.Size(97, 35);
            this.readImageBtn.TabIndex = 3;
            this.readImageBtn.Text = "读取图片";
            this.readImageBtn.UseVisualStyleBackColor = true;
            this.readImageBtn.Click += new System.EventHandler(this.readImageBtn_Click);
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Location = new System.Drawing.Point(23, 136);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(97, 35);
            this.saveImageBtn.TabIndex = 2;
            this.saveImageBtn.Text = "保存图片";
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // exposureBtn
            // 
            this.exposureBtn.Location = new System.Drawing.Point(23, 84);
            this.exposureBtn.Name = "exposureBtn";
            this.exposureBtn.Size = new System.Drawing.Size(97, 35);
            this.exposureBtn.TabIndex = 1;
            this.exposureBtn.Text = "设置曝光";
            this.exposureBtn.UseVisualStyleBackColor = true;
            this.exposureBtn.Click += new System.EventHandler(this.exposureBtn_Click);
            // 
            // takePhotoBtn
            // 
            this.takePhotoBtn.Location = new System.Drawing.Point(23, 33);
            this.takePhotoBtn.Name = "takePhotoBtn";
            this.takePhotoBtn.Size = new System.Drawing.Size(97, 35);
            this.takePhotoBtn.TabIndex = 0;
            this.takePhotoBtn.Text = "拍照";
            this.takePhotoBtn.UseVisualStyleBackColor = true;
            this.takePhotoBtn.Click += new System.EventHandler(this.takePhotoBtn_Click);
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
            this.cogRecordDisplay1.Location = new System.Drawing.Point(295, 37);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(710, 505);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 558);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.PageLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button floatBtn;
        private System.Windows.Forms.Button openBlockBtn;
        private System.Windows.Forms.Button detectionBtn;
        private System.Windows.Forms.Button readImageBtn;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.Button exposureBtn;
        private System.Windows.Forms.Button takePhotoBtn;
        private System.Windows.Forms.TextBox exposureIpt;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
    }
}

