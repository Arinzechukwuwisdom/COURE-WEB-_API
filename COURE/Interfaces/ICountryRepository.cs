using COURE.Models;
using COURE.Utilities;

namespace COURE.Interfaces
{
    public interface ICountryRepository
    {
        Task<ResponseDetails<Country?>> GetCountryByPhoneNumberAsync(string phoneNumber);
    }
}
