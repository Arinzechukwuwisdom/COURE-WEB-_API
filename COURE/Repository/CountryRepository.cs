using COURE.DataAccess;
using COURE.Interfaces;
using COURE.Models;
using COURE.Utilities;
using Microsoft.EntityFrameworkCore;
using System;

namespace COURE.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly Context _context;
        public CountryRepository(Context context)
        {
            _context = context;
        }

        public async Task<ResponseDetails<Country?>> GetCountryByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                phoneNumber = phoneNumber.Trim();

                if (phoneNumber.StartsWith(""))
                {
                    phoneNumber = phoneNumber.Substring(1);
                }

                var country = await _context.Countries
                    .FirstOrDefaultAsync(c =>
                        phoneNumber.StartsWith(c.CountryCode.ToString()));

                if (country == null)
                {
                    return ResponseDetails<Country?>.Failed(
                        message: "Country not found.",
                        error: "No country was found for the provided phone number.",
                        statusCode: 404);
                }

                return ResponseDetails<Country?>.Success(country);
            }
            catch (Exception ex)
            {
                return ResponseDetails<Country?>.Failed(
                    message: "An error occurred while retrieving the country.",
                    error: ex.Message,
                    statusCode: 500);
            }
        }
    }
}
