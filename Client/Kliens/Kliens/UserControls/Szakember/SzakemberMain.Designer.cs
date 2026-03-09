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
            projectGridView = new DataGridView();
            addProjectButton = new Button();
            projectInfoPanel = new Panel();
            partPanel = new Panel();
            label1 = new Label();
            projectStatusLabel = new Label();
            contractorLabel = new Label();
            projectDescLabel = new Label();
            projectIDLabel = new Label();
            projectNameLabel = new Label();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)projectGridView).BeginInit();
            projectInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(projectGridView);
            mainPanel.Controls.Add(addProjectButton);
            mainPanel.Controls.Add(projectInfoPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 2;
            // 
            // projectGridView
            // 
            projectGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectGridView.Location = new Point(24, 83);
            projectGridView.Name = "projectGridView";
            projectGridView.Size = new Size(360, 297);
            projectGridView.TabIndex = 5;
            // 
            // addProjectButton
            // 
            addProjectButton.BackColor = Color.DodgerBlue;
            addProjectButton.FlatStyle = FlatStyle.Flat;
            addProjectButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            addProjectButton.ForeColor = Color.Black;
            addProjectButton.Location = new Point(24, 47);
            addProjectButton.Name = "addProjectButton";
            addProjectButton.Size = new Size(35, 30);
            addProjectButton.TabIndex = 4;
            addProjectButton.Text = "+";
            addProjectButton.UseVisualStyleBackColor = false;
            // 
            // projectInfoPanel
            // 
            projectInfoPanel.AutoScroll = true;
            projectInfoPanel.BackColor = Color.White;
            projectInfoPanel.BorderStyle = BorderStyle.FixedSingle;
            projectInfoPanel.Controls.Add(partPanel);
            projectInfoPanel.Controls.Add(label1);
            projectInfoPanel.Controls.Add(projectStatusLabel);
            projectInfoPanel.Controls.Add(contractorLabel);
            projectInfoPanel.Controls.Add(projectDescLabel);
            projectInfoPanel.Controls.Add(projectIDLabel);
            projectInfoPanel.Controls.Add(projectNameLabel);
            projectInfoPanel.Dock = DockStyle.Right;
            projectInfoPanel.Location = new Point(409, 0);
            projectInfoPanel.Name = "projectInfoPanel";
            projectInfoPanel.Size = new Size(391, 450);
            projectInfoPanel.TabIndex = 3;
            // 
            // partPanel
            // 
            partPanel.Location = new Point(4, 394);
            partPanel.Name = "partPanel";
            partPanel.Size = new Size(350, 225);
            partPanel.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 11F);
            label1.Location = new Point(4, 361);
            label1.Name = "label1";
            label1.Size = new Size(80, 18);
            label1.TabIndex = 7;
            label1.Text = "Alkatrészek";
            // 
            // projectStatusLabel
            // 
            projectStatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            projectStatusLabel.AutoSize = true;
            projectStatusLabel.Font = new Font("Calibri", 11F);
            projectStatusLabel.Location = new Point(317, 46);
            projectStatusLabel.Name = "projectStatusLabel";
            projectStatusLabel.Size = new Size(52, 18);
            projectStatusLabel.TabIndex = 4;
            projectStatusLabel.Text = "Státusz";
            // 
            // contractorLabel
            // 
            contractorLabel.AutoSize = true;
            contractorLabel.Font = new Font("Calibri", 11F);
            contractorLabel.Location = new Point(4, 78);
            contractorLabel.Name = "contractorLabel";
            contractorLabel.Size = new Size(84, 18);
            contractorLabel.TabIndex = 3;
            contractorLabel.Text = "Megrendelö";
            // 
            // projectDescLabel
            // 
            projectDescLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            projectDescLabel.Font = new Font("Calibri", 11F);
            projectDescLabel.Location = new Point(4, 114);
            projectDescLabel.Name = "projectDescLabel";
            projectDescLabel.Size = new Size(365, 200);
            projectDescLabel.TabIndex = 2;
            projectDescLabel.Text = "Leírás";
            // 
            // projectIDLabel
            // 
            projectIDLabel.AutoSize = true;
            projectIDLabel.Font = new Font("Calibri", 11F);
            projectIDLabel.Location = new Point(3, 46);
            projectIDLabel.Name = "projectIDLabel";
            projectIDLabel.Size = new Size(69, 18);
            projectIDLabel.TabIndex = 1;
            projectIDLabel.Text = "Projekt ID";
            // 
            // projectNameLabel
            // 
            projectNameLabel.AutoSize = true;
            projectNameLabel.Font = new Font("Calibri", 14.25F, FontStyle.Bold);
            projectNameLabel.Location = new Point(3, 23);
            projectNameLabel.Name = "projectNameLabel";
            projectNameLabel.Size = new Size(114, 23);
            projectNameLabel.TabIndex = 0;
            projectNameLabel.Text = "Projekt Neve";
            // 
            // SzakemberMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainPanel);
            Name = "SzakemberMain";
            Size = new Size(800, 450);
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)projectGridView).EndInit();
            projectInfoPanel.ResumeLayout(false);
            projectInfoPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button addProjectButton;
        private Panel projectInfoPanel;
        private Label contractorLabel;
        private Label projectDescLabel;
        private Label projectIDLabel;
        private Label projectNameLabel;
        private DataGridView projectGridView;
        private Label projectStatusLabel;
        private Panel partPanel;
        private Label label1;
    }
}
