namespace Kliens.UserControls.Raktaros
{
    partial class RaktarosMain
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
            projectsBox = new ComboBox();
            warehouseBox = new DataGridView();
            partIdLabel = new Label();
            executeProjectButton = new Button();
            updateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)warehouseBox).BeginInit();
            SuspendLayout();
            // 
            // projectsBox
            // 
            projectsBox.BackColor = Color.White;
            projectsBox.Enabled = false;
            projectsBox.Font = new Font("Segoe UI", 11F);
            projectsBox.FormattingEnabled = true;
            projectsBox.Items.AddRange(new object[] { "Raktár", "Lefoglalt", "Hiányzó" });
            projectsBox.Location = new Point(84, 62);
            projectsBox.Name = "projectsBox";
            projectsBox.Size = new Size(270, 28);
            projectsBox.TabIndex = 19;
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
            warehouseBox.Location = new Point(20, 95);
            warehouseBox.Name = "warehouseBox";
            warehouseBox.ReadOnly = true;
            warehouseBox.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            warehouseBox.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            warehouseBox.Size = new Size(494, 233);
            warehouseBox.TabIndex = 20;
            // 
            // partIdLabel
            // 
            partIdLabel.AutoSize = true;
            partIdLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            partIdLabel.Location = new Point(20, 37);
            partIdLabel.Name = "partIdLabel";
            partIdLabel.Size = new Size(151, 21);
            partIdLabel.TabIndex = 21;
            partIdLabel.Text = "Scheduled Projektek";
            // 
            // executeProjectButton
            // 
            executeProjectButton.BackColor = Color.DodgerBlue;
            executeProjectButton.FlatStyle = FlatStyle.Flat;
            executeProjectButton.Font = new Font("Calibri", 11F);
            executeProjectButton.Location = new Point(360, 62);
            executeProjectButton.Name = "executeProjectButton";
            executeProjectButton.Size = new Size(76, 29);
            executeProjectButton.TabIndex = 22;
            executeProjectButton.Text = "Kivitelez";
            executeProjectButton.UseVisualStyleBackColor = false;
            executeProjectButton.Click += ExecuteProject;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.White;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Calibri", 11F);
            updateButton.Location = new Point(20, 61);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(58, 29);
            updateButton.TabIndex = 23;
            updateButton.Text = "Frissít";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            // 
            // RaktarosMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(updateButton);
            Controls.Add(executeProjectButton);
            Controls.Add(partIdLabel);
            Controls.Add(warehouseBox);
            Controls.Add(projectsBox);
            Name = "RaktarosMain";
            Size = new Size(800, 450);
            Load += RaktarosMain_Load;
            ((System.ComponentModel.ISupportInitialize)warehouseBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox projectsBox;
        private DataGridView warehouseBox;
        private Label partIdLabel;
        private Button executeProjectButton;
        private Button updateButton;
    }
}
