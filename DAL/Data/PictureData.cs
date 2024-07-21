using DAL.Interfaces;
using MODELS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DTO;
using Microsoft.EntityFrameworkCore;
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
         public async Task<bool> CreatePicture(PictureDto newPicture)
        {
            var newPictureModel=_mapper.Map<Picture>(newPicture);   
            var createUser=await _context.Users.FirstOrDefaultAsync(x=>x.Id==newPicture.CreateUserId);
            if (createUser != null) {
                createUser.UserPictures.Add(newPictureModel);  
             await   _context.Pictures.AddAsync(newPictureModel);
                var isOk = await  _context.SaveChangesAsync() >= 0;
                return isOk;    
            }
            return false;   
        }

        public async Task<bool> DeletePicture(int deletePictureId)//נגידדדדדדדדדדדדד שזה עובדדדדדדדדדד......................
        {
            var pictureToDelete =await _context.Pictures.FirstOrDefaultAsync(x => x.Id == deletePictureId);
            if (pictureToDelete != null)
            {
                _context.Pictures.Remove(pictureToDelete);
                var isOk = await   _context.SaveChangesAsync() >= 0;
                return isOk;
            }
            return false;
        }

        public async Task<PictureDto> GetPicture(int pictureId)
        {
            var pictureModel = await _context.Pictures.FirstOrDefaultAsync(x => x.Id == pictureId);
            if (pictureModel != null) { 
                var pictureToGet= _mapper.Map<PictureDto>(pictureModel);
                return pictureToGet;    
            }
            return null;
        }

        public async Task<List<PictureDto>> GetAllPicture(int userId)
        {
            var user=await _context.Users.FirstOrDefaultAsync(x=>x.Id == userId);
            if (user != null) { 
            var pictures= user.UserPictures.ToList();    
              var  picturesDto=_mapper.Map<List<PictureDto>>(pictures);
                return picturesDto; 
            }
            return null;
        }
        public async Task<List<PictureDto>> GetAllPicture(string key,string iv)
        {
            var pictureList = _context.Pictures.Where(x=>x.keyBase64==key&&x.ivBase64==iv).ToListAsync();
            if(pictureList!= null) {
              var pictureDto=_mapper.Map<List<PictureDto>>(pictureList);
                return pictureDto;  
            }
            return null;
        }
    }
}
