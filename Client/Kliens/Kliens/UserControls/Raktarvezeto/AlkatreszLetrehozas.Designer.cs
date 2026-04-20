namespace Kliens.UserControls.Raktarvezeto
{
    partial class AlkatreszLetrehozas
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
            cancelButton = new Button();
            saveButton = new Button();
            label6 = new Label();
            rekeszdbBox = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            priceBox = new NumericUpDown();
            label3 = new Label();
            nameBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)rekeszdbBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(117, 220);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 32);
            cancelButton.TabIndex = 21;
            cancelButton.Text = "Mégse";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel;
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(12, 220);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 32);
            saveButton.TabIndex = 20;
            saveButton.Text = "Mentés";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += AddPart;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(269, 154);
            label6.Name = "label6";
            label6.Size = new Size(28, 21);
            label6.TabIndex = 19;
            label6.Text = "db";
            // 
            // rekeszdbBox
            // 
            rekeszdbBox.Font = new Font("Segoe UI", 10F);
            rekeszdbBox.Location = new Point(157, 154);
            rekeszdbBox.Name = "rekeszdbBox";
            rekeszdbBox.RightToLeft = RightToLeft.Yes;
            rekeszdbBox.Size = new Size(106, 25);
            rekeszdbBox.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(12, 155);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 17;
            label5.Text = "Max. /rekesz:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(359, 109);
            label4.Name = "label4";
            label4.Size = new Size(23, 21);
            label4.TabIndex = 16;
            label4.Text = "Ft";
            // 
            // priceBox
            // 
            priceBox.Font = new Font("Segoe UI", 10F);
            priceBox.Location = new Point(157, 109);
            priceBox.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            priceBox.Name = "priceBox";
            priceBox.RightToLeft = RightToLeft.Yes;
            priceBox.Size = new Size(196, 25);
            priceBox.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 14;
            label3.Text = "Alaktrész Ára:";
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Segoe UI", 10F);
            nameBox.Location = new Point(157, 60);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(221, 25);
            nameBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 12;
            label2.Text = "Alaktrész Neve:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(251, 30);
            label1.TabIndex = 11;
            label1.Text = "Új Alkatrész Hozzáadása";
            // 
            // AlkatreszLetrehozas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(494, 261);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label6);
            Controls.Add(rekeszdbBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(priceBox);
            Controls.Add(label3);
            Controls.Add(nameBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(510, 300);
            MinimumSize = new Size(510, 300);
            Name = "AlkatreszLetrehozas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Alkatrész Létrehozás Varázsló";
            ((System.ComponentModel.ISupportInitialize)rekeszdbBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button saveButton;
        private Label label6;
        private NumericUpDown rekeszdbBox;
        private Label label5;
        private Label label4;
        private NumericUpDown priceBox;
        private Label label3;
        private TextBox nameBox;
        private Label label2;
        private Label label1;
    }
}