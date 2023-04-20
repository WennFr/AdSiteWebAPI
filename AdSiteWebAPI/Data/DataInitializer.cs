using AdSiteWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdSiteWebAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedUserData();
            _dbContext.SaveChanges();
            SeedAdvertData();
            _dbContext.SaveChanges();
        }


        private void SeedUserData()
        {
            if (!_dbContext.Users.Any())
            {
                _dbContext.Add(new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Password = "Hejsan123#",
                    Email = "John.Doe@hotmail.com"
                });
            }
        }

        private void SeedAdvertData()
        {
            if (!_dbContext.Adverts.Any())
            {
                _dbContext.Add(new Advert
                {
                    Title = "Used Honda Rebel 1100",
                    Description = "Selling my used Honda Rebel 1100, great speed and quality!",
                    StartingPrice = 10000,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    User = _dbContext.Users.First()
                });
            }
        }













    }

}
