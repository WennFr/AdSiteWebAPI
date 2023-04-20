using AdSiteWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdSiteWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Picture> Pictures { get; set; }

    }

}
