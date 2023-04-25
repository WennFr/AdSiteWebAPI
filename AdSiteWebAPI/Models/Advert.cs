using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AdSiteWebAPI.Models
{
    public class Advert
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        public Picture? Picture { get; set; }

        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


    }
}
