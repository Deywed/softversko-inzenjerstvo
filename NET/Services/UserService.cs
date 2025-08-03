using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Services.Interfaces;
using NET.Mappers;
using Microsoft.EntityFrameworkCore;

namespace NET.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var newUser = createUserDto.ToEntity();
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser.ToDto();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users.Select(u => u.ToDto());
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user.ToDto();
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UpdateUserDTO userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.UpdateEntity(userDto);
            await _context.SaveChangesAsync();
            return user.ToDto();
        }
    }
}