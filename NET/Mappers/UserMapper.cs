using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.entities;
using NET.Models;

namespace NET.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDto(this User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString(),
                Statistics = StatisticsMapper.ToDto(user.Statistics),

            };
        }

        public static User ToEntity(this CreateUserDTO createUserDto)
        {
            return new User
            {

                Username = createUserDto.Username,
                FirebaseUID = createUserDto.FirebaseUID,
                Role = Role.Client, // Default role, can be changed later
                Statistics = new Statistics(), // Initialize with default statistics
                GymID = createUserDto.GymID,
            };
        }

        public static void UpdateEntity(this User user, UpdateUserDTO updateUserDto)
        {
            user.Username = updateUserDto.Username ?? user.Username;
        }
    }
}