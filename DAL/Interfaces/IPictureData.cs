using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPictureData
    {
        public  Task<bool> CreatePicture(PictureDto newPicture);
        public Task<bool> DeletePicture(int deletePictureId);
        public Task<PictureDto> GetPicture(int pictureId);
        public Task<List<PictureDto>> GetAllPicture(int userId);
        public Task<List<PictureDto>> GetAllPicture(string key, string iv);

    }
}
