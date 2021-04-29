using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InfoFirma {
    public partial class TemplateForm : Form {
        public TemplateForm() {
            InitializeComponent();
            mainToolStrip.Renderer = new MyFormStyles.ToolStripRenderer();
        }

        private void mainToolStrip_MouseDown(object sender, MouseEventArgs e) {
            MyFormStyles.DragForm(this.Handle);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x84) {
                m.Result = (IntPtr)0x1;
                return;
            }
            base.WndProc(ref m);
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
