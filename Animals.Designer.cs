namespace Baobab_Ridge_Wildlife_Rehabilitation_Records_System
{
    partial class Animals
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DGVAnimals = new DataGridView();
            groupBox1 = new GroupBox();
            SearchIDTB = new TextBox();
            label1 = new Label();
            SearchButton = new Button();
            groupBox2 = new GroupBox();
            lblMode = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            RCtb = new TextBox();
            AgeTB = new TextBox();
            SpeciesTB = new TextBox();
            NameTB = new TextBox();
            AnimalTB = new TextBox();
            Savebutton = new Button();
            ClearButton = new Button();
            Addbutton = new Button();
            groupBox3 = new GroupBox();
            label7 = new Label();
            SummaryButton = new Button();
            DeleteButton = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVAnimals).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // DGVAnimals
            // 
            DGVAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVAnimals.Location = new Point(320, 55);
            DGVAnimals.Name = "DGVAnimals";
            DGVAnimals.RowHeadersWidth = 51;
            DGVAnimals.Size = new Size(560, 300);
            DGVAnimals.TabIndex = 0;
            DGVAnimals.SelectionChanged += DGVAnimals_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(SearchIDTB);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(SearchButton);
            groupBox1.Location = new Point(15, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 70);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search by Animal ID";
            // 
            // SearchIDTB
            // 
            SearchIDTB.Location = new Point(90, 28);
            SearchIDTB.Name = "SearchIDTB";
            SearchIDTB.Size = new Size(100, 27);
            SearchIDTB.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 31);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Animal ID";
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(200, 26);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(75, 30);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblMode);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(RCtb);
            groupBox2.Controls.Add(AgeTB);
            groupBox2.Controls.Add(SpeciesTB);
            groupBox2.Controls.Add(NameTB);
            groupBox2.Controls.Add(AnimalTB);
            groupBox2.Controls.Add(Savebutton);
            groupBox2.Controls.Add(ClearButton);
            groupBox2.Controls.Add(Addbutton);
            groupBox2.Location = new Point(15, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 310);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data Entry & Update";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMode.Location = new Point(15, 25);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(80, 20);
            lblMode.TabIndex = 14;
            lblMode.Text = "Mode: Add";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 175);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 13;
            label6.Text = "Recovery Score";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 140);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 12;
            label5.Text = "Age";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 105);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 11;
            label4.Text = "Species";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 70);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 10;
            label3.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 50);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 9;
            label2.Text = "Animal ID";
            // 
            // RCtb
            // 
            RCtb.Location = new Point(140, 172);
            RCtb.Name = "RCtb";
            RCtb.Size = new Size(130, 27);
            RCtb.TabIndex = 7;
            // 
            // AgeTB
            // 
            AgeTB.Location = new Point(140, 137);
            AgeTB.Name = "AgeTB";
            AgeTB.Size = new Size(130, 27);
            AgeTB.TabIndex = 6;
            // 
            // SpeciesTB
            // 
            SpeciesTB.Location = new Point(140, 102);
            SpeciesTB.Name = "SpeciesTB";
            SpeciesTB.Size = new Size(130, 27);
            SpeciesTB.TabIndex = 5;
            // 
            // NameTB
            // 
            NameTB.Location = new Point(140, 67);
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(130, 27);
            NameTB.TabIndex = 4;
            // 
            // AnimalTB
            // 
            AnimalTB.Location = new Point(140, 47);
            AnimalTB.Name = "AnimalTB";
            AnimalTB.Size = new Size(130, 27);
            AnimalTB.TabIndex = 3;
            // 
            // Savebutton
            // 
            Savebutton.Enabled = false;
            Savebutton.Location = new Point(150, 215);
            Savebutton.Name = "Savebutton";
            Savebutton.Size = new Size(120, 30);
            Savebutton.TabIndex = 2;
            Savebutton.Text = "Save Changes";
            Savebutton.UseVisualStyleBackColor = true;
            Savebutton.Click += Savebutton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(15, 255);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(255, 30);
            ClearButton.TabIndex = 1;
            ClearButton.Text = "Clear (Return to Add Mode)";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // Addbutton
            // 
            Addbutton.Location = new Point(15, 215);
            Addbutton.Name = "Addbutton";
            Addbutton.Size = new Size(120, 30);
            Addbutton.TabIndex = 0;
            Addbutton.Text = "Add Animal";
            Addbutton.UseVisualStyleBackColor = true;
            Addbutton.Click += Addbutton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(SummaryButton);
            groupBox3.Location = new Point(15, 445);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(865, 90);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Summary Report";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(190, 30);
            label7.Name = "label7";
            label7.Size = new Size(149, 20);
            label7.TabIndex = 14;
            label7.Text = "Summary will show here";
            // 
            // SummaryButton
            // 
            SummaryButton.Location = new Point(15, 25);
            SummaryButton.Name = "SummaryButton";
            SummaryButton.Size = new Size(160, 40);
            SummaryButton.TabIndex = 5;
            SummaryButton.Text = "Generate Summary";
            SummaryButton.UseVisualStyleBackColor = true;
            SummaryButton.Click += SummaryButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(740, 365);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(140, 30);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "Delete Selected";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.Location = new Point(320, 20);
            label8.Name = "label8";
            label8.Size = new Size(200, 25);
            label8.TabIndex = 15;
            label8.Text = "View & Manage Animals";
            // 
            // Animals
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(label8);
            Controls.Add(DeleteButton);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(DGVAnimals);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Animals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            Load += Animals_Load;
            ((System.ComponentModel.ISupportInitialize)DGVAnimals).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVAnimals;
        private GroupBox groupBox1;
        private Button SearchButton;
        private GroupBox groupBox2;
        private Button Savebutton;
        private Button ClearButton;
        private Button Addbutton;
        private GroupBox groupBox3;
        private TextBox RCtb;
        private TextBox AgeTB;
        private TextBox SpeciesTB;
        private TextBox NameTB;
        private TextBox AnimalTB;
        private TextBox SearchIDTB;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button SummaryButton;
        private Button DeleteButton;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblMode;
    }
}
