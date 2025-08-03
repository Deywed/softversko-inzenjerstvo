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
    public class TrainingSessionController : ControllerBase
    {
        private readonly ITrainingSessionService _trainingSessionService;

        public TrainingSessionController(ITrainingSessionService trainingSessionService)
        {
            _trainingSessionService = trainingSessionService;
        }
        [HttpPost("CreateTrainingSession")]
        public async Task<IActionResult> CreateTrainingSession([FromBody] CreateTrainingSessionDTO create)
        {
            var result = await _trainingSessionService.CreateTrainingSessionAsync(create);
            return Ok(result);
        }
        [HttpGet("GetAllTrainingSessions")]
        public async Task<IActionResult> GetAllTrainingSessions()
        {
            var result = await _trainingSessionService.GetAllTrainingSessionsAsync();
            return Ok(result);
        }
        [HttpGet("GetTrainingSessionById/{id}")]
        public async Task<IActionResult> GetTrainingSessionById(int id)
        {
            var result = await _trainingSessionService.GetTrainingSessionByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("UpdateTrainingSession/{id}")]
        public async Task<IActionResult> UpdateTrainingSession(int id, [FromBody] UpdateTrainingSessionDTO update)
        {
            var result = await _trainingSessionService.UpdateTrainingSessionAsync(id, update);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("DeleteTrainingSession/{id}")]
        public async Task<IActionResult> DeleteTrainingSession(int id)
        {
            var result = await _trainingSessionService.DeleteTrainingSessionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}