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
    public class JoinRequestService : IJoinRequestService
    {
        private readonly ApplicationDbContext _context;

        public JoinRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JoinRequestDTO> CreateJoinRequestAsync(CreateJoinRequestDTO createJoinRequestDto)
        {
            var joinRequest = createJoinRequestDto.ToEntity();
            await _context.JoinRequests.AddAsync(joinRequest);
            await _context.SaveChangesAsync();

            return joinRequest.ToDto();
        }

        public async Task<bool> DeleteJoinRequestAsync(int id)
        {
            var joinRequest = await _context.JoinRequests.FindAsync(id);
            if (joinRequest == null)
            {
                return false;
            }

            _context.JoinRequests.Remove(joinRequest);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<JoinRequestDTO>> GetAllJoinRequestsAsync()
        {
            var joinRequests = await _context.JoinRequests.ToListAsync();
            return joinRequests.Select(jr => jr.ToDto());
        }

        public async Task<JoinRequestDTO> GetJoinRequestByIdAsync(int id)
        {
            var joinRequest = await _context.JoinRequests.FindAsync(id);
            if (joinRequest == null)
            {
                throw new Exception("Join request not found");
            }
            return joinRequest.ToDto();
        }

        public async Task<JoinRequestDTO> UpdateJoinRequestAsync(int id, UpdateJoinRequestDTO joinRequestDto)
        {
            var joinRequest = await _context.JoinRequests.FindAsync(id);
            if (joinRequest == null)
            {
                throw new Exception("Join request not found");
            }
            joinRequest.UpdateEntity(joinRequestDto);
            await _context.SaveChangesAsync();

            return joinRequest.ToDto();
        }
    }
}