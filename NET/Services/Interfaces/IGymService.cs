using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IGymService
    {
        Task<GymDTO> GetGymByIdAsync(int id);
        Task<IEnumerable<GymDTO>> GetAllGymsAsync();
        Task<GymDTO> CreateGymAsync(CreateGymDTO createGymDto);
        Task<GymDTO> UpdateGymAsync(int id, UpdateGymDTO gymDto);
        Task<bool> DeleteGymAsync(int id);
    }
}