namespace Kliens.UserControls
{
    partial class TwoFA
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
            label1 = new Label();
            sendButton = new Button();
            codeBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 15F);
            label1.Location = new Point(95, 118);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 24);
            label1.TabIndex = 24;
            label1.Text = "Hitelesítö kód";
            // 
            // sendButton
            // 
            sendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sendButton.BackColor = Color.DodgerBlue;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI", 10F);
            sendButton.ForeColor = Color.Black;
            sendButton.Location = new Point(122, 182);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(72, 35);
            sendButton.TabIndex = 25;
            sendButton.Text = "Küldés";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += SendVerifyRequest;
            // 
            // codeBox
            // 
            codeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            codeBox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            codeBox.Location = new Point(36, 145);
            codeBox.Margin = new Padding(4, 3, 4, 3);
            codeBox.Name = "codeBox";
            codeBox.Size = new Size(243, 31);
            codeBox.TabIndex = 26;
            codeBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TwoFA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(314, 351);
            Controls.Add(codeBox);
            Controls.Add(sendButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(330, 390);
            MinimizeBox = false;
            MinimumSize = new Size(330, 390);
            Name = "TwoFA";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kétlépcsös Azonosítás";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button sendButton;
        private TextBox codeBox;
    }
}