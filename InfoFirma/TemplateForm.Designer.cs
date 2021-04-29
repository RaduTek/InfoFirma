
namespace InfoFirma {
    partial class TemplateForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.nameLabel = new System.Windows.Forms.ToolStripLabel();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.White;
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameLabel,
            this.closeButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainToolStrip.Size = new System.Drawing.Size(384, 25);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainToolStrip_MouseDown);
            // 
            // nameLabel
            // 
            this.nameLabel.Image = global::InfoFirma.Properties.Resources.icon_16;
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(99, 22);
            this.nameLabel.Text = "TemplateForm";
            // 
            // closeButton
            // 
            this.closeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeButton.Image = global::InfoFirma.Properties.Resources.close;
            this.closeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(23, 22);
            this.closeButton.Text = "Închidere";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 284);
            this.ControlBox = false;
            this.Controls.Add(this.mainToolStrip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripLabel nameLabel;
        private System.Windows.Forms.ToolStripButton closeButton;
    }
}