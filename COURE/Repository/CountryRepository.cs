using COURE.DataAccess;
using COURE.Interfaces;
using COURE.Models;
using COURE.Utilities;

namespace COURE.Repository
{
    public class CountryRepository : ICountry
    {
        private readonly Context _context;
        public CountryRepository(Context context)
        {
            _context = context;
        }
        public Task<CountryDetail?> GetCountryDetailsByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var 
            }
            catch (Exception ex)
            {

            }
        }
    }
}

