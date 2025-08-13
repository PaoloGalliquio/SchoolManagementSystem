using SchoolManagementSystem.Data.Repositories;

namespace SchoolManagementSystem.Services
{
    public interface ICountryService
    {
        // Define methods for country service
        IEnumerable<string> GetAllCountries();
        string GetCountryById(int id);
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        }

        // Get all countries
        public IEnumerable<string> GetAllCountries()
        {
            return _countryRepository.GetAll().Select(c => c.Name);
        }

        // Get country by ID
        public string GetCountryById(int id)
        {
            var country = _countryRepository.GetById(id);
            return country != null ? country.Name : string.Empty;
        }
    }
}
