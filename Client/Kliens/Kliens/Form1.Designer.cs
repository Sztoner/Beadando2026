namespace Kliens
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            loginButton = new Button();
            label2 = new Label();
            pwBox = new TextBox();
            label1 = new Label();
            nameBox = new TextBox();
            welcomeLabel = new Label();
            topMenu = new MenuStrip();
            welcomeToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            mainPanel.SuspendLayout();
            topMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(loginButton);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(pwBox);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(nameBox);
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 24);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 426);
            mainPanel.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top;
            loginButton.BackColor = Color.DodgerBlue;
            loginButton.FlatStyle = FlatStyle.Popup;
            loginButton.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            loginButton.Location = new Point(325, 290);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(128, 42);
            loginButton.TabIndex = 28;
            loginButton.Text = "Bejelentkezés";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += Login;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(271, 217);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 18);
            label2.TabIndex = 25;
            label2.Text = "Jelszó";
            // 
            // pwBox
            // 
            pwBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pwBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            pwBox.Location = new Point(271, 238);
            pwBox.Margin = new Padding(4, 3, 4, 3);
            pwBox.Name = "pwBox";
            pwBox.PasswordChar = '*';
            pwBox.Size = new Size(243, 31);
            pwBox.TabIndex = 24;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(271, 162);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 18);
            label1.TabIndex = 23;
            label1.Text = "Felhasználónév";
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nameBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            nameBox.Location = new Point(271, 183);
            nameBox.Margin = new Padding(4, 3, 4, 3);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(243, 31);
            nameBox.TabIndex = 22;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.Font = new Font("Calibri", 42F);
            welcomeLabel.Location = new Point(0, 0);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(800, 146);
            welcomeLabel.TabIndex = 21;
            welcomeLabel.Text = "Üdvözöljük.";
            welcomeLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // topMenu
            // 
            topMenu.BackColor = Color.White;
            topMenu.Items.AddRange(new ToolStripItem[] { welcomeToolStripMenuItem });
            topMenu.Location = new Point(0, 0);
            topMenu.Name = "topMenu";
            topMenu.Size = new Size(800, 24);
            topMenu.TabIndex = 1;
            // 
            // welcomeToolStripMenuItem
            // 
            welcomeToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            welcomeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem });
            welcomeToolStripMenuItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 238);
            welcomeToolStripMenuItem.Name = "welcomeToolStripMenuItem";
            welcomeToolStripMenuItem.Size = new Size(46, 21);
            welcomeToolStripMenuItem.Text = "Üdv,";
            welcomeToolStripMenuItem.Visible = false;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.BackColor = Color.White;
            logoutToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(142, 22);
            logoutToolStripMenuItem.Text = "Kijelentkezés";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Controls.Add(topMenu);
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(816, 489);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Megrendelés Karbantartó";
            Load += Form1_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            topMenu.ResumeLayout(false);
            topMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private Button loginButton;
        private Label label2;
        private TextBox pwBox;
        private Label label1;
        private TextBox nameBox;
        private Label welcomeLabel;
        private MenuStrip topMenu;
        private ToolStripMenuItem welcomeToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
    }
}
