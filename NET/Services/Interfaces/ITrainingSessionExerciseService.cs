using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface ITrainingSessionExerciseService
    {
        Task<TrainingSessionExerciseDTO> GetTrainingSessionExerciseByIdAsync(int id);
        Task<IEnumerable<TrainingSessionExerciseDTO>> GetAllTrainingSessionExercisesAsync();
        Task<TrainingSessionExerciseDTO> CreateTrainingSessionExerciseAsync(CreateTrainingSessionExerciseDTO createDto);
        Task<TrainingSessionExerciseDTO> UpdateTrainingSessionExerciseAsync(int id, TrainingSessionExerciseDTO dto);
        Task<bool> DeleteTrainingSessionExerciseAsync(int id);
    }
}