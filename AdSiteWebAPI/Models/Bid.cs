using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class Bid
    {

        [Key]
        [Required]
        public int BidId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public Advert Advert { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}
