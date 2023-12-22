using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;

namespace Test2
{
    public partial class FrmTB : Form
    {
        CogToolBlock mTb = null;
        public FrmTB(CogToolBlock tb)
        {
            InitializeComponent();
            mTb = tb;
        }

        private void FrmTB_Load(object sender, EventArgs e)
        {
            //设置cogToolBlockEditV21绑定的是哪个block工具 
            cogToolBlockEditV21.Subject = mTb;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {  

            //blockvpp 路径
            string path = Directory.GetCurrentDirectory() + "\\Vpp\\TB1.vpp";
            //序列化blcok对象到本地
            CogSerializer.SaveObjectToFile(mTb, path);
        }
    }
}
