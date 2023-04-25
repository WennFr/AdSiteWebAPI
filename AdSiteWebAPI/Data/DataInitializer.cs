using AdSiteWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.WebRequestMethods;

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
            SeedBidData();
            _dbContext.SaveChanges();
        }


        private void SeedUserData()
        {
            if (!_dbContext.Users.Any())
            {
                _dbContext.Add(new UserClient()
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
                    Title = "Honda Rebel 1100",
                    Description = "Brand new Honda Rebel 1100, great speed and quality!",
                    StartingPrice = 13000,
                    StartDate = DateTime.Now.AddDays(-1),
                    EndDate = DateTime.Now.AddDays(6),
                    Picture = new Picture
                    {
                        URL = "https://fakeimg.pl/300x200/?text=Advert%20Image&font=lobster"
                    }
                
                });

            }
        }

        private void SeedBidData()
        {
            if (!_dbContext.Bids.Any())
            {
                _dbContext.Add(new Bid
                {
                    Amount = 14000,
                    UserClient = _dbContext.Users.First(),
                    Advert = _dbContext.Adverts.First(),
                    Date = DateTime.Now
                });
            }
        }
      


    }

}
