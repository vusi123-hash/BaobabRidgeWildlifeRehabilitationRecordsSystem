using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaobabRidgeWildlifeRehabilitationRecordsSystem
{
    /// <summary>
    /// Main form for the Baobab Ridge Wildlife Rehabilitation Records System.
    /// Supports Add, View, Update (Search + grid select), Delete and Summary Report.
    /// </summary>
    public partial class MainForm : Form
    {
        // Path to the animals data file (same folder as the running .exe).
        private readonly string _filePath = Path.Combine(Application.StartupPath, "animals.txt");

        // In-memory list of valid animals currently loaded from the file.
        private List<Animal> _animalList = new List<Animal>();

        // Tracks whether the form is currently in Edit mode.
        private bool _isEditMode = false;

        // The ID of the animal currently being edited (null when in Add mode).
        private string? _editingId = null;

        /// <summary>
        /// Initialises the form, sets up the grid and loads data.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            SetupDataGridView();
            EnterAddMode();
        }

        /// <summary>
        /// Called when the form is first shown. Loads the animal data.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #region Grid and File Loading

        /// <summary>
        /// Configures the DataGridView columns and behaviour according to the brief.
        /// </summary>
        private void SetupDataGridView()
        {
            dgvAnimals.ReadOnly = true;
            dgvAnimals.AllowUserToAddRows = false;
            dgvAnimals.AllowUserToDeleteRows = false;
            dgvAnimals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimals.MultiSelect = false;
            dgvAnimals.AutoGenerateColumns = false;
            dgvAnimals.RowHeadersVisible = false;
            dgvAnimals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAnimals.Columns.Clear();
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ID", HeaderText = "Animal ID", Name = "colID" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Name = "colName" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Species", HeaderText = "Species", Name = "colSpecies" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Age", HeaderText = "Age", Name = "colAge" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RecoveryScore", HeaderText = "Recovery Score", Name = "colScore" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "colStatus" });
            dgvAnimals.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HousingUnit", HeaderText = "Housing Unit", Name = "colHouse" });
        }

        /// <summary>
        /// Ensures animals.txt exists. Creates an empty file if it is missing.
        /// </summary>
        private void EnsureFileExists()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    File.Create(_filePath).Close();
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied while creating the animals file.", "Access Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to create animals file because it is in use by another process.", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while creating the file: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads valid animal records from animals.txt into _animalList.
        /// Skips malformed lines and reports how many were skipped.
        /// </summary>
        private void LoadAnimalData()
        {
            _animalList.Clear();
            EnsureFileExists();

            int skippedLines = 0;

            try
            {
                string[] lines = File.ReadAllLines(_filePath, Encoding.UTF8);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');

                    // Expect exactly 7 fields.
                    if (parts.Length != 7)
                    {
                        skippedLines++;
                        continue;
                    }

                    string id = parts[0].Trim().ToUpperInvariant();
                    string name = parts[1].Trim();
                    string species = parts[2].Trim();
                    string ageText = parts[3].Trim();
                    string scoreText = parts[4].Trim();
                    // Status and Housing are recalculated on save; we still store the file values for display.
                    string status = parts[5].Trim();
                    string housing = parts[6].Trim();

                    // Validate ID format (WR- + 4 digits), age and score ranges.
                    bool idValid = id.Length == 7 && id.StartsWith("WR-") &&
                                   int.TryParse(id.Substring(3), out _);
                    bool ageValid = int.TryParse(ageText, out int age) && age >= 0 && age <= 100;
                    bool scoreValid = int.TryParse(scoreText, out int score) && score >= 0 && score <= 100;

                    if (idValid && ageValid && scoreValid)
                    {
                        _animalList.Add(new Animal(id, name, species, age, score, status, housing));
                    }
                    else
                    {
                        skippedLines++;
                    }
                }

                if (skippedLines > 0)
                {
                    MessageBox.Show($"{skippedLines} malformed record(s) were skipped.", "Data Load Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied when attempting to read animals.txt.", "Access Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("The animals.txt file is currently open in another program.", "File In Use",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reloads data from file and rebinds the grid.
        /// </summary>
        private void RefreshGrid()
        {
            LoadAnimalData();
            dgvAnimals.DataSource = null;
            dgvAnimals.DataSource = _animalList;
        }

        /// <summary>
        /// Writes the entire current _animalList back to animals.txt (full rewrite).
        /// Used by Update and Delete.
        /// </summary>
        private bool RewriteAnimalFile()
        {
            try
            {
                var lines = _animalList.Select(a => a.ToFileLine()).ToArray();
                File.WriteAllLines(_filePath, lines, Encoding.UTF8);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied while writing animals.txt. The file may be read-only.", "Access Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to write animals.txt because it is in use by another program.", "File In Use",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Appends a single new animal line to animals.txt (used by Add).
        /// </summary>
        private bool AppendAnimalToFile(Animal animal)
        {
            try
            {
                File.AppendAllText(_filePath, animal.ToFileLine() + Environment.NewLine, Encoding.UTF8);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied while appending to animals.txt.", "Access Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to append to animals.txt because it is in use by another program.", "File In Use",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while appending the record: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Mode Management (Add vs Edit)

        /// <summary>
        /// Switches the form into Add mode: ID editable, Add enabled, Save disabled.
        /// </summary>
        private void EnterAddMode()
        {
            _isEditMode = false;
            _editingId = null;

            txtAnimalId.ReadOnly = false;
            btnAdd.Enabled = true;
            btnSaveChanges.Enabled = false;

            ClearInputFields();
            lblMode.Text = "Mode: Add";
        }

        /// <summary>
        /// Switches the form into Edit mode for the given animal.
        /// ID becomes read-only, Add is disabled, Save Changes is enabled.
        /// </summary>
        private void EnterEditMode(Animal animal)
        {
            _isEditMode = true;
            _editingId = animal.ID;

            txtAnimalId.Text = animal.ID;
            txtName.Text = animal.Name;
            txtSpecies.Text = animal.Species;
            txtAge.Text = animal.Age.ToString();
            txtRecoveryScore.Text = animal.RecoveryScore.ToString();

            txtAnimalId.ReadOnly = true;
            btnAdd.Enabled = false;
            btnSaveChanges.Enabled = true;

            lblMode.Text = "Mode: Edit";
        }

        /// <summary>
        /// Clears all input text boxes.
        /// </summary>
        private void ClearInputFields()
        {
            txtAnimalId.Clear();
            txtName.Clear();
            txtSpecies.Clear();
            txtAge.Clear();
            txtRecoveryScore.Clear();
            txtSearchId.Clear();
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validates all input fields according to the project brief rules.
        /// Returns true if everything is valid; otherwise shows a message and focuses the offending control.
        /// </summary>
        private bool ValidateInputs(out string id, out string name, out string species, out int age, out int score, bool checkUniqueId)
        {
            id = txtAnimalId.Text.Trim().ToUpperInvariant();
            name = txtName.Text.Trim();
            species = txtSpecies.Text.Trim();
            age = 0;
            score = 0;

            // Animal ID
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Animal ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                return false;
            }
            if (id.Length != 7 || !id.StartsWith("WR-") || !int.TryParse(id.Substring(3), out _))
            {
                MessageBox.Show("Animal ID must be in the format WR- followed by exactly 4 digits (e.g. WR-0007).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                return false;
            }
            if (checkUniqueId && _animalList.Any(a => a.ID.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("An animal with this ID already exists. Animal ID must be unique.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnimalId.Focus();
                return false;
            }

            // Name
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (name.Length > 30)
            {
                MessageBox.Show("Name must be 1-30 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (name.Contains('|'))
            {
                MessageBox.Show("Name must not contain the pipe character (|).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Species
            if (string.IsNullOrWhiteSpace(species))
            {
                MessageBox.Show("Species is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return false;
            }
            if (species.Length > 30)
            {
                MessageBox.Show("Species must be 1-30 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return false;
            }
            if (species.Contains('|'))
            {
                MessageBox.Show("Species must not contain the pipe character (|).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecies.Focus();
                return false;
            }

            // Age
            if (!int.TryParse(txtAge.Text.Trim(), out age) || age < 0 || age > 100)
            {
                MessageBox.Show("Age must be a whole number between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }

            // Recovery Score
            if (!int.TryParse(txtRecoveryScore.Text.Trim(), out score) || score < 0 || score > 100)
            {
                MessageBox.Show("Recovery Score must be a whole number between 0 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRecoveryScore.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Feature: Add

        /// <summary>
        /// Handles the Add Animal button click.
        /// Validates, classifies, appends to file, refreshes grid and clears inputs.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out string id, out string name, out string species, out int age, out int score, checkUniqueId: true))
                return;

            var (status, housing) = Animal.Classify(score);
            var newAnimal = new Animal(id, name, species, age, score, status, housing);

            if (!AppendAnimalToFile(newAnimal))
                return;

            MessageBox.Show($"Animal added successfully.\nStatus: {status}\nHousing Unit: {housing}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshGrid();
            ClearInputFields();
            txtAnimalId.Focus();
        }

        #endregion

        #region Feature: Search and Update

        /// <summary>
        /// Handles the Search button. Performs an exact, case-insensitive ID lookup
        /// and loads the animal into the input controls (Edit mode).
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchId = txtSearchId.Text.Trim().ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(searchId))
            {
                MessageBox.Show("Please enter an Animal ID to search for.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearchId.Focus();
                return;
            }

            // Exact, case-insensitive match.
            Animal? found = _animalList.FirstOrDefault(a => a.ID.Equals(searchId, StringComparison.OrdinalIgnoreCase));

            if (found == null)
            {
                MessageBox.Show($"No animal found with ID '{searchId}'.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EnterEditMode(found);
        }

        /// <summary>
        /// Handles row selection in the grid. Loads the selected animal into the form (Edit mode).
        /// </summary>
        private void dgvAnimals_SelectionChanged(object sender, EventArgs e)
        {
            // Only react when the user has selected a row (not during data binding).
            if (dgvAnimals.SelectedRows.Count == 0)
                return;

            if (dgvAnimals.SelectedRows[0].DataBoundItem is Animal selected)
            {
                EnterEditMode(selected);
            }
        }

        /// <summary>
        /// Handles the Save Changes button (Edit mode).
        /// Re-validates (ID uniqueness not re-checked), recalculates classification,
        /// rewrites the entire file so only the edited record changes, then returns to Add mode.
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!_isEditMode || string.IsNullOrEmpty(_editingId))
            {
                MessageBox.Show("No animal is currently loaded for editing.", "Save Changes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ID uniqueness is not re-checked because the ID cannot be changed.
            if (!ValidateInputs(out string id, out string name, out string species, out int age, out int score, checkUniqueId: false))
                return;

            // Recalculate status and housing even if the score is unchanged.
            var (status, housing) = Animal.Classify(score);

            // Find and update the animal in the in-memory list.
            Animal? target = _animalList.FirstOrDefault(a => a.ID.Equals(_editingId, StringComparison.OrdinalIgnoreCase));
            if (target == null)
            {
                MessageBox.Show("The animal being edited could not be found in the current list.", "Save Changes",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EnterAddMode();
                return;
            }

            target.Name = name;
            target.Species = species;
            target.Age = age;
            target.RecoveryScore = score;
            target.Status = status;
            target.HousingUnit = housing;

            // Safely rewrite the whole file so only the selected animal is changed.
            if (!RewriteAnimalFile())
                return;

            MessageBox.Show($"Animal updated successfully.\nStatus: {status}\nHousing Unit: {housing}", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            RefreshGrid();
            EnterAddMode();
        }

        /// <summary>
        /// Handles the Clear button. Cancels editing and returns the form to Add mode.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            EnterAddMode();
        }

        #endregion

        #region Feature: Delete

        /// <summary>
        /// Handles the Delete Selected button.
        /// Requires a selected row, shows a Yes/No confirmation, then removes the record.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnimals.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal in the grid to delete.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvAnimals.SelectedRows[0].DataBoundItem is not Animal selected)
                return;

            var result = MessageBox.Show(
                $"Delete {selected.ID} ({selected.Name})? This cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            _animalList.RemoveAll(a => a.ID.Equals(selected.ID, StringComparison.OrdinalIgnoreCase));

            if (!RewriteAnimalFile())
            {
                // Reload to restore consistent state if write failed.
                RefreshGrid();
                return;
            }

            // If the deleted animal was loaded in the form, clear it.
            if (_isEditMode && _editingId != null &&
                _editingId.Equals(selected.ID, StringComparison.OrdinalIgnoreCase))
            {
                EnterAddMode();
            }

            RefreshGrid();
            MessageBox.Show("Animal deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Feature: Summary Report

        /// <summary>
        /// Handles the Generate Summary button.
        /// Calculates totals, averages and per-status counts, displays them on the form
        /// and writes summary.txt in the required format.
        /// </summary>
        private void btnSummary_Click(object sender, EventArgs e)
        {
            // Always work from the current in-memory list (which matches the file after last load/save).
            int total = _animalList.Count;

            string avgAge;
            string avgScore;

            if (total == 0)
            {
                avgAge = "N/A";
                avgScore = "N/A";
            }
            else
            {
                double ageSum = _animalList.Average(a => a.Age);
                double scoreSum = _animalList.Average(a => a.RecoveryScore);
                // Force full stop as decimal separator regardless of regional settings.
                avgAge = ageSum.ToString("F2", CultureInfo.InvariantCulture);
                avgScore = scoreSum.ToString("F2", CultureInfo.InvariantCulture);
            }

            int critical = _animalList.Count(a => a.Status == "Critical");
            int serious = _animalList.Count(a => a.Status == "Serious");
            int stable = _animalList.Count(a => a.Status == "Stable");
            int recovering = _animalList.Count(a => a.Status == "Recovering");
            int releaseReady = _animalList.Count(a => a.Status == "Release-Ready");

            // Display on the form.
            lblTotalAnimals.Text = $"Total animals: {total}";
            lblAverageAge.Text = $"Average age (years): {avgAge}";
            lblAverageScore.Text = $"Average recovery score: {avgScore}";
            lblCritical.Text = $"Critical: {critical}";
            lblSerious.Text = $"Serious: {serious}";
            lblStable.Text = $"Stable: {stable}";
            lblRecovering.Text = $"Recovering: {recovering}";
            lblReleaseReady.Text = $"Release-Ready: {releaseReady}";

            // Write summary.txt
            string summaryPath = Path.Combine(Application.StartupPath, "summary.txt");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            var sb = new StringBuilder();
            sb.AppendLine("BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
            sb.AppendLine("ANIMAL SUMMARY REPORT");
            sb.AppendLine($"Generated: {timestamp}");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Total animals: {total}");
            sb.AppendLine($"Average age (years): {avgAge}");
            sb.AppendLine($"Average recovery score: {avgScore}");
            sb.AppendLine("---------------------------------");
            sb.AppendLine("Animals per status:");
            sb.AppendLine($"Critical: {critical}");
            sb.AppendLine($"Serious: {serious}");
            sb.AppendLine($"Stable: {stable}");
            sb.AppendLine($"Recovering: {recovering}");
            sb.AppendLine($"Release-Ready: {releaseReady}");

            try
            {
                File.WriteAllText(summaryPath, sb.ToString(), Encoding.UTF8);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Permission denied while writing summary.txt.", "Access Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Unable to write summary.txt because it is in use by another program.", "File In Use",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while writing the summary: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
