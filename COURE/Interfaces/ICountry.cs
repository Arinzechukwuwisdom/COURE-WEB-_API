using COURE.Models;
using COURE.Utilities;

namespace COURE.Interfaces
{
    public interface ICountry
    {
        Task<CountryDetail?> GetCountryDetailsByPhoneNumberAsync(string phoneNumber);
    }
}
