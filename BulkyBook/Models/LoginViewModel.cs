using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BulkyBook.Models
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
   
        public string Password { get; set; }
    }
}
