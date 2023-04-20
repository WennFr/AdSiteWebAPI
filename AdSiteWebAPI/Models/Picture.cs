using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class Picture
    {
        [Key]
        [Required]
        public int PictureId { get; set; }
        [Required]
        public string URL { get; set; }



    }
}
