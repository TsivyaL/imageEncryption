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
    public class PictureProfile:Profile
    {
        public PictureProfile() 
        {
            CreateMap<Picture, PictureDto>().ForMember(dest => dest.CreateUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<PictureDto, Picture>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreateUserId));

        }
    }
}
