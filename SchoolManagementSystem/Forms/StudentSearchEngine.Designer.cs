namespace SchoolManagementSystem.Forms
{
    partial class StudentSearchEngine
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
            lblTitle = new Label();
            StudentTable = new DataGridView();
            StudentIdCard = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            School = new DataGridViewTextBoxColumn();
            txtSearchBox = new TextBox();
            btnSearch = new Button();
            lblTotalStudents = new Label();
            lblTotalStudentsResult = new Label();
            ((System.ComponentModel.ISupportInitialize)StudentTable).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(424, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "School Management System";
            // 
            // StudentTable
            // 
            StudentTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            StudentTable.Columns.AddRange(new DataGridViewColumn[] { StudentIdCard, FullName, School });
            StudentTable.Location = new Point(12, 86);
            StudentTable.Name = "StudentTable";
            StudentTable.Size = new Size(960, 438);
            StudentTable.TabIndex = 1;
            // 
            // StudentIdCard
            // 
            StudentIdCard.HeaderText = "Student ID Card";
            StudentIdCard.Name = "StudentIdCard";
            StudentIdCard.ReadOnly = true;
            StudentIdCard.Width = 115;
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.Name = "FullName";
            FullName.ReadOnly = true;
            FullName.Width = 400;
            // 
            // School
            // 
            School.HeaderText = "School";
            School.Name = "School";
            School.ReadOnly = true;
            School.Width = 400;
            // 
            // txtSearchBox
            // 
            txtSearchBox.Location = new Point(12, 57);
            txtSearchBox.Name = "txtSearchBox";
            txtSearchBox.Size = new Size(879, 23);
            txtSearchBox.TabIndex = 2;
            txtSearchBox.KeyPress += txtSearchBox_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(897, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += SearchButton_Click;
            // 
            // lblTotalStudents
            // 
            lblTotalStudents.AutoSize = true;
            lblTotalStudents.Location = new Point(12, 537);
            lblTotalStudents.Name = "lblTotalStudents";
            lblTotalStudents.Size = new Size(98, 15);
            lblTotalStudents.TabIndex = 4;
            lblTotalStudents.Text = "Total of students:";
            // 
            // lblTotalStudentsResult
            // 
            lblTotalStudentsResult.AutoSize = true;
            lblTotalStudentsResult.Location = new Point(116, 537);
            lblTotalStudentsResult.Name = "lblTotalStudentsResult";
            lblTotalStudentsResult.Size = new Size(13, 15);
            lblTotalStudentsResult.TabIndex = 5;
            lblTotalStudentsResult.Text = "0";
            // 
            // StudentSearchEngine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(lblTotalStudentsResult);
            Controls.Add(lblTotalStudents);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchBox);
            Controls.Add(StudentTable);
            Controls.Add(lblTitle);
            Name = "StudentSearchEngine";
            Text = "StudentSearchEngine";
            ((System.ComponentModel.ISupportInitialize)StudentTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView StudentTable;
        private TextBox txtSearchBox;
        private Button btnSearch;
        private DataGridViewTextBoxColumn StudentIdCard;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn School;
        private Label lblTotalStudents;
        private Label lblTotalStudentsResult;
    }
}