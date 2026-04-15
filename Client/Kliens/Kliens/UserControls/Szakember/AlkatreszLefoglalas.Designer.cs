namespace Kliens.UserControls.Szakember
{
    partial class AlkatreszLefoglalas
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
            dbBox = new NumericUpDown();
            cancelButton = new Button();
            saveButton = new Button();
            avaLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            removepartButton = new Button();
            addpartButton = new Button();
            projektpartsBox = new ListBox();
            partsBox = new ListBox();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(dbBox);
            mainPanel.Controls.Add(cancelButton);
            mainPanel.Controls.Add(saveButton);
            mainPanel.Controls.Add(avaLabel);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(label2);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(removepartButton);
            mainPanel.Controls.Add(addpartButton);
            mainPanel.Controls.Add(projektpartsBox);
            mainPanel.Controls.Add(partsBox);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(552, 300);
            mainPanel.TabIndex = 0;
            // 
            // dbBox
            // 
            dbBox.Location = new Point(253, 103);
            dbBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            dbBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            dbBox.Name = "dbBox";
            dbBox.Size = new Size(50, 23);
            dbBox.TabIndex = 35;
            dbBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(116, 255);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 32);
            cancelButton.TabIndex = 34;
            cancelButton.Text = "Mégse";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(11, 255);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 32);
            saveButton.TabIndex = 33;
            saveButton.Text = "Mentés";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // avaLabel
            // 
            avaLabel.AutoSize = true;
            avaLabel.Location = new Point(251, 131);
            avaLabel.Name = "avaLabel";
            avaLabel.Size = new Size(50, 15);
            avaLabel.TabIndex = 15;
            avaLabel.Text = "Elérhető";
            avaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 29);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 14;
            label3.Text = "Raktár";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 29);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 13;
            label2.Text = "Projekt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(218, 25);
            label1.TabIndex = 12;
            label1.Text = "Alkatrészek Lefoglalása";
            // 
            // removepartButton
            // 
            removepartButton.BackColor = Color.DodgerBlue;
            removepartButton.FlatStyle = FlatStyle.Flat;
            removepartButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            removepartButton.Location = new Point(258, 168);
            removepartButton.Name = "removepartButton";
            removepartButton.Size = new Size(35, 35);
            removepartButton.TabIndex = 11;
            removepartButton.Text = "<";
            removepartButton.UseVisualStyleBackColor = false;
            removepartButton.Click += MovePartBack;
            // 
            // addpartButton
            // 
            addpartButton.BackColor = Color.DodgerBlue;
            addpartButton.FlatStyle = FlatStyle.Flat;
            addpartButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            addpartButton.Location = new Point(258, 65);
            addpartButton.Name = "addpartButton";
            addpartButton.Size = new Size(35, 35);
            addpartButton.TabIndex = 10;
            addpartButton.Text = ">";
            addpartButton.UseVisualStyleBackColor = false;
            addpartButton.Click += MovePart;
            // 
            // projektpartsBox
            // 
            projektpartsBox.FormattingEnabled = true;
            projektpartsBox.ItemHeight = 15;
            projektpartsBox.Location = new Point(333, 47);
            projektpartsBox.Name = "projektpartsBox";
            projektpartsBox.Size = new Size(207, 184);
            projektpartsBox.TabIndex = 9;
            // 
            // partsBox
            // 
            partsBox.FormattingEnabled = true;
            partsBox.ItemHeight = 15;
            partsBox.Location = new Point(12, 47);
            partsBox.Name = "partsBox";
            partsBox.Size = new Size(207, 184);
            partsBox.TabIndex = 8;
            partsBox.SelectedIndexChanged += GetPartAvaiablity;
            // 
            // AlkatreszLefoglalas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(552, 300);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlkatreszLefoglalas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alkatrészek lefoglalása";
            Load += AlkatreszLefoglalas_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dbBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Label avaLabel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button removepartButton;
        private Button addpartButton;
        private ListBox projektpartsBox;
        private ListBox partsBox;
        private Button cancelButton;
        private Button saveButton;
        private NumericUpDown dbBox;
    }
}