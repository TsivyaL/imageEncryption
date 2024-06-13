using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class PictureDto
    {
        public int Id { get; set; }
        public byte[] EncryptionPicture { get; set; }
        public DateTime dateCreate { get; set; }
        public int CreateUserId { get; set; }
    }
}
