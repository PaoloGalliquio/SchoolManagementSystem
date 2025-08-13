using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Data.Repositories
{
    public interface ICountryRepository
    {
        // Define methods for country repository
        IEnumerable<Country> GetAll();
        Country GetById(int id);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly DbContext _context;

        public CountryRepository(DbContext context)
        {
            _context = context;
        }

        // Get all countries
        public IEnumerable<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        // Get country by ID
        public Country GetById(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id) ?? new Country();
        }
    }
}
