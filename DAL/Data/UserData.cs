using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using MODELS.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UserData : IUserData
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public UserData(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(UserDto newUser)
        {
            var newUserModel = _mapper.Map<User>(newUser);
            _context.Users.Add(newUserModel);
            var isOk = await _context.SaveChangesAsync() >= 0;
            return isOk;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            var usersModel = await _context.Users.ToListAsync();
            var usersDto = _mapper.Map<List<UserDto>>(usersModel);
            return usersDto;
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (userModel != null)
            {
                return _mapper.Map<UserDto>(userModel);
            }
            return null;
        }

        public async Task<bool> UpdateUser(UserDto updateUser)
        {
            // Find the user in the database
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUser.Id);
            if (userModel != null)
            {
                // Update the user properties with the new values from the DTO
                userModel.Username = updateUser.Username;
                userModel.Password = updateUser.Password;
                userModel.Email = updateUser.Email;

                // Save the changes to the database
                var isOk = await _context.SaveChangesAsync() >= 0;
                return isOk;
            }
            return false;
        }
        public async Task<bool> ResetPassword(string password, int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null) return false;

            userModel.Password = password;
            var isOk = await _context.SaveChangesAsync() >= 0;
            return isOk;
        }

        public async Task<bool> DeleteUser(int idToDelete)
        {
            var userModel = await _context.Users.FindAsync(idToDelete);
            if(userModel == null) return false;
            _context.Users.Remove(userModel);
            var isOk = await _context.SaveChangesAsync() >= 0;
            return isOk;
        }
    }
    
}
