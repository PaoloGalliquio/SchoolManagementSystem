using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Data.Repositories
{
    public interface IStudentRepository
    {
        // Define methods for student repository
        IEnumerable<Student> GetAll();
        Student GetByIdentityCard(string identityCard);
        IEnumerable<Student> SearchStudents(string searchTerm, DateTime? birthDate, string comparisonOperator);
        void Add(Student student);
        void Update(Student student);
        void Delete(string identityCard);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly DbContext _context;

        public StudentRepository(DbContext context)
        {
            _context = context;
        }

        // Get all students
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(s => s.IdSchoolNavigation).ToList();
        }

        // Get a student by IdentityCard
        public Student GetByIdentityCard(string identityCard)
        {
            return _context.Students.FirstOrDefault(s => s.IdentityCard == identityCard) ?? new Student();
        }

        // Search students based on Names, Surnames, BirthDate or SchoolName
        public IEnumerable<Student> SearchStudents(
            string searchTerm,
            DateTime? birthDate,
            string comparisonOperator)
        {
            var query = _context.Students
                .Include(s => s.IdSchoolNavigation)
                .AsQueryable();

            // Search by Names, Surnames or School Name
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(s =>
                    s.Names.Contains(searchTerm) ||
                    s.Surnames.Contains(searchTerm) ||
                    s.IdSchoolNavigation.Name.Contains(searchTerm));
            }

            // Search by Date of Birth with comparison operator
            if (birthDate.HasValue && !string.IsNullOrEmpty(comparisonOperator))
            {
                query = ApplyDateFilter(query, birthDate.Value, comparisonOperator);
            }

            return query.AsNoTracking().ToList();
        }

        // Check if the comparison operator is valid and apply the date filter
        private IQueryable<Student> ApplyDateFilter(
            IQueryable<Student> query,
            DateTime birthDate,
            string comparisonOperator)
        {
            return comparisonOperator switch
            {
                ">" => query.Where(s => s.DateOfBirth > birthDate),
                ">=" => query.Where(s => s.DateOfBirth >= birthDate),
                "<" => query.Where(s => s.DateOfBirth < birthDate),
                "<=" => query.Where(s => s.DateOfBirth <= birthDate),
                "=" => query.Where(s => s.DateOfBirth == birthDate),
                _ => query
            };
        }

        // Método adicional para búsqueda rápida
        public IEnumerable<Student> QuickSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return Enumerable.Empty<Student>();

            return _context.Students
                .Include(s => s.IdSchoolNavigation)
                .Where(s => s.FullName.Contains(searchText) ||
                           s.IdentityCard.Contains(searchText) ||
                           s.IdSchoolNavigation.Name.Contains(searchText))
                .AsNoTracking()
                .ToList();
        }

        // Add a new student
        public void Add(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // Update an existing student
        public void Update(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // Delete a student by IdentityCard
        public void Delete(string identityCard)
        {
            var student = GetByIdentityCard(identityCard);
            if (student == null) throw new KeyNotFoundException($"Student with IdentityCard {identityCard} not found.");
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
