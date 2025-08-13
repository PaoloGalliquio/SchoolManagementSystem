namespace SchoolManagementSystem.Data.Models;

public partial class Student
{
    public string IdentityCard { get; set; } = null!;

    public string Names { get; set; } = null!;

    public string Surnames { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int IdSchool { get; set; }

    public virtual School IdSchoolNavigation { get; set; } = null!;

    public string FullName
    {
        get
        {
            return string.Join(" ", new[] { Names, Surnames }.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}
