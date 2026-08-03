using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Dtos;
using NZWalksAPI.Reositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // private variable to hold the region repository
        private readonly NZWalkDBContext nZWalkDBContext;
        private readonly IRegionRepository regionRepository;

        //inject the region repository into the controller
        //Constructor injection of the region repository
        public RegionsController(NZWalkDBContext nZWalkDBContext,IRegionRepository regionRepository)
        {

            //assign the injected region repository to the private variable
            this.nZWalkDBContext = nZWalkDBContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        // GET : https://localhost:7000/api/Regions
        public async  Task<IActionResult> GetAllRegions()
        {
            //Get all regions from the database
            var regionDomain = await regionRepository.GetAllAsync();

            // domain models to dtos if needed, but for now we will return the domain models directly
            var regionsDto = new List<RegionDto>();
            //convert domain models to dtos
            //loop through each region
            foreach (var region in regionDomain)
            {   //add the region to the list of regionsDTo
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    imageUrl = region.imageUrl
                });
            }

            return Ok(regionsDto);
        }// end of GetAllRegions


        // GET: api/Regions/5
        // GET : https://localhost:7000/api/Regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute]Guid id)
        {
            //Get the region from the database
            //   var region = nZWalkDBContext.Regions.Find(id);
            //   find method only works on primary key, but we can use FirstOrDefault to find by any property
            var region = await nZWalkDBContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
            {
                return NotFound();
            }

            // convert domain model to dto
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                imageUrl = region.imageUrl
            };
            return Ok(regionDto);
        }// end of GetRegionById

        ///Create a new region
        //POST : https://localhost:7000/api/Regions
        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] RegionDto regionDto)
        {
            //convert dto to domain model
            var regionDomain = new Region()
            {
                Id = Guid.NewGuid(),
                Code = regionDto.Code,
                Name = regionDto.Name,
                imageUrl = regionDto.imageUrl
            };
            //save to database
           await  nZWalkDBContext.Regions.AddAsync(regionDomain);
          await  nZWalkDBContext.SaveChangesAsync();


            //convert domain model to dto
            var regionDtoToReturn = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                imageUrl = regionDomain.imageUrl
            };

            //return the created region
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDtoToReturn.Id }, regionDtoToReturn);
        }// end of CreateRegion

    //UPDATE an existing region
    //PUT : https://localhost:7000/api/Regions/{id}
    [HttpPut]
    [Route("{id:guid}")] //,make it type safe

    public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto UpdateRegioneDto)
    {
            //Check if the region exists in the database
            var existingRegion = await nZWalkDBContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            if(existingRegion == null)
            {
                return NotFound();
            }

            //convert dto to domain model



            existingRegion.Code = UpdateRegioneDto.Code;
            existingRegion.Name = UpdateRegioneDto.Name;
            existingRegion.imageUrl = UpdateRegioneDto.imageUrl;
       
        //save to database
       await nZWalkDBContext.SaveChangesAsync();

            //Convert domain model to dto
            var regiondto = new RegionDto()
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                imageUrl = existingRegion.imageUrl
            };

            return Ok(regiondto);
    }// end of UpdateRegion

        //DELETE an existing region
        //DELETE : https://localhost:7000/api/Regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //Check if the region exists in the database
            var existingRegion = await nZWalkDBContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (existingRegion == null)
            {
                return NotFound();
            }
            //delete from database
            // Remove does not have a async method
             nZWalkDBContext.Regions.Remove(existingRegion);
            await nZWalkDBContext.SaveChangesAsync();
            //Convert domain model to dto
            var regiondto = new RegionDto()
            {
                Id = existingRegion.Id,
                Code = existingRegion.Code,
                Name = existingRegion.Name,
                imageUrl = existingRegion.imageUrl
            };
            return Ok(regiondto);
        }// end of DeleteRegion


    }// end of RegionsController
}// end of namespace