using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdSiteWebAPI.Models
{
    public class Picture
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string URL { get; set; }

    }
}
