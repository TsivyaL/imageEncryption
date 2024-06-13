using DAL.DTO;
using Microsoft.Identity.Client;
using MODELS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.Model;
using AutoMapper;
using DAL.DTO;
namespace DAL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
