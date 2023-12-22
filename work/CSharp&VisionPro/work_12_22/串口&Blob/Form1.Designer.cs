namespace 串口_Blob {
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
            this.cogBlobEditV21 = new Cognex.VisionPro.Blob.CogBlobEditV2();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.takePhotoBtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.submitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // cogBlobEditV21
            // 
            this.cogBlobEditV21.Location = new System.Drawing.Point(26, 294);
            this.cogBlobEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogBlobEditV21.Name = "cogBlobEditV21";
            this.cogBlobEditV21.Size = new System.Drawing.Size(1178, 453);
            this.cogBlobEditV21.SuspendElectricRuns = false;
            this.cogBlobEditV21.TabIndex = 0;
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
            this.cogRecordDisplay1.Location = new System.Drawing.Point(26, 12);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(601, 228);
            this.cogRecordDisplay1.TabIndex = 1;
            // 
            // takePhotoBtn
            // 
            this.takePhotoBtn.Font = new System.Drawing.Font("宋体", 16F);
            this.takePhotoBtn.Location = new System.Drawing.Point(852, 12);
            this.takePhotoBtn.Name = "takePhotoBtn";
            this.takePhotoBtn.Size = new System.Drawing.Size(175, 90);
            this.takePhotoBtn.TabIndex = 2;
            this.takePhotoBtn.Text = "拍照";
            this.takePhotoBtn.UseVisualStyleBackColor = true;
            this.takePhotoBtn.Click += new System.EventHandler(this.takePhotoBtn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("宋体", 16F);
            this.submitBtn.Location = new System.Drawing.Point(852, 143);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(175, 90);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "提交";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 804);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.takePhotoBtn);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.cogBlobEditV21);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.PageLoad);
            ((System.ComponentModel.ISupportInitialize)(this.cogBlobEditV21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Blob.CogBlobEditV2 cogBlobEditV21;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.Button takePhotoBtn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button submitBtn;
    }
}

