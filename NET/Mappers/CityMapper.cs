using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class CityMapper
    {
        public static CityDTO ToDTO(this City city)
        {
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                Address = city.Address
            };
        }

        public static City ToEntity(this CreateCityDTO createCityDTO)
        {
            return new City
            {
                Name = createCityDTO.Name,
                Address = createCityDTO.Address
            };
        }

        public static void UpdateEntity(this City entity, UpdateCityDTO dto)
        {
            entity.Name = dto.Name ?? entity.Name;
            entity.Address = dto.Address ?? entity.Address;
        }
    }
}