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
            mainPanel = new Panel();
            projectsBox = new ComboBox();
            compBox = new NumericUpDown();
            colBox = new NumericUpDown();
            rowBox = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            dbBox = new NumericUpDown();
            button2 = new Button();
            warehouseBox = new DataGridView();
            partBox = new ComboBox();
            addPartButton = new Button();
            panel1 = new Panel();
            label3 = new Label();
            button1 = new Button();
            maxdbBox = new NumericUpDown();
            label2 = new Label();
            priceBox = new NumericUpDown();
            priceLabel = new Label();
            partIdLabel = new Label();
            partNameLabel = new Label();
            label4 = new Label();
            filterBox = new ComboBox();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)compBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)colBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rowBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dbBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warehouseBox).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maxdbBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(projectsBox);
            mainPanel.Controls.Add(compBox);
            mainPanel.Controls.Add(colBox);
            mainPanel.Controls.Add(rowBox);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(dbBox);
            mainPanel.Controls.Add(button2);
            mainPanel.Controls.Add(warehouseBox);
            mainPanel.Controls.Add(partBox);
            mainPanel.Controls.Add(addPartButton);
            mainPanel.Controls.Add(panel1);
            mainPanel.Controls.Add(filterBox);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 1;
            mainPanel.ControlAdded += DisableBackground;
            mainPanel.ControlRemoved += EnableBackground;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // projectsBox
            // 
            projectsBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            projectsBox.BackColor = Color.White;
            projectsBox.Enabled = false;
            projectsBox.Font = new Font("Segoe UI", 11F);
            projectsBox.FormattingEnabled = true;
            projectsBox.Items.AddRange(new object[] { "Raktár", "Lefoglalt", "Hiányzó" });
            projectsBox.Location = new Point(238, 58);
            projectsBox.Name = "projectsBox";
            projectsBox.Size = new Size(166, 28);
            projectsBox.TabIndex = 18;
            projectsBox.SelectedValueChanged += projectsBox_SelectedValueChanged;
            // 
            // compBox
            // 
            compBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            compBox.Font = new Font("Segoe UI", 11F);
            compBox.Location = new Point(106, 350);
            compBox.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            compBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            compBox.Name = "compBox";
            compBox.ReadOnly = true;
            compBox.Size = new Size(35, 27);
            compBox.TabIndex = 17;
            compBox.TabStop = false;
            compBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // colBox
            // 
            colBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            colBox.Font = new Font("Segoe UI", 11F);
            colBox.Location = new Point(65, 350);
            colBox.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            colBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            colBox.Name = "colBox";
            colBox.ReadOnly = true;
            colBox.Size = new Size(35, 27);
            colBox.TabIndex = 16;
            colBox.TabStop = false;
            colBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rowBox
            // 
            rowBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            rowBox.Font = new Font("Segoe UI", 11F);
            rowBox.Location = new Point(24, 350);
            rowBox.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            rowBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            rowBox.Name = "rowBox";
            rowBox.ReadOnly = true;
            rowBox.Size = new Size(35, 27);
            rowBox.TabIndex = 15;
            rowBox.TabStop = false;
            rowBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Calibri", 11F);
            label6.Location = new Point(319, 328);
            label6.Name = "label6";
            label6.Size = new Size(25, 18);
            label6.TabIndex = 14;
            label6.Text = "Db";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Calibri", 11F);
            label5.Location = new Point(147, 328);
            label5.Name = "label5";
            label5.Size = new Size(65, 18);
            label5.TabIndex = 13;
            label5.Text = "Alkatrész";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11F);
            label1.Location = new Point(24, 329);
            label1.Name = "label1";
            label1.Size = new Size(51, 18);
            label1.TabIndex = 10;
            label1.Text = "Pozíció";
            // 
            // dbBox
            // 
            dbBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dbBox.Font = new Font("Segoe UI", 11F);
            dbBox.Location = new Point(319, 350);
            dbBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            dbBox.Name = "dbBox";
            dbBox.Size = new Size(59, 27);
            dbBox.TabIndex = 11;
            dbBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = Color.DodgerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Calibri", 11F);
            button2.Location = new Point(384, 348);
            button2.Name = "button2";
            button2.Size = new Size(76, 29);
            button2.TabIndex = 10;
            button2.Text = "Elhelyez";
            button2.UseVisualStyleBackColor = false;
            button2.Click += PlacePart;
            // 
            // warehouseBox
            // 
            warehouseBox.AllowUserToAddRows = false;
            warehouseBox.AllowUserToDeleteRows = false;
            warehouseBox.AllowUserToResizeColumns = false;
            warehouseBox.AllowUserToResizeRows = false;
            warehouseBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            warehouseBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            warehouseBox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            warehouseBox.BackgroundColor = Color.White;
            warehouseBox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warehouseBox.Location = new Point(24, 92);
            warehouseBox.Name = "warehouseBox";
            warehouseBox.ReadOnly = true;
            warehouseBox.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            warehouseBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            warehouseBox.Size = new Size(494, 233);
            warehouseBox.TabIndex = 6;
            // 
            // partBox
            // 
            partBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            partBox.Font = new Font("Segoe UI", 11F);
            partBox.FormattingEnabled = true;
            partBox.Location = new Point(147, 349);
            partBox.Name = "partBox";
            partBox.Size = new Size(166, 28);
            partBox.TabIndex = 5;
            partBox.SelectedValueChanged += SelectPart;
            // 
            // addPartButton
            // 
            addPartButton.BackColor = Color.DodgerBlue;
            addPartButton.FlatStyle = FlatStyle.Flat;
            addPartButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            addPartButton.ForeColor = Color.Black;
            addPartButton.Location = new Point(24, 51);
            addPartButton.Name = "addPartButton";
            addPartButton.Size = new Size(35, 35);
            addPartButton.TabIndex = 4;
            addPartButton.Text = "+";
            addPartButton.UseVisualStyleBackColor = false;
            addPartButton.Click += ShowAddPartDialog;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(maxdbBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(priceBox);
            panel1.Controls.Add(priceLabel);
            panel1.Controls.Add(partIdLabel);
            panel1.Controls.Add(partNameLabel);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(582, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(218, 450);
            panel1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F);
            label3.Location = new Point(127, 99);
            label3.Name = "label3";
            label3.Size = new Size(21, 20);
            label3.TabIndex = 7;
            label3.Text = "Ft";
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 11F);
            button1.Location = new Point(15, 191);
            button1.Name = "button1";
            button1.Size = new Size(79, 27);
            button1.TabIndex = 6;
            button1.Text = "Mentés";
            button1.UseVisualStyleBackColor = false;
            button1.Click += UpdatePart;
            // 
            // maxdbBox
            // 
            maxdbBox.Font = new Font("Segoe UI", 11.25F);
            maxdbBox.Location = new Point(15, 148);
            maxdbBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            maxdbBox.Name = "maxdbBox";
            maxdbBox.Size = new Size(59, 27);
            maxdbBox.TabIndex = 5;
            maxdbBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(15, 127);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "Max. /Rekesz";
            // 
            // priceBox
            // 
            priceBox.Font = new Font("Segoe UI", 11.25F);
            priceBox.Location = new Point(15, 97);
            priceBox.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            priceBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(111, 27);
            priceBox.TabIndex = 3;
            priceBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Segoe UI", 11.25F);
            priceLabel.Location = new Point(15, 76);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(24, 20);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Ár";
            // 
            // partIdLabel
            // 
            partIdLabel.AutoSize = true;
            partIdLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            partIdLabel.Location = new Point(15, 44);
            partIdLabel.Name = "partIdLabel";
            partIdLabel.Size = new Size(92, 21);
            partIdLabel.TabIndex = 1;
            partIdLabel.Text = "Alkatrész ID";
            // 
            // partNameLabel
            // 
            partNameLabel.AutoSize = true;
            partNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            partNameLabel.Location = new Point(15, 19);
            partNameLabel.Name = "partNameLabel";
            partNameLabel.Size = new Size(143, 25);
            partNameLabel.TabIndex = 0;
            partNameLabel.Text = "Alaktrész Neve";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F);
            label4.Location = new Point(80, 153);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 9;
            label4.Text = "db";
            // 
            // filterBox
            // 
            filterBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filterBox.BackColor = Color.White;
            filterBox.Font = new Font("Segoe UI", 11F);
            filterBox.FormattingEnabled = true;
            filterBox.Items.AddRange(new object[] { "Raktár", "Lefoglalt", "Hiányzó" });
            filterBox.Location = new Point(419, 58);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(99, 28);
            filterBox.TabIndex = 2;
            filterBox.SelectedIndexChanged += filterBox_SelectedIndexChanged;
            // 
            // RaktarvezetoMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainPanel);
            Name = "RaktarvezetoMain";
            Size = new Size(800, 450);
            Load += RaktarvezetoMain_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)compBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)colBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)rowBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dbBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)warehouseBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maxdbBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel mainPanel;
        private Panel panel1;
        private Label partIdLabel;
        private Label partNameLabel;
        private ComboBox filterBox;
        private NumericUpDown maxdbBox;
        private Label label2;
        private NumericUpDown priceBox;
        private Label priceLabel;
        private Button button1;
        private Label label3;
        private Label label4;
        private Button addPartButton;
        private DataGridView warehouseBox;
        private ComboBox partBox;
        private NumericUpDown dbBox;
        private Button button2;
        private Label label5;
        private Label label1;
        private Label label6;
        private NumericUpDown compBox;
        private NumericUpDown colBox;
        private NumericUpDown rowBox;
        private ComboBox projectsBox;
    }
}
