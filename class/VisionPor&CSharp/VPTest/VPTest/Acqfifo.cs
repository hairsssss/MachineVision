using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
namespace VPTest
{
    public partial class Acqfifo : Form
    {
        private CogAcqFifoTool _tempAcq;
        public Acqfifo(CogAcqFifoTool acq)
        {
            InitializeComponent();

            _tempAcq = acq;
            //关联当前acq设置页面的父工具 
            cogAcqFifoEditV21.Subject = _tempAcq;
        }

        //保存当前acq设计页面的信息
        private void button1_Click(object sender, EventArgs e)
        {
            CarmaManager.SaveVpp(_tempAcq);
        }
    }
}
