using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace AdSiteWebAPI.Models
{
    public class Bid
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public User User { get; set; }
        [Required]
        public int Amount { get; set; }

        public Advert Advert { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}
