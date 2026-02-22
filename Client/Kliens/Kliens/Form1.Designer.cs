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
            codeBox = new TextBox();
            loginButton = new Button();
            label3 = new Label();
            label2 = new Label();
            pwBox = new TextBox();
            label1 = new Label();
            nameBox = new TextBox();
            welcomeLabel = new Label();
            linkLabel1 = new LinkLabel();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(codeBox);
            mainPanel.Controls.Add(loginButton);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(pwBox);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(nameBox);
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Controls.Add(linkLabel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 0;
            // 
            // codeBox
            // 
            codeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            codeBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            codeBox.Location = new Point(271, 303);
            codeBox.Margin = new Padding(4, 3, 4, 3);
            codeBox.Name = "codeBox";
            codeBox.PasswordChar = '*';
            codeBox.Size = new Size(116, 31);
            codeBox.TabIndex = 29;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top;
            loginButton.BackColor = Color.DodgerBlue;
            loginButton.FlatStyle = FlatStyle.Popup;
            loginButton.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            loginButton.Location = new Point(330, 349);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(128, 42);
            loginButton.TabIndex = 28;
            loginButton.Text = "Bejelentkezés";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += Login;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(271, 282);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 18);
            label3.TabIndex = 26;
            label3.Text = "Biztonsági Kód";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(271, 228);
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
            pwBox.Location = new Point(271, 249);
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
            label1.Location = new Point(271, 173);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(33, 18);
            label1.TabIndex = 23;
            label1.Text = "Név";
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nameBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            nameBox.Location = new Point(271, 194);
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
            welcomeLabel.Size = new Size(800, 157);
            welcomeLabel.TabIndex = 21;
            welcomeLabel.Text = "Üdvözöljük.";
            welcomeLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(385, 319);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(40, 15);
            linkLabel1.TabIndex = 27;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Mi ez?";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Megrendelés Karbantartó";
            Load += Form1_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private TextBox codeBox;
        private Button loginButton;
        private Label label3;
        private Label label2;
        private TextBox pwBox;
        private Label label1;
        private TextBox nameBox;
        private Label welcomeLabel;
        private LinkLabel linkLabel1;
    }
}
