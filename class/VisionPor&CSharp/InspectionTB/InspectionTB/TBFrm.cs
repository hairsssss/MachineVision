using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.VPManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace InspectionTB
{
    public partial class TBFrm : Form
    {
        public TBFrm(CogToolBlock cogToolBlock)
        {
            InitializeComponent();
            cogToolBlockEditV21.Subject = cogToolBlock;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VPManage.SaveBlockVpp(cogToolBlockEditV21.Subject, Directory.GetCurrentDirectory() + "\\TBBlob.vpp");
        }
    }
}
