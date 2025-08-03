using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.Domain;
using NET.Mappers;
using NET.Services.Interfaces;

namespace NET.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO createExerciseDto)
        {
            var newExercise = createExerciseDto.ToEntity();
            _context.Exercises.Add(newExercise);
            await _context.SaveChangesAsync();
            return newExercise.ToDto();
        }

        public async Task<bool> DeleteExerciseAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return false;
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return exercises.Select(e => e.ToDto());
        }

        public async Task<ExerciseDTO> GetExerciseByIdAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return null!;
            }

            return exercise.ToDto();
        }

        public async Task<ExerciseDTO> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDto)
        {
            var oldExercise = await _context.Exercises.FindAsync(id);
            if (oldExercise == null)
            {
                return null!;
            }
            _context.Entry(oldExercise).CurrentValues.SetValues(exerciseDto);
            await _context.SaveChangesAsync();
            return oldExercise.ToDto();
        }
    }
}