
using Microsoft.AspNetCore.Mvc;
using Stefanini.Challenge.Application.Services.Interfaces;
using Stefanini.Challenge.Domain.Dtos.Request.City;

namespace Stefanini.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService) : base()
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var action = await _cityService.GetAllAsync();

                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var action = await _cityService.GetAsync(id);

                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCityRequest request)
        {
            try
            {
                var action = await _cityService.CreateAsync(request);

                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateCityRequest request)
        {
            try
            {
                var action = await _cityService.UpdateAsync(id, request);

                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var action = await _cityService.DeleteAsync(id);

                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }
    }
}
