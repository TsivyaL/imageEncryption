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
            try
            {
                var newPictureModel = _mapper.Map<Picture>(newPicture);
                newPictureModel.Id = 0; // וודא שה-Id הוא 0 או לא מוגדר

                await _context.Pictures.AddAsync(newPictureModel);
                var isOk = await _context.SaveChangesAsync() > 0;

                if (isOk)
                {
                    var user = await _context.Users.FindAsync(newPicture.CreateUserId);
                    if (user != null)
                    {
                        user.UserPictures.Add(newPictureModel);
                        await _context.SaveChangesAsync();
                    }
                }

                return isOk;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
           

        public async Task<bool> DeletePicture(int deletePictureId)//נגידדדדדדדדדדדדד שזה עובדדדדדדדדדד......................
        {
            var pictureToDelete =await _context.Pictures.FindAsync(deletePictureId);
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
            var pictureModel = await _context.Pictures.FindAsync(pictureId);
            if (pictureModel != null) { 
                var pictureToGet= _mapper.Map<PictureDto>(pictureModel);
                return pictureToGet;    
            }
            return null;
        }

        public async Task<List<PictureDto>> GetAllPicture(int userId)
        {
            var user = await _context.Users
       .Include(u => u.UserPictures)
       .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null) { 
            var pictures= user.UserPictures.ToList();    
              var  picturesDto=_mapper.Map<List<PictureDto>>(pictures);
                return picturesDto; 
            }
            return null;
        }
        public async Task<List<PictureDto>> GetAllPicture(string key,string iv)
        {
            var pictureList =await _context.Pictures.Where(x=>x.keyBase64==key&&x.ivBase64==iv).ToListAsync();
            if(pictureList!= null) {
              var pictureDto=_mapper.Map<List<PictureDto>>(pictureList);
                return pictureDto;  
            }
            return null;
        }
    }
}
