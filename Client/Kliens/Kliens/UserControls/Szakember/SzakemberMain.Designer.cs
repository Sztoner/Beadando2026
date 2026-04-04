namespace Kliens.UserControls.Szakember
{
    partial class SzakemberMain
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
            loadProjectButton = new Button();
            label1 = new Label();
            addProjectButton = new Button();
            projectsGridView = new DataGridView();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)projectsGridView).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(loadProjectButton);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(addProjectButton);
            mainPanel.Controls.Add(projectsGridView);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 0;
            // 
            // loadProjectButton
            // 
            loadProjectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadProjectButton.BackColor = Color.DodgerBlue;
            loadProjectButton.FlatStyle = FlatStyle.Flat;
            loadProjectButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            loadProjectButton.ForeColor = Color.Black;
            loadProjectButton.Location = new Point(671, 367);
            loadProjectButton.Name = "loadProjectButton";
            loadProjectButton.Size = new Size(72, 35);
            loadProjectButton.TabIndex = 8;
            loadProjectButton.Text = "Betöltés";
            loadProjectButton.UseVisualStyleBackColor = false;
            loadProjectButton.Click += LoadProject;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(41, 56);
            label1.Name = "label1";
            label1.Size = new Size(107, 30);
            label1.TabIndex = 7;
            label1.Text = "Projektek";
            // 
            // addProjectButton
            // 
            addProjectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addProjectButton.BackColor = Color.DodgerBlue;
            addProjectButton.FlatStyle = FlatStyle.Flat;
            addProjectButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            addProjectButton.ForeColor = Color.Black;
            addProjectButton.Location = new Point(41, 367);
            addProjectButton.Name = "addProjectButton";
            addProjectButton.Size = new Size(35, 35);
            addProjectButton.TabIndex = 6;
            addProjectButton.Text = "+";
            addProjectButton.UseVisualStyleBackColor = false;
            addProjectButton.Click += AddProject;
            // 
            // projectsGridView
            // 
            projectsGridView.AllowUserToAddRows = false;
            projectsGridView.AllowUserToDeleteRows = false;
            projectsGridView.AllowUserToResizeColumns = false;
            projectsGridView.AllowUserToResizeRows = false;
            projectsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            projectsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            projectsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            projectsGridView.BackgroundColor = Color.White;
            projectsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectsGridView.Location = new Point(41, 89);
            projectsGridView.Name = "projectsGridView";
            projectsGridView.ReadOnly = true;
            projectsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            projectsGridView.Size = new Size(702, 272);
            projectsGridView.TabIndex = 0;
            // 
            // SzakemberMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainPanel);
            Name = "SzakemberMain";
            Size = new Size(800, 450);
            Load += SzakemberMain_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)projectsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private DataGridView projectsGridView;
        private Label label1;
        private Button addProjectButton;
        private Button loadProjectButton;
    }
}
