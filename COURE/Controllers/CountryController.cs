using COURE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COURE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountryByPhoneNumberAsync(string phoneNumber)
        {
            try
            {
                var req = await _countryRepository
                    .GetCountryByPhoneNumberAsync(phoneNumber);

                if (req.IsSuccess)
                {
                    return Ok(req);
                }

                return StatusCode(req.StatusCode, req);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
    }
}
