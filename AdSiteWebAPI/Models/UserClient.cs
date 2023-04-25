using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class UserClient
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }


    }
}
