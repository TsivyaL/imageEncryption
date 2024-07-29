using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserData
    {
        public Task<bool> CreateUser(UserDto newUser);
        public Task<bool> UpdateUser(UserDto updateUser);    
        public Task<UserDto> GetUser(int userId); 
        public Task<List<UserDto>> GetAllUsers();
        public Task<bool> ResetPassword(string password, int id);
        public Task<bool> DeleteUser(int idToDelete);


    }
}
