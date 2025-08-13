using SchoolManagementSystem.Data.Repositories;

namespace SchoolManagementSystem.Services
{
    public interface ISchoolService
    {
        // Define methods that the SchoolService should implement
        IEnumerable<string> GetAllSchools();
        string GetSchoolById(int id);
    }
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
        }

        // Get all schools
        public IEnumerable<string> GetAllSchools()
        {
            return _schoolRepository.GetAll().Select(s => s.Name);
        }

        // Get school by ID
        public string GetSchoolById(int id)
        {
            var school = _schoolRepository.GetById(id);
            return school != null ? school.Name : string.Empty;
        }
    }
}
