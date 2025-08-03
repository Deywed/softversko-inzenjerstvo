using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<ExerciseDTO> GetExerciseByIdAsync(int id);
        Task<IEnumerable<ExerciseDTO>> GetAllExercisesAsync();
        Task<ExerciseDTO> CreateExerciseAsync(CreateExerciseDTO createExerciseDto);
        Task<ExerciseDTO> UpdateExerciseAsync(int id, UpdateExerciseDTO exerciseDto);
        Task<bool> DeleteExerciseAsync(int id);
    }
}