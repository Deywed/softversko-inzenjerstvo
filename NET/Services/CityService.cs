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
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CityDTO> CreateCityAsync(CreateCityDTO createCityDto)
        {
            var newCity = createCityDto.ToEntity();
            _context.Cities.Add(newCity);
            await _context.SaveChangesAsync();
            return newCity.ToDTO();
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return false;
            }
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities.Select(c => c.ToDTO());
        }

        public async Task<CityDTO> GetCityByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return null!;
            }
            return city.ToDTO();
        }

        public async Task<CityDTO> UpdateCityAsync(int id, UpdateCityDTO cityDto)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return null!;
            }
            city.UpdateEntity(cityDto);
            await _context.SaveChangesAsync();
            return city.ToDTO();
        }
    }
}