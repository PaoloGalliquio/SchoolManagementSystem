using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Data.Repositories
{
    public interface ISchoolRepository
    {
        // Define methods for school repository
        IEnumerable<School> GetAll();
        School GetById(int id);
    }

    public class SchoolRepository : ISchoolRepository
    {
        private readonly DbContext _context;

        public SchoolRepository(DbContext context)
        {
            _context = context;
        }

        // Get all schools
        public IEnumerable<School> GetAll()
        {
            return _context.Schools.ToList();
        }

        // Get school by ID
        public School GetById(int id)
        {
            return _context.Schools.FirstOrDefault(s => s.Id == id) ?? new School();
        }
    }
}
