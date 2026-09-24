using COURE.Dtos;
using COURE.Models;
using COURE.Utilities;

namespace COURE.Interfaces
{
    public interface ICountryRepository
    {
        Task<ResponseDetails<CountryDto?>> GetCountryByPhoneNumberAsync(string phoneNumber);
    }
}
