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
            addPartButton = new Button();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            label3 = new Label();
            button1 = new Button();
            dbBox = new NumericUpDown();
            label2 = new Label();
            priceBox = new NumericUpDown();
            priceLabel = new Label();
            partIdLabel = new Label();
            partNameLabel = new Label();
            label4 = new Label();
            filterBox = new ComboBox();
            partBox = new ListBox();
            mainPanel.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(addPartButton);
            mainPanel.Controls.Add(panel1);
            mainPanel.Controls.Add(filterBox);
            mainPanel.Controls.Add(partBox);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 1;
            mainPanel.ControlAdded += DisableBackground;
            mainPanel.ControlRemoved += EnableBackground;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // addPartButton
            // 
            addPartButton.BackColor = Color.DodgerBlue;
            addPartButton.FlatStyle = FlatStyle.Flat;
            addPartButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            addPartButton.ForeColor = Color.Black;
            addPartButton.Location = new Point(24, 47);
            addPartButton.Name = "addPartButton";
            addPartButton.Size = new Size(35, 30);
            addPartButton.TabIndex = 4;
            addPartButton.Text = "+";
            addPartButton.UseVisualStyleBackColor = false;
            addPartButton.Click += ShowAddPartDialog;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dbBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(priceBox);
            panel1.Controls.Add(priceLabel);
            panel1.Controls.Add(partIdLabel);
            panel1.Controls.Add(partNameLabel);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(462, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 450);
            panel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Controls.Add(button6);
            flowLayoutPanel1.Controls.Add(button7);
            flowLayoutPanel1.Controls.Add(button8);
            flowLayoutPanel1.Controls.Add(button9);
            flowLayoutPanel1.Controls.Add(button10);
            flowLayoutPanel1.Controls.Add(button11);
            flowLayoutPanel1.Controls.Add(button12);
            flowLayoutPanel1.Controls.Add(button13);
            flowLayoutPanel1.Controls.Add(button14);
            flowLayoutPanel1.Controls.Add(button15);
            flowLayoutPanel1.Controls.Add(button16);
            flowLayoutPanel1.Controls.Add(button17);
            flowLayoutPanel1.Controls.Add(button18);
            flowLayoutPanel1.Controls.Add(button19);
            flowLayoutPanel1.Controls.Add(button20);
            flowLayoutPanel1.Controls.Add(button21);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(16, 137);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(301, 182);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // button2
            // 
            button2.BackColor = Color.SkyBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(7, 0);
            button2.Margin = new Padding(7, 0, 7, 0);
            button2.Name = "button2";
            button2.Size = new Size(45, 45);
            button2.TabIndex = 0;
            button2.Text = "1";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.SkyBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(7, 45);
            button3.Margin = new Padding(7, 0, 7, 0);
            button3.Name = "button3";
            button3.Size = new Size(45, 45);
            button3.TabIndex = 1;
            button3.Text = "2";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.SkyBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(7, 90);
            button4.Margin = new Padding(7, 0, 7, 0);
            button4.Name = "button4";
            button4.Size = new Size(45, 45);
            button4.TabIndex = 2;
            button4.Text = "3";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.SkyBlue;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(7, 135);
            button5.Margin = new Padding(7, 0, 7, 0);
            button5.Name = "button5";
            button5.Size = new Size(45, 45);
            button5.TabIndex = 3;
            button5.Text = "4";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.SkyBlue;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(66, 0);
            button6.Margin = new Padding(7, 0, 7, 0);
            button6.Name = "button6";
            button6.Size = new Size(45, 45);
            button6.TabIndex = 4;
            button6.Text = "1";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.SkyBlue;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(66, 45);
            button7.Margin = new Padding(7, 0, 7, 0);
            button7.Name = "button7";
            button7.Size = new Size(45, 45);
            button7.TabIndex = 5;
            button7.Text = "2";
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.SkyBlue;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(66, 90);
            button8.Margin = new Padding(7, 0, 7, 0);
            button8.Name = "button8";
            button8.Size = new Size(45, 45);
            button8.TabIndex = 6;
            button8.Text = "3";
            button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            button9.BackColor = Color.SkyBlue;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Location = new Point(66, 135);
            button9.Margin = new Padding(7, 0, 7, 0);
            button9.Name = "button9";
            button9.Size = new Size(45, 45);
            button9.TabIndex = 7;
            button9.Text = "4";
            button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            button10.BackColor = Color.SkyBlue;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(125, 0);
            button10.Margin = new Padding(7, 0, 7, 0);
            button10.Name = "button10";
            button10.Size = new Size(45, 45);
            button10.TabIndex = 8;
            button10.Text = "1";
            button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            button11.BackColor = Color.SkyBlue;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(125, 45);
            button11.Margin = new Padding(7, 0, 7, 0);
            button11.Name = "button11";
            button11.Size = new Size(45, 45);
            button11.TabIndex = 9;
            button11.Text = "2";
            button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            button12.BackColor = Color.SkyBlue;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Location = new Point(125, 90);
            button12.Margin = new Padding(7, 0, 7, 0);
            button12.Name = "button12";
            button12.Size = new Size(45, 45);
            button12.TabIndex = 10;
            button12.Text = "3";
            button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            button13.BackColor = Color.SkyBlue;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Location = new Point(125, 135);
            button13.Margin = new Padding(7, 0, 7, 0);
            button13.Name = "button13";
            button13.Size = new Size(45, 45);
            button13.TabIndex = 11;
            button13.Text = "4";
            button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            button14.BackColor = Color.SkyBlue;
            button14.FlatStyle = FlatStyle.Flat;
            button14.Location = new Point(184, 0);
            button14.Margin = new Padding(7, 0, 7, 0);
            button14.Name = "button14";
            button14.Size = new Size(45, 45);
            button14.TabIndex = 12;
            button14.Text = "1";
            button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            button15.BackColor = Color.SkyBlue;
            button15.FlatStyle = FlatStyle.Flat;
            button15.Location = new Point(184, 45);
            button15.Margin = new Padding(7, 0, 7, 0);
            button15.Name = "button15";
            button15.Size = new Size(45, 45);
            button15.TabIndex = 13;
            button15.Text = "2";
            button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            button16.BackColor = Color.SkyBlue;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Location = new Point(184, 90);
            button16.Margin = new Padding(7, 0, 7, 0);
            button16.Name = "button16";
            button16.Size = new Size(45, 45);
            button16.TabIndex = 14;
            button16.Text = "3";
            button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            button17.BackColor = Color.SkyBlue;
            button17.FlatStyle = FlatStyle.Flat;
            button17.Location = new Point(184, 135);
            button17.Margin = new Padding(7, 0, 7, 0);
            button17.Name = "button17";
            button17.Size = new Size(45, 45);
            button17.TabIndex = 15;
            button17.Text = "4";
            button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            button18.BackColor = Color.SkyBlue;
            button18.FlatStyle = FlatStyle.Flat;
            button18.Location = new Point(243, 0);
            button18.Margin = new Padding(7, 0, 7, 0);
            button18.Name = "button18";
            button18.Size = new Size(45, 45);
            button18.TabIndex = 16;
            button18.Text = "1";
            button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            button19.BackColor = Color.SkyBlue;
            button19.FlatStyle = FlatStyle.Flat;
            button19.Location = new Point(243, 45);
            button19.Margin = new Padding(7, 0, 7, 0);
            button19.Name = "button19";
            button19.Size = new Size(45, 45);
            button19.TabIndex = 17;
            button19.Text = "2";
            button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            button20.BackColor = Color.SkyBlue;
            button20.FlatStyle = FlatStyle.Flat;
            button20.Location = new Point(243, 90);
            button20.Margin = new Padding(7, 0, 7, 0);
            button20.Name = "button20";
            button20.Size = new Size(45, 45);
            button20.TabIndex = 18;
            button20.Text = "3";
            button20.UseVisualStyleBackColor = false;
            // 
            // button21
            // 
            button21.BackColor = Color.SkyBlue;
            button21.FlatStyle = FlatStyle.Flat;
            button21.Location = new Point(243, 135);
            button21.Margin = new Padding(7, 0, 7, 0);
            button21.Name = "button21";
            button21.Size = new Size(45, 45);
            button21.TabIndex = 19;
            button21.Text = "4";
            button21.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Calibri", 11F);
            label3.Location = new Point(128, 100);
            label3.Name = "label3";
            label3.Size = new Size(20, 18);
            label3.TabIndex = 7;
            label3.Text = "Ft";
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Calibri", 10F);
            button1.Location = new Point(242, 98);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Mentés";
            button1.UseVisualStyleBackColor = false;
            button1.Click += UpdatePart;
            // 
            // dbBox
            // 
            dbBox.Location = new Point(159, 98);
            dbBox.Name = "dbBox";
            dbBox.Size = new Size(59, 23);
            dbBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 11F);
            label2.Location = new Point(159, 77);
            label2.Name = "label2";
            label2.Size = new Size(90, 18);
            label2.TabIndex = 4;
            label2.Text = "Max. /Rekesz";
            // 
            // priceBox
            // 
            priceBox.Location = new Point(16, 98);
            priceBox.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(111, 23);
            priceBox.TabIndex = 3;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Calibri", 11F);
            priceLabel.Location = new Point(16, 77);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(22, 18);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Ár";
            // 
            // partIdLabel
            // 
            partIdLabel.AutoSize = true;
            partIdLabel.Font = new Font("Calibri", 11F);
            partIdLabel.Location = new Point(3, 46);
            partIdLabel.Name = "partIdLabel";
            partIdLabel.Size = new Size(81, 18);
            partIdLabel.TabIndex = 1;
            partIdLabel.Text = "Alkatrész ID";
            // 
            // partNameLabel
            // 
            partNameLabel.AutoSize = true;
            partNameLabel.Font = new Font("Calibri", 14.25F, FontStyle.Bold);
            partNameLabel.Location = new Point(3, 23);
            partNameLabel.Name = "partNameLabel";
            partNameLabel.Size = new Size(131, 23);
            partNameLabel.TabIndex = 0;
            partNameLabel.Text = "Alaktrész Neve";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Calibri", 11F);
            label4.Location = new Point(216, 100);
            label4.Name = "label4";
            label4.Size = new Size(24, 18);
            label4.TabIndex = 9;
            label4.Text = "db";
            // 
            // filterBox
            // 
            filterBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filterBox.BackColor = SystemColors.Window;
            filterBox.Font = new Font("Segoe UI", 11F);
            filterBox.FormattingEnabled = true;
            filterBox.Items.AddRange(new object[] { "Összes", "Hiányzó", "Lefoglalt" });
            filterBox.Location = new Point(295, 47);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(99, 28);
            filterBox.TabIndex = 2;
            // 
            // partBox
            // 
            partBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            partBox.BorderStyle = BorderStyle.FixedSingle;
            partBox.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            partBox.FormattingEnabled = true;
            partBox.ItemHeight = 19;
            partBox.Location = new Point(24, 79);
            partBox.Name = "partBox";
            partBox.Size = new Size(370, 306);
            partBox.TabIndex = 0;
            partBox.SelectedValueChanged += partBox_SelectedValueChanged;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dbBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel mainPanel;
        private ListBox partBox;
        private Panel panel1;
        private Label partIdLabel;
        private Label partNameLabel;
        private ComboBox filterBox;
        private NumericUpDown dbBox;
        private Label label2;
        private NumericUpDown priceBox;
        private Label priceLabel;
        private Button button1;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
        private Button button21;
        private Label label4;
        private Button addPartButton;
    }
}
