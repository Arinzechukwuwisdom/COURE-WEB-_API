using COURE.DataAccess;
using COURE.Dtos;
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

        public async Task<ResponseDetails<CountryDto?>> GetCountryByPhoneNumberAsync(string phoneNumber)
        {
            //    try
            //    {
            //        phoneNumber = phoneNumber.Trim();
            //        phoneNumber = phoneNumber.Trim('+');

            //        var country = await _context.Countries
            //            .Include(c => c.CountryDetails)
            //            //.Where(CountryDetail.)
            //            .FirstOrDefaultAsync(c =>
            //                phoneNumber.StartsWith(c.CountryCode.ToString()));

            //        if (country == null)
            //        {
            //            return ResponseDetails<CountryDto?>.Failed(
            //                message: "Country not found.",
            //                error: "No country was found for the provided phone number.",
            //                statusCode: 404);
            //        }

            //        return ResponseDetails<CountryDto?>.Success(country);
            //    }
            //    catch (Exception ex)
            //    {
            //        return ResponseDetails<CountryDto?>.Failed(
            //            message: "An error occurred while retrieving the country.",
            //            error: ex.Message,
            //            statusCode: 500);
            //    }
           
                try
                {
                    // 1. Validate input
                    if (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        return ResponseDetails<CountryDto?>.Failed(
                            message: "Invalid phone number.",
                            error: "Phone number cannot be empty.",
                            statusCode: 400);
                    }

                    // 2. Normalize phone number
                    phoneNumber = phoneNumber.Trim().TrimStart('+');

                    // 3. Find the country based on country calling code
                    var country = await _context.Countries
                        .FirstOrDefaultAsync(c =>
                            phoneNumber.StartsWith(c.CountryCode.ToString()));

                    if (country == null)
                    {
                        return ResponseDetails<CountryDto?>.Failed(
                            message: "Country not found.",
                            error: "No country was found for the provided phone number.",
                            statusCode: 404);
                    }

                    // 4. Remove the country code
                    var countryCode = country.CountryCode.ToString();

                    var remainingNumber = phoneNumber.Substring(countryCode.Length);

                // 5. Find the matching country detail/operator
                //var countryDetail = await _context.CountryDetails
                //    .Where(cd => cd.CountryId == country.Id)
                //    .AsEnumerable()
                //    .FirstOrDefaultAsync(cd =>
                //        remainingNumber.StartsWith(cd.OperatorCode));
                var countryDetail = await _context.CountryDetails
                    .FirstOrDefaultAsync(cd => cd.CountryId == country.Id);

                if (countryDetail == null)
                    {
                        return ResponseDetails<CountryDto?>.Failed(
                            message: "Operator not found.",
                            error: "No operator was found for the provided phone number.",
                            statusCode: 404);
                    }

                    // 6. Build the response DTO
                    var result = new CountryDto
                    {
                        Id = country.Id,
                        Name = country.Name,
                        CountryIso = country.CountryIso,
                        CountryCode = country.CountryCode,

                        CountryDetail = new CountryDetailDto
                        {
                            Id = countryDetail.Id,
                            Operator = countryDetail.Operator,
                            OperatorCode = countryDetail.OperatorCode
                        }
                    };

                    // 7. Return successful response
                    return ResponseDetails<CountryDto?>.Success(result);
                }
                catch (Exception ex)
                {
                    return ResponseDetails<CountryDto?>.Failed(
                        message: "An error occurred while retrieving the country.",
                        error: ex.Message,
                        statusCode: 500);
                }
            }
        }
    }
    

