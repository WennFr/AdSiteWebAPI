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

				_dbContext.Add(new Advert
				{
					Title = "Mountain Bike Sale",
					Description = "Get ready for your next adventure with our high-performance mountain bikes! Whether you're tackling steep trails or exploring off-road terrains, our bikes will provide the ultimate riding experience.",
					StartingPrice = 900,
					StartDate = DateTime.Now.AddDays(-2),
					EndDate = DateTime.Now.AddDays(8),
					Picture = new Picture
					{
						URL = "https://fakeimg.pl/300x200/?text=Mountain%20Bike&font=lobster"
					}
				});


				_dbContext.Add(new Advert
				{
					Title = "Luxury Watch Clearance",
					Description = "Upgrade your style with our luxury watches collection. From elegant designs to exquisite craftsmanship, our watches will add a touch of sophistication to your outfits. Don't miss out on our clearance sale!",
					StartingPrice = 5000,
					StartDate = DateTime.Now.AddDays(-3),
					EndDate = DateTime.Now.AddDays(5),
					Picture = new Picture
					{
						URL = "https://fakeimg.pl/300x200/?text=Luxury%20Watch&font=lobster"
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
