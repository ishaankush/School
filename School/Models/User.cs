using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
