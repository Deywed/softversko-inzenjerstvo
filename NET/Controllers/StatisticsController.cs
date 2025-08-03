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
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }
        [HttpGet("GetAllStatistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var statistics = await _statisticsService.GetAllStatisticsAsync();
            return Ok(statistics);
        }
        // [HttpGet("GetStatisticsByUserId/{userId}")]
        // public async Task<IActionResult> GetUserStatistics(int userId)
        // {
        //     var userStatistics = await _statisticsService.GetStatisticsByUserId(userId);
        //     if (userStatistics == null)
        //     {
        //         return NotFound($"Statistics for user with ID {userId} not found.");
        //     }
        //     return Ok(userStatistics);
        // }

        [HttpPost("CreateStatistics")]
        public async Task<IActionResult> CreateStatistics([FromBody] CreateStatisticsDTO createStatisticsDto)
        {
            var createdStatistics = await _statisticsService.CreateStatisticsAsync(createStatisticsDto);
            return Ok(createdStatistics);
        }

        [HttpPut("UpdateStatistics/{id}")]
        public async Task<IActionResult> UpdateStatistics(int id, [FromBody] UpdateStatisticsDTO updateStatisticsDto)
        {
            var updatedStatistics = await _statisticsService.UpdateStatisticsAsync(id, updateStatisticsDto);
            if (updatedStatistics == null)
            {
                return NotFound($"Statistics with ID {id} not found.");
            }
            return Ok(updatedStatistics);
        }

        [HttpDelete("DeleteStatistics/{id}")]
        public async Task<IActionResult> DeleteStatistics(int id)
        {
            var result = await _statisticsService.DeleteStatisticsAsync(id);
            if (!result)
            {
                return NotFound($"Statistics with ID {id} not found.");
            }
            return NoContent();
        }
    }
}