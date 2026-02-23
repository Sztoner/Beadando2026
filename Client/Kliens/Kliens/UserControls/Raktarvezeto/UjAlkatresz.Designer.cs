namespace Kliens.UserControls.Raktarvezeto
{
    partial class UjAlkatresz
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(251, 30);
            label1.TabIndex = 0;
            label1.Text = "Új Alkatrész Hozzáadása";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(23, 65);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 1;
            label2.Text = "Alaktrész Neve:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(145, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 25);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(23, 112);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 3;
            label3.Text = "Alaktrész Ára:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 10F);
            numericUpDown1.Location = new Point(145, 112);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.RightToLeft = RightToLeft.Yes;
            numericUpDown1.Size = new Size(196, 25);
            numericUpDown1.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label4.Location = new Point(342, 113);
            label4.Name = "label4";
            label4.Size = new Size(23, 21);
            label4.TabIndex = 5;
            label4.Text = "Ft";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 10F);
            numericUpDown2.Location = new Point(145, 161);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.RightToLeft = RightToLeft.Yes;
            numericUpDown2.Size = new Size(106, 25);
            numericUpDown2.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label5.Location = new Point(23, 161);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 6;
            label5.Text = "Max. /rekesz:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label6.Location = new Point(252, 163);
            label6.Name = "label6";
            label6.Size = new Size(28, 21);
            label6.TabIndex = 8;
            label6.Text = "db";
            // 
            // saveButton
            // 
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Location = new Point(23, 239);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(99, 32);
            saveButton.TabIndex = 9;
            saveButton.Text = "Mentés";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Location = new Point(128, 239);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(99, 32);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Mégse";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel;
            // 
            // UjAlkatresz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(label6);
            Controls.Add(numericUpDown2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UjAlkatresz";
            Size = new Size(508, 298);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private Label label5;
        private Label label6;
        private Button saveButton;
        private Button cancelButton;
    }
}
