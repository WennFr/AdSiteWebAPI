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



    }
}
