using System.ComponentModel.DataAnnotations;

namespace AdSiteWebAPI.Models
{
    public class Advert
    {
        [Key]
        public int AdvertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
