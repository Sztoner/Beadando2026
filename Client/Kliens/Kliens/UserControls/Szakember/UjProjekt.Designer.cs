namespace Kliens.UserControls.Szakember
{
    partial class UjProjekt
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
            mainPanel = new Panel();
            descriptionBox = new RichTextBox();
            label4 = new Label();
            locationBox = new TextBox();
            clientBox = new TextBox();
            cancelButton = new Button();
            saveButton = new Button();
            label5 = new Label();
            label3 = new Label();
            nameBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(descriptionBox);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(locationBox);
            mainPanel.Controls.Add(clientBox);
            mainPanel.Controls.Add(cancelButton);
            mainPanel.Controls.Add(saveButton);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(nameBox);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(label1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(494, 261);
            mainPanel.TabIndex = 0;
            // 
            // descriptionBox
            // 
            descriptionBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            descriptionBox.BorderStyle = BorderStyle.FixedSingle;
            descriptionBox.Location = new Point(129, 145);
            descriptionBox.Name = "descriptionBox";
            descriptionBox.Size = new Size(236, 61);
            descriptionBox.TabIndex = 31;
            descriptionBox.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(69, 145);
            label4.Name = "label4";
            label4.Size = new Size(54, 21);
            label4.TabIndex = 35;
            label4.Text = "Leírás:";
            // 
            // locationBox
            // 
            locationBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            locationBox.Font = new Font("Segoe UI", 10F);
            locationBox.Location = new Point(146, 108);
            locationBox.Name = "locationBox";
            locationBox.Size = new Size(219, 25);
            locationBox.TabIndex = 30;
            // 
            // clientBox
            // 
            clientBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clientBox.Font = new Font("Segoe UI", 10F);
            clientBox.Location = new Point(172, 72);
            clientBox.Name = "clientBox";
            clientBox.Size = new Size(193, 25);
            clientBox.TabIndex = 29;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(115, 219);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 32);
            cancelButton.TabIndex = 38;
            cancelButton.Text = "Mégse";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(10, 219);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 32);
            saveButton.TabIndex = 37;
            saveButton.Text = "Mentés";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += CreateProject;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(69, 108);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 30;
            label5.Text = "Helyszín:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(69, 72);
            label3.Name = "label3";
            label3.Size = new Size(97, 21);
            label3.TabIndex = 29;
            label3.Text = "Megrendelö:";
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameBox.Font = new Font("Segoe UI", 10F);
            nameBox.Location = new Point(116, 37);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(249, 25);
            nameBox.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(69, 37);
            label2.Name = "label2";
            label2.Size = new Size(41, 21);
            label2.TabIndex = 27;
            label2.Text = "Név:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(232, 30);
            label1.TabIndex = 26;
            label1.Text = "Új Projekt Hozzáadása";
            // 
            // UjProjekt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(494, 261);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(510, 300);
            MinimizeBox = false;
            MinimumSize = new Size(510, 300);
            Name = "UjProjekt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Új Projekt Létrehozása Varázsló";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private RichTextBox descriptionBox;
        private Label label4;
        private TextBox locationBox;
        private TextBox clientBox;
        private Button cancelButton;
        private Button saveButton;
        private Label label5;
        private Label label3;
        private TextBox nameBox;
        private Label label2;
        private Label label1;
    }
}