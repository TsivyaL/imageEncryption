
using MODELS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Model
{
    public class User
    {
        public User() {
            UserPictures=new LinkedList<Picture>(); 
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsManager { get; set; } 
        public ICollection<Picture> UserPictures { get; set; }
    }
}
