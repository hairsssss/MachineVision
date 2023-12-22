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

namespace 使用Block工具 {
    public partial class ToolBlock : Form {
        CogToolBlock mTb = null;

        public ToolBlock(CogToolBlock toolBlock) {
            InitializeComponent();
            mTb = toolBlock;
            //设置cogToolBlockEditV21绑定的是哪个block工具 
            cogToolBlockEditV21.Subject = mTb;
        }

        private void submitBtn_Click(object sender, EventArgs e) {

            //blockvpp 路径
            string path = Directory.GetCurrentDirectory() + "\\Vpp\\ToolBlock.vpp";
            //序列化blcok对象到本地
            CogSerializer.SaveObjectToFile(mTb, path);
        }
    }
}
