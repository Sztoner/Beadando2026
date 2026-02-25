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
            button1 = new Button();
            newButton = new Button();
            projectBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button1.Location = new Point(420, 186);
            button1.Name = "button1";
            button1.Size = new Size(100, 100);
            button1.TabIndex = 1;
            button1.Text = "Betöltés";
            button1.UseVisualStyleBackColor = false;
            // 
            // newButton
            // 
            newButton.BackColor = Color.SkyBlue;
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
            Controls.Add(button1);
            Controls.Add(newButton);
            Name = "SzakemberMain";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button newButton;
        private ComboBox projectBox;
    }
}
