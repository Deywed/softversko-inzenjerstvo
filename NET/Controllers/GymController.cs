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
    public class GymController : ControllerBase
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        [HttpGet("GetGym/{id}")]
        public async Task<IActionResult> GetGym(int id)
        {
            var gym = await _gymService.GetGymByIdAsync(id);
            if (gym == null)
            {
                return NotFound("Gym not found.");
            }
            return Ok(gym);
        }

        [HttpGet("GetAllGyms")]
        public async Task<IActionResult> GetAllGyms()
        {
            var gyms = await _gymService.GetAllGymsAsync();
            return Ok(gyms);
        }

        [HttpPost("AddGym")]
        public async Task<IActionResult> AddGym([FromBody] CreateGymDTO createGymDto)
        {
            var gym = await _gymService.CreateGymAsync(createGymDto);
            if (gym == null)
            {
                return BadRequest("Failed to create gym.");
            }
            return Ok(gym);
        }

        [HttpPut("UpdateGym/{id}")]
        public async Task<IActionResult> UpdateGym(int id, [FromBody] UpdateGymDTO updateGymDto)
        {
            var gym = await _gymService.UpdateGymAsync(id, updateGymDto);
            if (gym == null)
            {
                return NotFound("Gym not found.");
            }
            return Ok(gym);
        }

        [HttpDelete("DeleteGym/{id}")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var result = await _gymService.DeleteGymAsync(id);
            if (!result)
            {
                return NotFound("Gym not found.");
            }
            return Ok($"Gym with ID {id} deleted successfully.");
        }
    }
}