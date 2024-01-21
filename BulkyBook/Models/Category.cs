using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        //Key attribute/annotation that tell Entity Framework core when you create a table 
        //you need to make sure that it is a primary key
        [Key]
        public int Id { get; set; }  // Identity Column
        [Required]
        public string Name { get; set; } //Required Field
        [DisplayName("DisplayOrder")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;




    }
}
