using DAL.Interfaces;
using MODELS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DTO;
namespace DAL.Data
{
    public class PictureData:IPictureData
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;   
         public PictureData(DBContext context, IMapper mapper) 
        {
         _context = context;
            _mapper = mapper;   
        }
         public bool CreatePicture(PictureDto newPicture)
        {
            var newPictureModel=_mapper.Map<Picture>(newPicture);   
            var createUser=_context.Users.FirstOrDefault(x=>x.Id==newPicture.CreateUserId);
            if (createUser != null) {
                createUser.UserPictures.Add(newPictureModel);  
                _context.Pictures.Add(newPictureModel);
                var isOk = _context.SaveChanges() >= 0;
                return isOk;    
            }
            return false;   
        }

        public bool DeletePicture(int deletePictureId)
        {
            var pictureToDelete = _context.Pictures.FirstOrDefault(x => x.Id == deletePictureId);
            if (pictureToDelete != null)
            {

                _context.Pictures.Remove(pictureToDelete);
                var isOk = _context.SaveChanges() >= 0;
                return isOk;
            }
            return false;
        }

        public PictureDto GetPicture(int pictureId)
        {
            throw new NotImplementedException();
        }

        public List<PictureDto> GetAllPicture()
        {
            throw new NotImplementedException();
        }
    }
}
