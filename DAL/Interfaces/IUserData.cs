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
        public bool CreateUser(UserDto newUser);
        public bool UpdateUser(UserDto updateUser);    
        public bool DeleteUser(int deleteUserId);
        public UserDto GetUser(int userId); 
        public List<UserDto> GetAllUsers(); 

    }
}
