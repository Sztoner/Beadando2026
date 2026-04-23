namespace Kliens.UserControls.Szakember
{
    partial class ProjektInfo
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
            PartsPanel = new Panel();
            PartsButton = new Button();
            partGridView = new DataGridView();
            partsLabel = new Label();
            detailsPanel = new Panel();
            calcPriceButton = new Button();
            priceLabel = new Label();
            partPriceLabel = new Label();
            savePriceButton = new Button();
            label6 = new Label();
            label5 = new Label();
            laborcostBox = new NumericUpDown();
            joblenghtBox = new NumericUpDown();
            statusLabel = new Label();
            nameLabel = new Label();
            label3 = new Label();
            descriptionLabel = new Label();
            label2 = new Label();
            locationLabel = new Label();
            label1 = new Label();
            clientLabel = new Label();
            closeProjectButton = new Button();
            topPanel = new Panel();
            backButton = new Button();
            mainPanel.SuspendLayout();
            PartsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)partGridView).BeginInit();
            detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)laborcostBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)joblenghtBox).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Controls.Add(PartsPanel);
            mainPanel.Controls.Add(detailsPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 30);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 420);
            mainPanel.TabIndex = 0;
            // 
            // PartsPanel
            // 
            PartsPanel.Controls.Add(PartsButton);
            PartsPanel.Controls.Add(partGridView);
            PartsPanel.Controls.Add(partsLabel);
            PartsPanel.Dock = DockStyle.Top;
            PartsPanel.Location = new Point(0, 239);
            PartsPanel.Name = "PartsPanel";
            PartsPanel.Size = new Size(783, 280);
            PartsPanel.TabIndex = 6;
            // 
            // PartsButton
            // 
            PartsButton.BackColor = Color.DodgerBlue;
            PartsButton.FlatStyle = FlatStyle.Flat;
            PartsButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            PartsButton.ForeColor = Color.Black;
            PartsButton.Location = new Point(253, 16);
            PartsButton.Name = "PartsButton";
            PartsButton.Size = new Size(90, 35);
            PartsButton.TabIndex = 8;
            PartsButton.Text = "Lefoglalás";
            PartsButton.UseVisualStyleBackColor = false;
            PartsButton.Click += AddParts;
            // 
            // partGridView
            // 
            partGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            partGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            partGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            partGridView.BackgroundColor = Color.White;
            partGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            partGridView.Location = new Point(12, 47);
            partGridView.Name = "partGridView";
            partGridView.ReadOnly = true;
            partGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            partGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partGridView.Size = new Size(436, 230);
            partGridView.TabIndex = 5;
            // 
            // partsLabel
            // 
            partsLabel.AutoSize = true;
            partsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            partsLabel.Location = new Point(3, 16);
            partsLabel.Name = "partsLabel";
            partsLabel.Size = new Size(114, 25);
            partsLabel.TabIndex = 4;
            partsLabel.Text = "Alkatrészek";
            // 
            // detailsPanel
            // 
            detailsPanel.Controls.Add(calcPriceButton);
            detailsPanel.Controls.Add(priceLabel);
            detailsPanel.Controls.Add(partPriceLabel);
            detailsPanel.Controls.Add(savePriceButton);
            detailsPanel.Controls.Add(label6);
            detailsPanel.Controls.Add(label5);
            detailsPanel.Controls.Add(laborcostBox);
            detailsPanel.Controls.Add(joblenghtBox);
            detailsPanel.Controls.Add(statusLabel);
            detailsPanel.Controls.Add(nameLabel);
            detailsPanel.Controls.Add(label3);
            detailsPanel.Controls.Add(descriptionLabel);
            detailsPanel.Controls.Add(label2);
            detailsPanel.Controls.Add(locationLabel);
            detailsPanel.Controls.Add(label1);
            detailsPanel.Controls.Add(clientLabel);
            detailsPanel.Dock = DockStyle.Top;
            detailsPanel.Location = new Point(0, 0);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Size = new Size(783, 239);
            detailsPanel.TabIndex = 5;
            // 
            // calcPriceButton
            // 
            calcPriceButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            calcPriceButton.BackColor = Color.DodgerBlue;
            calcPriceButton.FlatStyle = FlatStyle.Flat;
            calcPriceButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            calcPriceButton.ForeColor = Color.Black;
            calcPriceButton.Location = new Point(566, 168);
            calcPriceButton.Name = "calcPriceButton";
            calcPriceButton.Size = new Size(89, 28);
            calcPriceButton.TabIndex = 17;
            calcPriceButton.Text = "Árkalkuláció";
            calcPriceButton.UseVisualStyleBackColor = false;
            calcPriceButton.Visible = false;
            calcPriceButton.Click += CalculatePrice;
            // 
            // priceLabel
            // 
            priceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Segoe UI", 13F);
            priceLabel.Location = new Point(566, 140);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(93, 25);
            priceLabel.TabIndex = 12;
            priceLabel.Text = "Össz. Ár: -";
            priceLabel.Visible = false;
            // 
            // partPriceLabel
            // 
            partPriceLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            partPriceLabel.AutoSize = true;
            partPriceLabel.Font = new Font("Segoe UI", 13F);
            partPriceLabel.Location = new Point(566, 115);
            partPriceLabel.Name = "partPriceLabel";
            partPriceLabel.Size = new Size(145, 25);
            partPriceLabel.TabIndex = 11;
            partPriceLabel.Text = "Akatrészek Ára: -";
            partPriceLabel.Visible = false;
            // 
            // savePriceButton
            // 
            savePriceButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            savePriceButton.BackColor = Color.DodgerBlue;
            savePriceButton.FlatStyle = FlatStyle.Flat;
            savePriceButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            savePriceButton.ForeColor = Color.Black;
            savePriceButton.Location = new Point(698, 125);
            savePriceButton.Name = "savePriceButton";
            savePriceButton.Size = new Size(68, 28);
            savePriceButton.TabIndex = 12;
            savePriceButton.Text = "Mentés";
            savePriceButton.UseVisualStyleBackColor = false;
            savePriceButton.Click += UpdatePriceInfo;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(745, 90);
            label6.Name = "label6";
            label6.Size = new Size(21, 19);
            label6.TabIndex = 15;
            label6.Text = "Ft";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(745, 65);
            label5.Name = "label5";
            label5.Size = new Size(32, 19);
            label5.TabIndex = 14;
            label5.Text = "nap";
            // 
            // laborcostBox
            // 
            laborcostBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            laborcostBox.BorderStyle = BorderStyle.None;
            laborcostBox.Font = new Font("Segoe UI", 11F);
            laborcostBox.Location = new Point(668, 89);
            laborcostBox.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            laborcostBox.Name = "laborcostBox";
            laborcostBox.Size = new Size(71, 23);
            laborcostBox.TabIndex = 13;
            laborcostBox.TabStop = false;
            laborcostBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // joblenghtBox
            // 
            joblenghtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            joblenghtBox.BorderStyle = BorderStyle.None;
            joblenghtBox.Font = new Font("Segoe UI", 11F);
            joblenghtBox.Location = new Point(668, 66);
            joblenghtBox.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            joblenghtBox.Name = "joblenghtBox";
            joblenghtBox.Size = new Size(71, 23);
            joblenghtBox.TabIndex = 12;
            joblenghtBox.TabStop = false;
            joblenghtBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            statusLabel.Font = new Font("Segoe UI", 14F);
            statusLabel.Location = new Point(593, 3);
            statusLabel.Name = "statusLabel";
            statusLabel.RightToLeft = RightToLeft.No;
            statusLabel.Size = new Size(187, 32);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Állapot:";
            statusLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            nameLabel.Location = new Point(0, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(173, 36);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Projekt Neve";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(566, 86);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 10;
            label3.Text = "Munkadíj:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            descriptionLabel.Font = new Font("Segoe UI", 12F);
            descriptionLabel.Location = new Point(0, 125);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(519, 99);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Leírás";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(566, 61);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 9;
            label2.Text = "Munkaidö:";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Segoe UI", 14F);
            locationLabel.Location = new Point(0, 61);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(82, 25);
            locationLabel.TabIndex = 1;
            locationLabel.Text = "Helyszín";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(0, 100);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 3;
            label1.Text = "Leírás";
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Font = new Font("Segoe UI", 14F);
            clientLabel.Location = new Point(0, 36);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(115, 25);
            clientLabel.TabIndex = 2;
            clientLabel.Text = "Megrendelö";
            // 
            // closeProjectButton
            // 
            closeProjectButton.BackColor = Color.DodgerBlue;
            closeProjectButton.Dock = DockStyle.Left;
            closeProjectButton.FlatStyle = FlatStyle.Flat;
            closeProjectButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            closeProjectButton.ForeColor = Color.Black;
            closeProjectButton.Location = new Point(0, 0);
            closeProjectButton.Name = "closeProjectButton";
            closeProjectButton.Size = new Size(89, 30);
            closeProjectButton.TabIndex = 16;
            closeProjectButton.Text = "Lezárás";
            closeProjectButton.UseVisualStyleBackColor = false;
            closeProjectButton.Visible = false;
            closeProjectButton.Click += CloseProject;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(backButton);
            topPanel.Controls.Add(closeProjectButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(800, 30);
            topPanel.TabIndex = 1;
            // 
            // backButton
            // 
            backButton.BackColor = Color.White;
            backButton.Dock = DockStyle.Right;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            backButton.ForeColor = Color.Black;
            backButton.Location = new Point(770, 0);
            backButton.Name = "backButton";
            backButton.Size = new Size(30, 30);
            backButton.TabIndex = 17;
            backButton.Text = ">";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += GoBack;
            // 
            // ProjektInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainPanel);
            Controls.Add(topPanel);
            Name = "ProjektInfo";
            Size = new Size(800, 450);
            Load += ProjektInfo_Load;
            mainPanel.ResumeLayout(false);
            PartsPanel.ResumeLayout(false);
            PartsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)partGridView).EndInit();
            detailsPanel.ResumeLayout(false);
            detailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)laborcostBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)joblenghtBox).EndInit();
            topPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel topPanel;
        private Label statusLabel;
        private Label nameLabel;
        private Label locationLabel;
        private Label clientLabel;
        private Label descriptionLabel;
        private Label label1;
        private Panel detailsPanel;
        private Panel PartsPanel;
        private DataGridView partGridView;
        private Label partsLabel;
        private Button PartsButton;
        private Label partPriceLabel;
        private Label label3;
        private Label label2;
        private NumericUpDown joblenghtBox;
        private NumericUpDown laborcostBox;
        private Button savePriceButton;
        private Label label6;
        private Label label5;
        private Label priceLabel;
        private Button closeProjectButton;
        private Button backButton;
        private Button calcPriceButton;
    }
}
