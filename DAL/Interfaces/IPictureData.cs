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
        public bool CreatePicture(PictureDto newPicture);
        public bool DeletePicture(int deletePictureId);
        public PictureDto GetPicture(int pictureId);
        public List<PictureDto> GetAllPicture();
    }
}
