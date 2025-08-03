using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<WorkoutDTO> GetWorkoutByIdAsync(int id);
        Task<IEnumerable<WorkoutDTO>> GetAllWorkoutsAsync();
        Task<WorkoutDTO> CreateWorkoutAsync(CreateWorkoutDTO createWorkoutDto);
        Task<WorkoutDTO> UpdateWorkoutAsync(int id, UpdateWorkoutDTO workoutDto);
        Task<bool> DeleteWorkoutAsync(int id);
    }
}