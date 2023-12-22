namespace FrameGrabber连接相机 {
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
            this.takePhotoBtn = new System.Windows.Forms.Button();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.readImage = new System.Windows.Forms.Button();
            this.exposureBtn = new System.Windows.Forms.Button();
            this.exposureIpt = new System.Windows.Forms.TextBox();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // takePhotoBtn
            // 
            this.takePhotoBtn.Location = new System.Drawing.Point(839, 117);
            this.takePhotoBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takePhotoBtn.Name = "takePhotoBtn";
            this.takePhotoBtn.Size = new System.Drawing.Size(169, 62);
            this.takePhotoBtn.TabIndex = 2;
            this.takePhotoBtn.Text = "拍照";
            this.takePhotoBtn.UseVisualStyleBackColor = true;
            this.takePhotoBtn.Click += new System.EventHandler(this.TakePhotoBtn_click);
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Location = new System.Drawing.Point(752, 215);
            this.saveImageBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(169, 62);
            this.saveImageBtn.TabIndex = 3;
            this.saveImageBtn.Text = "保存图像";
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.SaveImageBtn_click);
            // 
            // readImage
            // 
            this.readImage.Location = new System.Drawing.Point(930, 215);
            this.readImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readImage.Name = "readImage";
            this.readImage.Size = new System.Drawing.Size(169, 62);
            this.readImage.TabIndex = 4;
            this.readImage.Text = "读取图像";
            this.readImage.UseVisualStyleBackColor = true;
            this.readImage.Click += new System.EventHandler(this.ReadImage_click);
            // 
            // exposureBtn
            // 
            this.exposureBtn.Location = new System.Drawing.Point(752, 324);
            this.exposureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exposureBtn.Name = "exposureBtn";
            this.exposureBtn.Size = new System.Drawing.Size(169, 62);
            this.exposureBtn.TabIndex = 5;
            this.exposureBtn.Text = "曝光设置";
            this.exposureBtn.UseVisualStyleBackColor = true;
            this.exposureBtn.Click += new System.EventHandler(this.ExposureBtn_click);
            // 
            // exposureIpt
            // 
            this.exposureIpt.Location = new System.Drawing.Point(930, 324);
            this.exposureIpt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exposureIpt.Multiline = true;
            this.exposureIpt.Name = "exposureIpt";
            this.exposureIpt.Size = new System.Drawing.Size(167, 62);
            this.exposureIpt.TabIndex = 6;
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
            this.cogRecordDisplay1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(533, 530);
            this.cogRecordDisplay1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 692);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.exposureIpt);
            this.Controls.Add(this.exposureBtn);
            this.Controls.Add(this.readImage);
            this.Controls.Add(this.saveImageBtn);
            this.Controls.Add(this.takePhotoBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PageClosing);
            this.Load += new System.EventHandler(this.PageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button takePhotoBtn;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.Button readImage;
        private System.Windows.Forms.Button exposureBtn;
        private System.Windows.Forms.TextBox exposureIpt;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
    }
}

