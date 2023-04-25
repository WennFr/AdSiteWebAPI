using System.Reflection;
using AdSiteWebAPI.Data;
using AdSiteWebAPI.DTO;
using AdSiteWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
            return Ok(await _dbContext.Adverts.Include(a=> a.Picture).ToListAsync());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Advert>> GetOne(int id)
        {
            var advert = _dbContext.Adverts.FirstOrDefault(a => a.Id == id);

            if (advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(advert);
        }


        [HttpPost]
        public async Task<ActionResult<Advert>> PostAdvert(AdvertCreateDto advertCreateDto)
        {
            var advert = new Advert
            {
                Title = advertCreateDto.Title,
                Description = advertCreateDto.Description,
                StartingPrice = advertCreateDto.StartingPrice,
                StartDate = advertCreateDto.StartDate,
                EndDate = advertCreateDto.EndDate,
            };


            _dbContext.Adverts.Add(advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<Advert>> UpdateAdvert(AdvertUpdateDto advertUpdateDto)
        {

            var advertToUpdate = await _dbContext.Adverts.FirstOrDefaultAsync(a => a.Id == advertUpdateDto.Id);


            if (advertToUpdate == null)
            {
                return BadRequest("Advert not found");
            }

            advertToUpdate.Title = advertUpdateDto.Title;
            advertToUpdate.Description = advertUpdateDto.Description;
            advertToUpdate.StartingPrice = advertUpdateDto.StartingPrice;
            advertToUpdate.StartDate = advertUpdateDto.StartDate;
            advertToUpdate.EndDate = advertUpdateDto.EndDate;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Adverts.ToListAsync());

        }


        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Advert>> PatchAdvert(JsonPatchDocument advert, int id)
        {
            var advertToUpdate = await _dbContext.Adverts.FindAsync(id);

            if (advertToUpdate == null)
            {
                return BadRequest("Advert not found.");
            }

            advert.ApplyTo(advertToUpdate);
            await _dbContext.SaveChangesAsync();


            return Ok(await _dbContext.Adverts.ToListAsync());


        }









        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Advert>> Delete(int id)
        {
            var advert = await _dbContext.Adverts.FindAsync(id);

            if (advert == null)
            {
                return BadRequest("Advert not found");
            }

            _dbContext.Adverts.Remove(advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.ToListAsync());
        }














    }













}

