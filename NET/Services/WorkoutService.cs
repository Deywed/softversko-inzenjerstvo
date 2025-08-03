using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Mappers;
using NET.Models;
using NET.Services.Interfaces;

namespace NET.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _context;
        public WorkoutService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<WorkoutDTO> CreateWorkoutAsync(CreateWorkoutDTO createWorkoutDto)
        {
            var workout = createWorkoutDto.ToEntity();
            workout.Exercises = new List<Exercise>();
            
            if (createWorkoutDto.Exercise == null || !createWorkoutDto.Exercise.Any())
            {
                throw new ArgumentException("At least one exercise must be provided.");
            }

            foreach (var exerciseDto in createWorkoutDto.Exercise)
            {
                var exercise = await _context.Exercises.FindAsync(exerciseDto);
                if (exercise == null) throw new ArgumentException($"Exercise with ID {exerciseDto} not found.");
                workout.Exercises.Add(exercise);
            }

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout.ToDto();
        }

        public async Task<bool> DeleteWorkoutAsync(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WorkoutDTO>> GetAllWorkoutsAsync()
        {
            var workouts = await _context.Workouts.Include(e => e.Exercises).ToListAsync();
            return workouts.Select(w => w.ToDto());
        }

        public async Task<WorkoutDTO> GetWorkoutByIdAsync(int id)
        {
            var workout = await _context.Workouts.Include(e => e.Exercises).FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null) return null!;
            return workout.ToDto();
        }

        public async Task<WorkoutDTO> UpdateWorkoutAsync(int id, UpdateWorkoutDTO updateWorkoutDto)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null) return null!;
            await workout.UpdateEntityAsync(updateWorkoutDto,_context);
            await _context.SaveChangesAsync();
            return workout.ToDto();
        }
    }
}