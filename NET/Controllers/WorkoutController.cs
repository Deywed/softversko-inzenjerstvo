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
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var workouts = await _workoutService.GetAllWorkoutsAsync();
            return Ok(workouts);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetWorkoutById(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);
            if (workout == null) return NotFound();
            return Ok(workout);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> CreateWorkout([FromBody] CreateWorkoutDTO createWorkoutDto)
        {
            var workout = await _workoutService.CreateWorkoutAsync(createWorkoutDto);
            return Ok(workout);
        }

        [HttpPut("Put/{id}")]
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] UpdateWorkoutDTO updateWorkoutDto)
        {
            var updatedWorkout = await _workoutService.UpdateWorkoutAsync(id, updateWorkoutDto);
            if (updatedWorkout == null) return NotFound();
            return Ok(updatedWorkout);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var result = await _workoutService.DeleteWorkoutAsync(id);
            if (!result) return NotFound();
            return Ok("Workout deleted successfully.");
        }
    }
}