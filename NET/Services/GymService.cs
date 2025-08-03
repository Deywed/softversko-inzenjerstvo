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
    public class GymService : IGymService

    {

        private readonly ApplicationDbContext _context;
        public GymService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GymDTO> CreateGymAsync(CreateGymDTO createGymDto)
        {
            var newGym = createGymDto.ToEntity();
            _context.Gyms.Add(newGym);
            await _context.SaveChangesAsync();
            return newGym.ToDto();
        }

        public async Task<bool> DeleteGymAsync(int id)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
            {
                return false; // or throw an exception if preferred
            }

            _context.Gyms.Remove(gym);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GymDTO>> GetAllGymsAsync()
        {
            var allgyms = await _context.Gyms.Include(g => g.Users).ToListAsync();
            return allgyms.Select(g => g.ToDto());
        }

        public async Task<GymDTO> GetGymByIdAsync(int id)
        {
            var gym = await _context.Gyms.Include(g => g.Users).FirstOrDefaultAsync(g => g.Id == id);
            if (gym == null)
            {
                return null!; // or throw an exception if preferred
            }
            return gym.ToDto();
        }

        public async Task<GymDTO> UpdateGymAsync(int id, UpdateGymDTO gymDto)
        {
            var gym = await _context.Gyms.FindAsync(id);
            if (gym == null)
            {
                return null!; // or throw an exception if preferred
            }
            gym.UpdateEntity(gymDto);
            await _context.SaveChangesAsync();
            return gym.ToDto();
        }
    }
}