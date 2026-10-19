namespace BaobabRidgeWildlifeRehabilitationRecordsSystem
{
    partial class MainForm
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
            dgvAnimals = new DataGridView();
            grpSearch = new GroupBox();
            txtSearchId = new TextBox();
            lblSearchId = new Label();
            btnSearch = new Button();
            grpDataEntry = new GroupBox();
            lblMode = new Label();
            lblAnimalId = new Label();
            txtAnimalId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblSpecies = new Label();
            txtSpecies = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblRecoveryScore = new Label();
            txtRecoveryScore = new TextBox();
            btnAdd = new Button();
            btnSaveChanges = new Button();
            btnClear = new Button();
            grpSummary = new GroupBox();
            btnSummary = new Button();
            lblTotalAnimals = new Label();
            lblAverageAge = new Label();
            lblAverageScore = new Label();
            lblCritical = new Label();
            lblSerious = new Label();
            lblStable = new Label();
            lblRecovering = new Label();
            lblReleaseReady = new Label();
            btnDelete = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).BeginInit();
            grpSearch.SuspendLayout();
            grpDataEntry.SuspendLayout();
            grpSummary.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAnimals
            // 
            dgvAnimals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimals.Location = new Point(340, 60);
            dgvAnimals.Name = "dgvAnimals";
            dgvAnimals.RowHeadersWidth = 51;
            dgvAnimals.Size = new Size(620, 320);
            dgvAnimals.TabIndex = 0;
            dgvAnimals.SelectionChanged += dgvAnimals_SelectionChanged;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(txtSearchId);
            grpSearch.Controls.Add(lblSearchId);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Location = new Point(20, 50);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(300, 70);
            grpSearch.TabIndex = 1;
            grpSearch.TabStop = false;
            grpSearch.Text = "Search by Animal ID";
            // 
            // txtSearchId
            // 
            txtSearchId.Location = new Point(90, 28);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(100, 27);
            txtSearchId.TabIndex = 1;
            // 
            // lblSearchId
            // 
            lblSearchId.AutoSize = true;
            lblSearchId.Location = new Point(15, 31);
            lblSearchId.Name = "lblSearchId";
            lblSearchId.Size = new Size(69, 20);
            lblSearchId.TabIndex = 0;
            lblSearchId.Text = "Animal ID";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(200, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // grpDataEntry
            // 
            grpDataEntry.Controls.Add(lblMode);
            grpDataEntry.Controls.Add(lblAnimalId);
            grpDataEntry.Controls.Add(txtAnimalId);
            grpDataEntry.Controls.Add(lblName);
            grpDataEntry.Controls.Add(txtName);
            grpDataEntry.Controls.Add(lblSpecies);
            grpDataEntry.Controls.Add(txtSpecies);
            grpDataEntry.Controls.Add(lblAge);
            grpDataEntry.Controls.Add(txtAge);
            grpDataEntry.Controls.Add(lblRecoveryScore);
            grpDataEntry.Controls.Add(txtRecoveryScore);
            grpDataEntry.Controls.Add(btnAdd);
            grpDataEntry.Controls.Add(btnSaveChanges);
            grpDataEntry.Controls.Add(btnClear);
            grpDataEntry.Location = new Point(20, 130);
            grpDataEntry.Name = "grpDataEntry";
            grpDataEntry.Size = new Size(300, 320);
            grpDataEntry.TabIndex = 2;
            grpDataEntry.TabStop = false;
            grpDataEntry.Text = "Data Entry & Update";
            // 
            // lblMode
            // 
            lblMode.AutoSize = true;
            lblMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMode.Location = new Point(15, 25);
            lblMode.Name = "lblMode";
            lblMode.Size = new Size(80, 20);
            lblMode.TabIndex = 0;
            lblMode.Text = "Mode: Add";
            // 
            // lblAnimalId
            // 
            lblAnimalId.AutoSize = true;
            lblAnimalId.Location = new Point(15, 55);
            lblAnimalId.Name = "lblAnimalId";
            lblAnimalId.Size = new Size(69, 20);
            lblAnimalId.TabIndex = 1;
            lblAnimalId.Text = "Animal ID";
            // 
            // txtAnimalId
            // 
            txtAnimalId.Location = new Point(140, 52);
            txtAnimalId.Name = "txtAnimalId";
            txtAnimalId.Size = new Size(140, 27);
            txtAnimalId.TabIndex = 2;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 90);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 20);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 87);
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 27);
            txtName.TabIndex = 4;
            // 
            // lblSpecies
            // 
            lblSpecies.AutoSize = true;
            lblSpecies.Location = new Point(15, 125);
            lblSpecies.Name = "lblSpecies";
            lblSpecies.Size = new Size(58, 20);
            lblSpecies.TabIndex = 5;
            lblSpecies.Text = "Species";
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(140, 122);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(140, 27);
            txtSpecies.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(15, 160);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(36, 20);
            lblAge.TabIndex = 7;
            lblAge.Text = "Age";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(140, 157);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(140, 27);
            txtAge.TabIndex = 8;
            // 
            // lblRecoveryScore
            // 
            lblRecoveryScore.AutoSize = true;
            lblRecoveryScore.Location = new Point(15, 195);
            lblRecoveryScore.Name = "lblRecoveryScore";
            lblRecoveryScore.Size = new Size(110, 20);
            lblRecoveryScore.TabIndex = 9;
            lblRecoveryScore.Text = "Recovery Score";
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.Location = new Point(140, 192);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(140, 27);
            txtRecoveryScore.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 240);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 32);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add Animal";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Enabled = false;
            btnSaveChanges.Location = new Point(150, 240);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(130, 32);
            btnSaveChanges.TabIndex = 12;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(15, 280);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(265, 30);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear (Return to Add Mode)";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // grpSummary
            // 
            grpSummary.Controls.Add(btnSummary);
            grpSummary.Controls.Add(lblTotalAnimals);
            grpSummary.Controls.Add(lblAverageAge);
            grpSummary.Controls.Add(lblAverageScore);
            grpSummary.Controls.Add(lblCritical);
            grpSummary.Controls.Add(lblSerious);
            grpSummary.Controls.Add(lblStable);
            grpSummary.Controls.Add(lblRecovering);
            grpSummary.Controls.Add(lblReleaseReady);
            grpSummary.Location = new Point(20, 460);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(940, 130);
            grpSummary.TabIndex = 3;
            grpSummary.TabStop = false;
            grpSummary.Text = "Summary Report";
            // 
            // btnSummary
            // 
            btnSummary.Location = new Point(15, 30);
            btnSummary.Name = "btnSummary";
            btnSummary.Size = new Size(160, 40);
            btnSummary.TabIndex = 0;
            btnSummary.Text = "Generate Summary";
            btnSummary.UseVisualStyleBackColor = true;
            btnSummary.Click += btnSummary_Click;
            // 
            // lblTotalAnimals
            // 
            lblTotalAnimals.AutoSize = true;
            lblTotalAnimals.Location = new Point(200, 25);
            lblTotalAnimals.Name = "lblTotalAnimals";
            lblTotalAnimals.Size = new Size(110, 20);
            lblTotalAnimals.TabIndex = 1;
            lblTotalAnimals.Text = "Total animals: -";
            // 
            // lblAverageAge
            // 
            lblAverageAge.AutoSize = true;
            lblAverageAge.Location = new Point(200, 50);
            lblAverageAge.Name = "lblAverageAge";
            lblAverageAge.Size = new Size(160, 20);
            lblAverageAge.TabIndex = 2;
            lblAverageAge.Text = "Average age (years): -";
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(200, 75);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(180, 20);
            lblAverageScore.TabIndex = 3;
            lblAverageScore.Text = "Average recovery score: -";
            // 
            // lblCritical
            // 
            lblCritical.AutoSize = true;
            lblCritical.Location = new Point(500, 25);
            lblCritical.Name = "lblCritical";
            lblCritical.Size = new Size(70, 20);
            lblCritical.TabIndex = 4;
            lblCritical.Text = "Critical: -";
            // 
            // lblSerious
            // 
            lblSerious.AutoSize = true;
            lblSerious.Location = new Point(500, 50);
            lblSerious.Name = "lblSerious";
            lblSerious.Size = new Size(70, 20);
            lblSerious.TabIndex = 5;
            lblSerious.Text = "Serious: -";
            // 
            // lblStable
            // 
            lblStable.AutoSize = true;
            lblStable.Location = new Point(500, 75);
            lblStable.Name = "lblStable";
            lblStable.Size = new Size(60, 20);
            lblStable.TabIndex = 6;
            lblStable.Text = "Stable: -";
            // 
            // lblRecovering
            // 
            lblRecovering.AutoSize = true;
            lblRecovering.Location = new Point(700, 25);
            lblRecovering.Name = "lblRecovering";
            lblRecovering.Size = new Size(95, 20);
            lblRecovering.TabIndex = 7;
            lblRecovering.Text = "Recovering: -";
            // 
            // lblReleaseReady
            // 
            lblReleaseReady.AutoSize = true;
            lblReleaseReady.Location = new Point(700, 50);
            lblReleaseReady.Name = "lblReleaseReady";
            lblReleaseReady.Size = new Size(110, 20);
            lblReleaseReady.TabIndex = 8;
            lblReleaseReady.Text = "Release-Ready: -";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(820, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 32);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Selected";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(480, 28);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 610);
            Controls.Add(lblTitle);
            Controls.Add(btnDelete);
            Controls.Add(grpSummary);
            Controls.Add(grpDataEntry);
            Controls.Add(grpSearch);
            Controls.Add(dgvAnimals);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnimals).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            grpDataEntry.ResumeLayout(false);
            grpDataEntry.PerformLayout();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAnimals;
        private GroupBox grpSearch;
        private TextBox txtSearchId;
        private Label lblSearchId;
        private Button btnSearch;
        private GroupBox grpDataEntry;
        private Label lblMode;
        private Label lblAnimalId;
        private TextBox txtAnimalId;
        private Label lblName;
        private TextBox txtName;
        private Label lblSpecies;
        private TextBox txtSpecies;
        private Label lblAge;
        private TextBox txtAge;
        private Label lblRecoveryScore;
        private TextBox txtRecoveryScore;
        private Button btnAdd;
        private Button btnSaveChanges;
        private Button btnClear;
        private GroupBox grpSummary;
        private Button btnSummary;
        private Label lblTotalAnimals;
        private Label lblAverageAge;
        private Label lblAverageScore;
        private Label lblCritical;
        private Label lblSerious;
        private Label lblStable;
        private Label lblRecovering;
        private Label lblReleaseReady;
        private Button btnDelete;
        private Label lblTitle;
    }
}
