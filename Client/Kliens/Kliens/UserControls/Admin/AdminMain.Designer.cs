namespace Kliens.UserControls.Admin
{
    partial class AdminMain
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
            usersGridView = new DataGridView();
            newUserButton = new Button();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)usersGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(49, 73);
            label1.Name = "label1";
            label1.Size = new Size(139, 30);
            label1.TabIndex = 9;
            label1.Text = "Felhasználók";
            // 
            // usersGridView
            // 
            usersGridView.AllowUserToAddRows = false;
            usersGridView.AllowUserToDeleteRows = false;
            usersGridView.AllowUserToResizeColumns = false;
            usersGridView.AllowUserToResizeRows = false;
            usersGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            usersGridView.BackgroundColor = Color.White;
            usersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersGridView.Location = new Point(49, 106);
            usersGridView.Name = "usersGridView";
            usersGridView.ReadOnly = true;
            usersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGridView.Size = new Size(548, 272);
            usersGridView.TabIndex = 8;
            // 
            // newUserButton
            // 
            newUserButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newUserButton.BackColor = Color.DodgerBlue;
            newUserButton.FlatStyle = FlatStyle.Flat;
            newUserButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            newUserButton.ForeColor = Color.Black;
            newUserButton.Location = new Point(603, 106);
            newUserButton.Name = "newUserButton";
            newUserButton.Size = new Size(72, 35);
            newUserButton.TabIndex = 10;
            newUserButton.Text = "Új";
            newUserButton.UseVisualStyleBackColor = false;
            newUserButton.Click += NewUser;
            // 
            // deleteButton
            // 
            deleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteButton.BackColor = Color.DodgerBlue;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            deleteButton.ForeColor = Color.Black;
            deleteButton.Location = new Point(603, 164);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(72, 35);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Törlés";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += DeleteUser;
            // 
            // AdminMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(deleteButton);
            Controls.Add(newUserButton);
            Controls.Add(label1);
            Controls.Add(usersGridView);
            Name = "AdminMain";
            Size = new Size(800, 450);
            Load += AdminMain_Load;
            ((System.ComponentModel.ISupportInitialize)usersGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView usersGridView;
        private Button newUserButton;
        private Button deleteButton;
    }
}
