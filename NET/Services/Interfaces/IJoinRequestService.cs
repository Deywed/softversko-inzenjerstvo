using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IJoinRequestService
    {
        Task<JoinRequestDTO> GetJoinRequestByIdAsync(int id);
        Task<IEnumerable<JoinRequestDTO>> GetAllJoinRequestsAsync();
        Task<JoinRequestDTO> CreateJoinRequestAsync(CreateJoinRequestDTO createJoinRequestDto);
        Task<JoinRequestDTO> UpdateJoinRequestAsync(int id, UpdateJoinRequestDTO joinRequestDto);
        Task<bool> DeleteJoinRequestAsync(int id);
    }
}