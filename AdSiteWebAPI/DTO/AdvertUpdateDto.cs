using System.ComponentModel.DataAnnotations;
using AdSiteWebAPI.Models;

namespace AdSiteWebAPI.DTO
{
    public class AdvertUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public Picture Picture { get; set; }

    }
}
