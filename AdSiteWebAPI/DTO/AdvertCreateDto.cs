namespace AdSiteWebAPI.DTO
{
    public class AdvertCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StartingPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
