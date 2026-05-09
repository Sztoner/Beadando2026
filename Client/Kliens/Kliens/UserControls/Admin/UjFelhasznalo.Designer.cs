namespace Kliens.UserControls.Admin
{
    partial class UjFelhasznalo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            emailBox = new TextBox();
            cancelButton = new Button();
            saveButton = new Button();
            label5 = new Label();
            label3 = new Label();
            nameBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pwBox = new TextBox();
            rolesBox = new ComboBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(109, 151);
            label4.Name = "label4";
            label4.Size = new Size(54, 21);
            label4.TabIndex = 47;
            label4.Text = "Jelszó:";
            // 
            // emailBox
            // 
            emailBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            emailBox.Font = new Font("Segoe UI", 10F);
            emailBox.Location = new Point(173, 87);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(193, 25);
            emailBox.TabIndex = 42;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(117, 217);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 32);
            cancelButton.TabIndex = 49;
            cancelButton.Text = "Mégse";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CloseForm;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(12, 217);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 32);
            saveButton.TabIndex = 48;
            saveButton.Text = "Mentés";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += CreateUser;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(109, 118);
            label5.Name = "label5";
            label5.Size = new Size(83, 21);
            label5.TabIndex = 45;
            label5.Text = "Szerepkör:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(109, 91);
            label3.Name = "label3";
            label3.Size = new Size(51, 21);
            label3.TabIndex = 43;
            label3.Text = "Email:";
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameBox.Font = new Font("Segoe UI", 10F);
            nameBox.Location = new Point(173, 56);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(193, 25);
            nameBox.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(48, 56);
            label2.Name = "label2";
            label2.Size = new Size(119, 21);
            label2.TabIndex = 40;
            label2.Text = "Felhasználónév:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(-3, -1);
            label1.Name = "label1";
            label1.Size = new Size(275, 30);
            label1.TabIndex = 39;
            label1.Text = "Új Felhasználó Hozzáadása";
            // 
            // pwBox
            // 
            pwBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pwBox.Font = new Font("Segoe UI", 10F);
            pwBox.Location = new Point(173, 151);
            pwBox.Name = "pwBox";
            pwBox.Size = new Size(193, 25);
            pwBox.TabIndex = 44;
            // 
            // rolesBox
            // 
            rolesBox.Font = new Font("Segoe UI", 10F);
            rolesBox.FormattingEnabled = true;
            rolesBox.Items.AddRange(new object[] { "Admin", "Raktarvezeto", "Raktaros", "Szakember" });
            rolesBox.Location = new Point(198, 120);
            rolesBox.Name = "rolesBox";
            rolesBox.Size = new Size(168, 25);
            rolesBox.TabIndex = 43;
            // 
            // UjFelhasznalo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(494, 261);
            Controls.Add(rolesBox);
            Controls.Add(pwBox);
            Controls.Add(label4);
            Controls.Add(emailBox);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(nameBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(510, 300);
            MinimizeBox = false;
            MinimumSize = new Size(510, 300);
            Name = "UjFelhasznalo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Új Felhasználó Létrehozása Varázsló";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private TextBox emailBox;
        private Button cancelButton;
        private Button saveButton;
        private Label label5;
        private Label label3;
        private TextBox nameBox;
        private Label label2;
        private Label label1;
        private TextBox pwBox;
        private ComboBox rolesBox;
    }
}