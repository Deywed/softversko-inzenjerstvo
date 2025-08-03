using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface ICityService
    {
        Task<CityDTO> GetCityByIdAsync(int id);
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> CreateCityAsync(CreateCityDTO createCityDto);
        Task<CityDTO> UpdateCityAsync(int id, UpdateCityDTO cityDto);
        Task<bool> DeleteCityAsync(int id);
    }
}