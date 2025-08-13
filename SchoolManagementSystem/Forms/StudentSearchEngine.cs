using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Services;

namespace SchoolManagementSystem.Forms
{
    public partial class StudentSearchEngine : Form
    {
        private readonly IStudentService _studentService;

        public StudentSearchEngine(IStudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
            ConfigureStudentTable();
            LoadStudents();
        }

        private void ConfigureStudentTable()
        {
            // Configuration of the DataGridView
            StudentTable.DataSource = null;
            StudentTable.Columns.Clear();
            StudentTable.AutoGenerateColumns = false;
            StudentTable.AllowUserToAddRows = false;
            StudentTable.ReadOnly = true;

            // Configuration of columns
            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "colIdentityCard",
                    DataPropertyName = "IdentityCard",
                    HeaderText = "Student ID Card",
                    Width = 115
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colFullName",
                    DataPropertyName = "FullName",
                    HeaderText = "Full Name",
                    Width = 400
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "colSchoolName",
                    DataPropertyName = "SchoolName",
                    HeaderText = "School",
                    Width = 400
                }
            };

            StudentTable.Columns.AddRange(columns);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearchBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    LoadStudents();
                    return;
                }

                var students = await Task.Run(() => _studentService.SearchStudents(searchTerm));
                BindDataToGrid(students);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading students: {ex.Message}");
            }
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                BindDataToGrid(students);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Error loading students: {ex.Message}");
            }
        }

        private void BindDataToGrid(IEnumerable<StudentDTO> students)
        {
            // Check if the DataGridView requires invoking to update the UI thread
            if (StudentTable.InvokeRequired)
            {
                StudentTable.Invoke(new Action(() => BindDataToGrid(students)));
                return;
            }

            // Suspend layout to improve performance while updating the DataGridView
            StudentTable.SuspendLayout();
            StudentTable.DataSource = null;
            StudentTable.DataSource = students?.ToList();
            StudentTable.Refresh();
            StudentTable.ResumeLayout();
            lblTotalStudentsResult.Text = students?.Count().ToString();
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
