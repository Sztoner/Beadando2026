namespace Kliens.UserControls
{
    partial class RaktarvezetoMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            nézetToolStripMenuItem = new ToolStripMenuItem();
            alToolStripMenuItem = new ToolStripMenuItem();
            MainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { nézetToolStripMenuItem, alToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // nézetToolStripMenuItem
            // 
            nézetToolStripMenuItem.Name = "nézetToolStripMenuItem";
            nézetToolStripMenuItem.Size = new Size(66, 20);
            nézetToolStripMenuItem.Text = "Alkatrész";
            // 
            // alToolStripMenuItem
            // 
            alToolStripMenuItem.Name = "alToolStripMenuItem";
            alToolStripMenuItem.Size = new Size(56, 20);
            alToolStripMenuItem.Text = "Projekt";
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 24);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(800, 426);
            MainPanel.TabIndex = 1;
            // 
            // RaktarvezetoMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(MainPanel);
            Controls.Add(menuStrip1);
            Name = "RaktarvezetoMain";
            Size = new Size(800, 450);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem nézetToolStripMenuItem;
        private ToolStripMenuItem alToolStripMenuItem;
        private Panel MainPanel;
    }
}
