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
        public byte[] keyBase64 { get; set; }
        public byte[] ivBase64 { get; set; }
        public PictureDto(byte[] EncryptionPicture, DateTime dateCreate, int CreateUserId, byte[] keyBase64, byte[] ivBase64)
        {
            this.EncryptionPicture = EncryptionPicture; 
            this.dateCreate = dateCreate;   
            this.CreateUserId = CreateUserId;   
            this.keyBase64 = keyBase64; 
            this.ivBase64 = ivBase64;   

        }
        public PictureDto() { } 
    }
}
