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


        // Get All ///////////////////////////////////////////////////////
        /// <summary>
        /// Retrieve All Adverts From Database
        /// </summary>
        /// <returns>
        /// Full list of Adverts
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully returned a full list of All existing Adverts
        /// </response>

        [HttpGet]
        public async Task<ActionResult<List<Advert>>> GetAll()
        {
            return Ok(await _dbContext.Adverts.Include(a=> a.Picture).ToListAsync());
        }



        // Get One ///////////////////////////////////////////////////////
        /// <summary>
        /// Retrieve One Advert From Database
        /// </summary>
        /// <returns>
        /// One Advert
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert/1
        /// </remarks>
        /// <response code="200">
        /// Successfully returned one existing Advert
        /// </response>


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Advert>> GetOne(int id)
        {
            var advert = _dbContext.Adverts.Include(a=> a.Picture).FirstOrDefault(a => a.Id == id);

            if (advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(advert);
        }



        // Post Advert ///////////////////////////////////////////////////////
        /// <summary>
        /// Create New Advert And Save To Database
        /// </summary>
        /// <returns>
        /// One Created Advert
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully created a new Advert
        /// </response>


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
                Picture = null
            };


            _dbContext.Adverts.Add(advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.Include(a => a.Picture).ToListAsync());
        }


        // Update Advert ///////////////////////////////////////////////////////
        /// <summary>
        /// Update entire Advert And Save To Database
        /// </summary>
        /// <returns>
        /// One Fully Updated Advert
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully updated the whole Advert
        /// </response>

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
            advertToUpdate.Picture = null;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Adverts.Include(a => a.Picture).ToListAsync());

        }


        // Patch Advert ///////////////////////////////////////////////////////
        /// <summary>
        /// Update One Advert Property And Save To Database
        /// </summary>
        /// <returns>
        /// Updated Advert Property
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert/1
        /// </remarks>
        /// <response code="200">
        /// Successfully Updated Advert Property
        /// </response>

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


            return Ok(await _dbContext.Adverts.Include(a=> a.Picture).ToListAsync());


        }


        // Delete ///////////////////////////////////////////////////////
        /// <summary>
        /// Delete Advert From Database
        /// </summary>
        /// <returns>
        /// Deleted Advert
        /// </returns>
        /// <remarks>
        /// Example end point: GET /api/Advert/1
        /// </remarks>
        /// <response code="200">
        /// Successfully Deleted Advert
        /// </response>


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

