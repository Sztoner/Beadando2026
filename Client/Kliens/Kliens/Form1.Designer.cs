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
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
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
            mainPanel.Controls.Add(loginButton);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(textBox2);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(textBox1);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(nameBox);
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Controls.Add(linkLabel1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top;
            loginButton.BackColor = Color.DodgerBlue;
            loginButton.FlatStyle = FlatStyle.Popup;
            loginButton.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            loginButton.Location = new Point(333, 339);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(128, 42);
            loginButton.TabIndex = 11;
            loginButton.Text = "Bejelentkezés";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += Login;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(274, 272);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 18);
            label3.TabIndex = 9;
            label3.Text = "Biztonsági Kód";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBox2.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox2.Location = new Point(274, 293);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 31);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(274, 218);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(45, 18);
            label2.TabIndex = 7;
            label2.Text = "Jelszó";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBox1.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textBox1.Location = new Point(274, 239);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(243, 31);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(274, 163);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(33, 18);
            label1.TabIndex = 5;
            label1.Text = "Név";
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            nameBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            nameBox.Location = new Point(274, 184);
            nameBox.Margin = new Padding(4, 3, 4, 3);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(243, 31);
            nameBox.TabIndex = 2;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Dock = DockStyle.Top;
            welcomeLabel.Font = new Font("Calibri", 42F);
            welcomeLabel.Location = new Point(0, 0);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(800, 157);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Üdvözöljük.";
            welcomeLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(388, 309);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(40, 15);
            linkLabel1.TabIndex = 10;
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
        private TextBox nameBox;
        private Label welcomeLabel;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button loginButton;
        private LinkLabel linkLabel1;
    }
}
