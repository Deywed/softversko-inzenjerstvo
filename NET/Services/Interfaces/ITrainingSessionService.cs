using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface ITrainingSessionService
    {
        Task<TrainingSessionDTO> GetTrainingSessionByIdAsync(int id);
        Task<IEnumerable<TrainingSessionDTO>> GetAllTrainingSessionsAsync();
        Task<TrainingSessionDTO> CreateTrainingSessionAsync(CreateTrainingSessionDTO createTrainingSessionDto);
        Task<TrainingSessionDTO> UpdateTrainingSessionAsync(int id, UpdateTrainingSessionDTO trainingSessionDto);
        Task<bool> DeleteTrainingSessionAsync(int id);
    }
}