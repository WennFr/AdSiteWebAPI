using AdSiteWebAPI.Data;
using AdSiteWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdSiteWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        public AdvertController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        [HttpGet]
        public async Task<ActionResult<List<Advert>>> GetAll()
        {
            return Ok(await _dbContext.Adverts.Include(a=>a.Pictures).ToListAsync());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Advert>> GetOne(int id)
        {
            //var advert = _dbContext.Adverts.Find(id);
            var advert = _dbContext.Adverts.Include(a => a.Pictures).FirstOrDefault(a => a.Id == id);

            if (advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(advert);
        }

        [HttpPut]
        public async Task<ActionResult<Advert>> UpdateAdvert(Advert advert)
        {
            // OBS: PUT Uppdaterar HELA SuperHero (ALLA properties)

            var advertToUpdate = await _dbContext.Adverts.Include(a => a.Pictures).FirstOrDefaultAsync(a => a.Id == advert.Id);


            if (advertToUpdate == null)
            {
                return BadRequest("Advert not found");
            }

            advertToUpdate.Description = advert.Description;
            advertToUpdate.StartingPrice = advert.StartingPrice;
            advertToUpdate.StartDate = advert.StartDate;
            advertToUpdate.EndDate = advert.EndDate;
            advertToUpdate.Bids = advert.Bids;
            advertToUpdate.Pictures = advert.Pictures;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Adverts.ToListAsync());

        }



    }
}
