using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET.Domain;
using NET.Services.Interfaces;

namespace NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] CreateCityDTO createCityDto)
        {
            if (createCityDto == null)
            {
                return BadRequest("Invalid city data.");
            }

            var city = await _cityService.CreateCityAsync(createCityDto);
            return Ok(city);
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await _cityService.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("GetCityById/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _cityService.GetCityByIdAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPut("UpdateCity/{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityDTO updateCityDto)
        {
            if (updateCityDto == null || id <= 0)
            {
                return BadRequest("Invalid city data.");
            }

            var updatedCity = await _cityService.UpdateCityAsync(id, updateCityDto);
            if (updatedCity == null)
            {
                return NotFound();
            }
            return Ok(updatedCity);
        }

        [HttpDelete("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {

            var deleted = await _cityService.DeleteCityAsync(id);
            if (!deleted)
            {
                return NotFound("City not found.");
            }
            return Ok("City deleted successfully.");
        }
    }
}