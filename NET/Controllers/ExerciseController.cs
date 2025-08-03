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
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost("AddExercise")]
        public async Task<IActionResult> AddExercise([FromBody] CreateExerciseDTO createExerciseDto)
        {
            var exercise = await _exerciseService.CreateExerciseAsync(createExerciseDto);
            if (exercise == null)
            {
                return BadRequest("Failed to create exercise.");
            }

            return Ok(exercise);
        }

        [HttpGet("GetExercises/{id}")]
        public async Task<IActionResult> GetExercises(int id)
        {
            var exercises = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercises == null)
            {
                return NotFound("Exercise not found.");
            }
            return Ok(exercises);
        }

        [HttpGet("GetAllExercises")]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercisesAsync();
            return Ok(exercises);
        }

        [HttpPut("UpdateExercise/{id}")]
        public async Task<IActionResult> UpdateExercise(int id, [FromBody] UpdateExerciseDTO updateExerciseDto)
        {
            var updatedExercise = await _exerciseService.UpdateExerciseAsync(id, updateExerciseDto);
            if (updatedExercise == null)
            {
                return NotFound("Exercise not found or update failed.");
            }
            return Ok(updatedExercise);
        }

        [HttpDelete("DeleteExercise/{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var result = await _exerciseService.DeleteExerciseAsync(id);
            if (!result)
            {
                return NotFound("Exercise not found or delete failed.");
            }
            return Ok("Exercise deleted successfully.");
        }
    }
}