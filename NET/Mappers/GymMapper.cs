using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class GymMapper
    {
        public static GymDTO ToDto(this Gym gym)
        {
            return new GymDTO
            {
                Id = gym.Id,
                Name = gym.Name,
                Location = gym.Location,
                CityId = gym.CityId.HasValue ? gym.CityId.Value : 0, // Assuming CityId is required
                Users = gym.Users?.Select(u => u.ToDto()).ToList() // Assuming Users is a collection of User entities
            };
        }

        public static Gym ToEntity(this CreateGymDTO createGymDto)
        {
            return new Gym
            {
                Name = createGymDto.Name,
                Location = createGymDto.Location,
                CityId = createGymDto.CityId,
            };
        }

        public static Gym UpdateEntity(this Gym gym, UpdateGymDTO updateGymDto)
        {
                gym.Name = updateGymDto.Name ?? gym.Name;
                gym.Location = updateGymDto.Location ?? gym.Location;
                gym.CityId = updateGymDto.CityId.HasValue ? updateGymDto.CityId.Value : gym.CityId;
            return gym;
        }
    }
}