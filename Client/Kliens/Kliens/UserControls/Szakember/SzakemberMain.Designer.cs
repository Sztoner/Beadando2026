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
            loadButton = new Button();
            newButton = new Button();
            projectBox = new ComboBox();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.BackColor = Color.DodgerBlue;
            loadButton.FlatStyle = FlatStyle.Flat;
            loadButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            loadButton.Location = new Point(420, 186);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(100, 100);
            loadButton.TabIndex = 1;
            loadButton.Text = "Betöltés";
            loadButton.UseVisualStyleBackColor = false;
            // 
            // newButton
            // 
            newButton.BackColor = Color.DodgerBlue;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.Font = new Font("Segoe UI", 39.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            newButton.Location = new Point(280, 186);
            newButton.Name = "newButton";
            newButton.Size = new Size(100, 100);
            newButton.TabIndex = 0;
            newButton.Text = "+";
            newButton.UseVisualStyleBackColor = false;
            // 
            // projectBox
            // 
            projectBox.Font = new Font("Segoe UI", 11F);
            projectBox.FormattingEnabled = true;
            projectBox.Location = new Point(526, 186);
            projectBox.Name = "projectBox";
            projectBox.Size = new Size(163, 28);
            projectBox.TabIndex = 2;
            projectBox.Visible = false;
            // 
            // SzakemberMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(projectBox);
            Controls.Add(loadButton);
            Controls.Add(newButton);
            Name = "SzakemberMain";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Button loadButton;
        private Button newButton;
        private ComboBox projectBox;
    }
}
