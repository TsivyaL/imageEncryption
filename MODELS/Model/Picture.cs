
using MODELS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Model
{
    public class Picture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] EncryptionPicture { get; set; }
        public DateTime dateCreate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string keyBase64 { get; set; }
        public string ivBase64 { get; set; }

    }
}
