using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class Picture
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string URL { get; set; }
        public Advert Advert { get; set; }

    }
}
