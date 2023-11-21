using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work_11_16 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void FormLoad(object sender, EventArgs e) {
            allPanels = GetAllPanels(this);
            foreach (var panel in allPanels) {
                panel.Click += Panel_Click;
            }
            ChangeColorPanle();
        }
        private List<Panel> allPanels = new List<Panel>();
        private void ChangeColorPanle() {
            for (int i = 0; i < allPanels.Count; i++) {
                if (i % 2 == 1) {
                    this.Invoke((MethodInvoker)delegate {
                        allPanels[i].BackColor = Color.Teal;
                    });
                }
            }
        }
        private List<Panel> GetAllPanels(Control container) {
            List<Panel> panels = new List<Panel>();

            var panelsInContainer = container.Controls.OfType<Panel>().OrderBy(ctrl => ctrl.TabIndex).ToList();
            panels.AddRange(panelsInContainer);

            foreach (Control ctrl in container.Controls) {
                panels.AddRange(GetAllPanels(ctrl));
            }

            return panels;
        }


        private void Panel_Click(object sender, EventArgs e) {
            foreach (var panel in allPanels) {
                panel.BackColor = Color.Gray;
            }

            Panel clickedPanel = (Panel)sender;
            clickedPanel.BackColor = Color.Teal;
        }

    }
}
