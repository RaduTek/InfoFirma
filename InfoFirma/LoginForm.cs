using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InfoFirma {
    public partial class LoginForm : Form {
        public LoginForm() {
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] result;
            //result = this.bazaDateDataSet.Tables["Utilizatori"].Select("Nume = '" + utilizator.Text + "' AND Parola = '" + parola.Text + "'");
            result = this.bazaDateDataSet.Tables["Utilizatori"].Select();

            if (result.Length >= 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("User sau parolă greșite! Încercați din nou!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
