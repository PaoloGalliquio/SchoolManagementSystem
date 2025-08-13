using SchoolManagementSystem.Data.DTO;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Data.Repositories;

namespace SchoolManagementSystem.Services
{
    public interface IStudentService
    {
        // Define methods that the StudentService should implement
        IEnumerable<StudentDTO> GetAllStudents();
        IEnumerable<StudentDTO> SearchStudents(string searchTerm);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        // Get all students
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            return _studentRepository.GetAll().Select(s => new StudentDTO
            {
                IdentityCard = s.IdentityCard,
                Names = s.Names,
                Surnames = s.Surnames,
                DateOfBirth = s.DateOfBirth,
                IdSchool = s.IdSchool,
                SchoolName = s.IdSchoolNavigation?.Name ?? string.Empty
            });
        }

        // Search students based on various IdentityCard, Names, Surnames, BirthDate or SchoolName
        public IEnumerable<StudentDTO> SearchStudents(string searchTerm)
        {
            var parsedSearch = ParseSearchTerm(searchTerm);

            return _studentRepository.SearchStudents(
                    parsedSearch.searchTerm,
                    parsedSearch.birthDate,
                    parsedSearch.comparisonOperator)
                .Select(s => new StudentDTO
                    {
                        IdentityCard = s.IdentityCard,
                        Names = s.Names,
                        Surnames = s.Surnames,
                        DateOfBirth = s.DateOfBirth,
                        IdSchool = s.IdSchool,
                        SchoolName = s.IdSchoolNavigation?.Name ?? string.Empty
                    });
        }

        private (string searchTerm, DateTime? birthDate, string comparisonOperator) ParseSearchTerm(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return (null, null, null);
            }

            // Verification of date format
            var dateMatch = System.Text.RegularExpressions.Regex.Match(
                input.Trim(),
                @"^((>=|<=|>|<|=)\s*(\d{4}-\d{1,2}-\d{1,2})|(\d{4}-\d{1,2}-\d{1,2})\s*(>=|<=|>|<|=))$");

            if (dateMatch.Success)
            {
                DateTime date;
                string op;

                // Case 1: Operator at the start (">= 2020-01-01")
                if (!string.IsNullOrEmpty(dateMatch.Groups[2].Value))
                {
                    op = dateMatch.Groups[2].Value;
                    if (DateTime.TryParse(dateMatch.Groups[3].Value, out date))
                    {
                        return (null, date, op);
                    }
                }
                // Case 2: Operator at the end ("2020-01-01 <=")
                else if (!string.IsNullOrEmpty(dateMatch.Groups[5].Value))
                {
                    op = dateMatch.Groups[5].Value;
                    if (DateTime.TryParse(dateMatch.Groups[4].Value, out date))
                    {
                        return (null, date, op);
                    }
                }
            }

            // If is not a date, treat as a search term
            return (input, null, null);
        }
    }
}
