using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace InfoFirma {
    public static class MyFormStyles {
        // Clasa aceasta defineste diferite optiuni pentru stil
        // Este definita ca statica pentru ca aceasta va fi accesata direct fara a crea o instanta noua

        public class ToolStripRenderer : ToolStripProfessionalRenderer {
            // Un ToolStripRenderer particularizat spre a dezactiva bordurile rotunjite ale ToolStrip-ului
            // Deasemenea selecteaza ToolStripColors, o clasa ce defineste culorile meniului
            public ToolStripRenderer() : base(new ToolStripColors()) {
                this.RoundedEdges = false;
            }
        }

        public class ToolStripColors : ProfessionalColorTable {
            // Clasa aceasta defineste culorile meniului, sunt alese spre a se asorta cu TabControl-ul prezent deasemenea "in" ToolStrip
            // Culorile sunt definite ca proprietati, care au functiile get si set
            // Acestea sunt read-only, avand doar get si ele inlocuiesc proprietatile ce existau in clasa originala prin override

            // Background color
            public override Color ToolStripGradientBegin { get { return Color.White; } }
            public override Color ToolStripGradientMiddle { get { return Color.White; } }
            public override Color ToolStripGradientEnd { get { return Color.White; } }

            public override Color MenuStripGradientBegin { get { return Color.White; } }
            public override Color MenuStripGradientEnd { get { return Color.White; } }

            public override Color StatusStripGradientBegin { get { return Color.FromArgb(240, 240, 240); } }
            public override Color StatusStripGradientEnd { get { return Color.FromArgb(240, 240, 240); } }

            // Toolstrip border
            public override Color ToolStripBorder { get { return Color.FromArgb(217, 217, 217); } }

            // Item border
            public override Color ButtonSelectedBorder { get { return Color.FromArgb(217, 217, 217); } }
            public override Color MenuItemBorder { get { return Color.FromArgb(217, 217, 217); } }

            // Hover back color
            public override Color ButtonSelectedGradientBegin { get { return Color.FromArgb(216, 234, 249); } }
            public override Color ButtonSelectedGradientMiddle { get { return Color.FromArgb(216, 234, 249); } }
            public override Color ButtonSelectedGradientEnd { get { return Color.FromArgb(216, 234, 249); } }
            public override Color MenuItemSelected { get { return Color.FromArgb(216, 234, 249); } }
            public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(216, 234, 249); } }
            public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(216, 234, 249); } }

            // Pressed back color
            public override Color ButtonPressedGradientBegin { get { return Color.FromArgb(216, 234, 249); } }
            public override Color ButtonPressedGradientMiddle { get { return Color.FromArgb(216, 234, 249); } }
            public override Color ButtonPressedGradientEnd { get { return Color.FromArgb(216, 234, 249); } }
            public override Color MenuItemPressedGradientBegin { get { return Color.White; } }
            public override Color MenuItemPressedGradientMiddle { get { return Color.White; } }
            public override Color MenuItemPressedGradientEnd { get { return Color.White; } }

        }

        // Importa DLLuri necesare spre a muta fereastra
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void DragForm(IntPtr handle) {
            // Trimite comanda la Windows facandu-l sa creada ca are loc un click & drag pe bara de sus a programului
            // Fiindca programul nostru nu are acea bara vizibila, trebuie adaugat separat aceasta optiune
            // Aceasta optiune ne permite sa beneficiem de functiile Aero Snap si Aero Shake
            ReleaseCapture();
            SendMessage(handle, 0xA1, 0x2, 0);
        }

        /*
         * Functia aceasta intercepteaza mesajele transmise de fereastra spre a dezactiva posibilitatea de a redimensiona fereastra
         * Este folosita fiindca fereastrele au marginea setata la sizable pentru a avea marginea stilizata si cu umbre, similar cu fereastra de retele wireless din Windows 7
         * aceasta inlocuieste mesajul ce transmite pozitia cursorului pe marginea redimensionabila cu cel ce reprezinta pozitia cursorului in zona "client" adica zona ce o controleaza fereastra noastra, continutul ferestrei
        protected override void WndProc(ref Message m) {
            if(m.Msg == 0x84) {
                m.Result = (IntPtr)0x1;
                return;
            }
            base.WndProc(ref m);
        }
        */
    }
}
