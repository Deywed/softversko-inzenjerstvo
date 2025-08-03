using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;

namespace NET.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto);
        Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}