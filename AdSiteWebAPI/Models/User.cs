using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class User
    {

        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public string Email { get; set; }

    }
}
