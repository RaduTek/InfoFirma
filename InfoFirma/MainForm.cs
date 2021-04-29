using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InfoFirma {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            mainToolStrip.Renderer = new MyFormStyles.ToolStripRenderer();
            mainStatusStrip.Renderer = new MyFormStyles.ToolStripRenderer();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            #region "Incarcare tabele date"
            this.utilizatoriTableAdapter.Fill(this.bazaDateDataSet.Utilizatori);
            this.departamenteTableAdapter.Fill(this.bazaDateDataSet.Departamente);
            this.clientiTableAdapter.Fill(this.bazaDateDataSet.Clienti);
            this.proiecteTableAdapter.Fill(this.bazaDateDataSet.Proiecte);
            this.angajatiTableAdapter.Fill(this.bazaDateDataSet.Angajati);
            #endregion

        }

        #region "Bara ferestrei"
        // Miscarea ferestrei
        private void mainToolStrip_MouseDown(object sender, MouseEventArgs e) {
            // Apeleaza functia DragForm din clasa statica MyFormStyles
            MyFormStyles.DragForm(this.Handle);
        }

        // Butoane bara
        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void restoreButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Normal;
        }

        private void maximizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        // Setare buton maximizare/restaurare
        private void MainForm_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Maximized) {
                restoreButton.Visible = true;
                maximizeButton.Visible = false;
            } else {
                restoreButton.Visible = false;
                maximizeButton.Visible = true;
            }
        }
        #endregion

        #region "Meniuri si taburi"
        private void despreInfoFirmaToolStripMenuItem_Click(object sender, EventArgs e) {
            // Creaza o noua instanta a ferestrei AboutForm si o afiseaza pentru meniul Despre
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void salvareDateToolStripMenuItem_Click(object sender, EventArgs e) {
            // Apeleaza functia de salvare date cand optiunea de salvare din meniu a fost selectata
            statusLabel.Text = "Salvarea datelor în curs...";
            SalvareDate();
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            // Selectarea tabelului la apasarea tab-ului
            // Prima oara ascunde toate control-urile din mainTabPanel
            foreach (Control c in mainTabPanel.Controls) c.Visible = false;
            // Apoi afiseaza doar control-ul cu acelasi index ca si tab-ul
            mainTabPanel.Controls[mainTabControl.SelectedIndex].Visible = true;
            // Aceasta procedura se bazeaza pe ordinea in care acestea se afla, dar fiindca tot timpul va fi aceeasi nu este o problema
        }
        #endregion

        #region "Salvare date"
        private void SalvareDate() {
            // Salveaza datele in baza de date
            try {
                // Da refresh fiecarui tabel
                angajatiDataGridView.Update();
                proiecteDataGridView.Update();
                clientiDataGridView.Update();
                departamenteDataGridView.Update();
                utilizatoriDataGridView.Update();

                // Actualizeaza datele stocate in baza de date prin TableAdapter
                this.angajatiTableAdapter.Update(this.bazaDateDataSet.Angajati);
                this.proiecteTableAdapter.Update(this.bazaDateDataSet.Proiecte);
                this.clientiTableAdapter.Update(this.bazaDateDataSet.Clienti);
                this.departamenteTableAdapter.Update(this.bazaDateDataSet.Departamente);
                this.utilizatoriTableAdapter.Update(this.bazaDateDataSet.Utilizatori);

                // Afisare mesaj de stare
                statusLabel.Text = "Datele au fost salvate cu succes!";
            } catch {
                statusLabel.Text = "Eroare la salvarea datelor!";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Salveaza datele automat la iesire din program
            statusLabel.Text = "Salvare automată a datelor în curs...";
            SalvareDate();
        }

        private void autoSaveTimer_Tick(object sender, EventArgs e) {
            // Salveaza datele automat din minut in minut, interval setat de autoSaveTimer.Interval
            statusLabel.Text = "Salvare automată a datelor în curs...";
            SalvareDate();
        }
        #endregion

        #region "Selector data pentru tabel"
        DateTimePicker oDatePicker = null; // Obiectul DateTimePicker pt selectarea datei
        DataGridView cDataGridView = null; // Referinta la tabelul curent in care se foloseste oDatePicker

        private void CreareDatePicker(object sender, DataGridViewCellEventArgs e) {
            // Crearea control-ului DateTimePicker si inserarea acestuia in celula din tabel
            // Datorita parametrilor, se selecteaza ca eveniment al tabelelor ce contin coloane al caror nume incepe cu "Data"

            // Obtine tabelul selectat curent prin parametrul sender transmis de eveniment
            cDataGridView = (DataGridView)sender;

            try {
                if (cDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Data")) {
                    // Creaza o noua instanta a control-ului DateTimePicker
                    oDatePicker = new DateTimePicker();
                    // Adauga la colectia de controale a tabeluli selectat curent
                    cDataGridView.Controls.Add(oDatePicker);
                    // Seteaza formatul datei si preia data din tabel
                    oDatePicker.Format = DateTimePickerFormat.Short;
                    oDatePicker.Text = cDataGridView.CurrentCell.Value.ToString();
                    // Seteaza pozitia control-ului si dimensiunea lui
                    Rectangle oRectangle = cDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    oDatePicker.Size = new Size(oRectangle.Width + 1, oRectangle.Height - 1);
                    oDatePicker.Location = new Point(oRectangle.X - 1, oRectangle.Y - 1);
                    // Atribuie evenimentele control-ului
                    oDatePicker.CloseUp += new EventHandler(oDatePicker_CloseUp);
                    oDatePicker.TextChanged += new EventHandler(oDatePicker_OnTextChange);
                    // In final afiseaza control-ul
                    oDatePicker.Visible = true;
                }
            } catch {
            }
        }

        private void EliminareDatePicker(object sender, EventArgs e) {
            // Elimina control-ul DateTimePicker cand alta celula a fost selectata din tabel
            // Foloseste dispose pentru eliminarea acestuia corecta din tabel si din memorie
            // Datorita parametrilor, se selecteaza ca eveniment al tabelelor ce contin coloane al caror nume incepe cu "Data"
            if (oDatePicker != null) oDatePicker.Dispose();
        }

        private void oDatePicker_CloseUp(object sender, EventArgs e) {
            // Ascunde control-ul DateTimePicker cand acesta a fost inchis
            oDatePicker.Visible = false;
        }

        private void oDatePicker_OnTextChange(object sender, EventArgs e) {
            // Schimba text-ul celulei selectate din tabelul curent
            cDataGridView.CurrentCell.Value = oDatePicker.Text.ToString();
        }
        #endregion

        private void MainForm_Shown(object sender, EventArgs e) {
            Autentificare();
        }

        private void Autentificare()
        {
            mainTabPanel.Visible = false;
            mainTabControl.Visible = false;
            statusLabel.Text = "Nu sunteți autentificat";
            LoginForm lf = new LoginForm();
            DialogResult result = lf.ShowDialog();
            if (result == DialogResult.OK)
            {
                mainTabPanel.Visible = true;
                mainTabControl.Visible = true;
                statusLabel.Text = "Sunteți autentificat";
            }
        }

        private void delogareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autentificare();
        }
    }
}
