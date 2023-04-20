using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public ICollection<Bid> Bids { get; set; }
        public ICollection<Picture> Pictures { get; set; }


    }
}
