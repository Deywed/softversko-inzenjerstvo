using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    public static class WorkoutMapper
    {
        public static WorkoutDTO ToDto(this Workout workout)
        {
            return new WorkoutDTO
            {
                Id = workout.Id,
                Name = workout.Name,
                Description = workout.Description,
                Points = workout.Points,
                Level = workout.Level.ToString(),
                Exercises = workout.Exercises.Select(e => e.ToDto()).ToList()
            };
        }

        public static Workout ToEntity(this CreateWorkoutDTO workoutDto)
        {
            return new Workout
            {
                Name = workoutDto.Name,
                Description = workoutDto.Description,
                Points = workoutDto.Points,
                Level = Enum.Parse<Level>(workoutDto.Level!),
                Exercises = new List<Exercise>()
            };
        }

        public static async Task UpdateEntityAsync(this Workout workout, UpdateWorkoutDTO updateDto, ApplicationDbContext _context)
        {
            workout.Name = updateDto.Name ?? workout.Name;
            workout.Description = updateDto.Description ?? workout.Description;
            workout.Points = updateDto.Points ?? workout.Points;
            workout.Level = updateDto.Level != null ? Enum.Parse<Level>(updateDto.Level) : workout.Level;

            if (updateDto.Exercise != null)
            {
                var existingWorkout = await _context.Workouts.Include(w => w.Exercises).FirstOrDefaultAsync(w => w.Id == workout.Id);
                existingWorkout!.Exercises.Clear();
                foreach (var exerciseId in updateDto.Exercise)
                {
                    var exercise = await _context.Exercises.FindAsync(exerciseId);
                    if (exercise == null) throw new ArgumentException($"Exercise with ID {exerciseId} not found.");
                    existingWorkout.Exercises.Add(exercise);
                }
            }
        }
    }
}