using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Dtos;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        // private variable to hold the region repository
        private readonly NZWalkDBContext nZWalkDBContext;

        //inject the region repository into the controller
        //Constructor injection of the region repository
        public RegionsController(NZWalkDBContext nZWalkDBContext)
        {

            //assign the injected region repository to the private variable
            this.nZWalkDBContext = nZWalkDBContext;
        }

        [HttpGet]
        // GET : https://localhost:7000/api/Regions
        public IActionResult GetAllRegions()
        {
            //Get all regions from the database
            var regionDomain = nZWalkDBContext.Regions.ToList();

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
        public IActionResult GetRegionById([FromRoute]Guid id)
        {
            //Get the region from the database
            //   var region = nZWalkDBContext.Regions.Find(id);
            //   find method only works on primary key, but we can use FirstOrDefault to find by any property
            var region = nZWalkDBContext.Regions.FirstOrDefault(r => r.Id == id);
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
        public IActionResult CreateRegion([FromBody] RegionDto regionDto)
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
            nZWalkDBContext.Regions.Add(regionDomain);
            nZWalkDBContext.SaveChanges();


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

    public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto UpdateRegioneDto)
    {
            //Check if the region exists in the database
            var existingRegion = nZWalkDBContext.Regions.FirstOrDefault(r => r.Id == id);

            if(existingRegion == null)
            {
                return NotFound();
            }

            //convert dto to domain model



            existingRegion.Code = UpdateRegioneDto.Code;
            existingRegion.Name = UpdateRegioneDto.Name;
            existingRegion.imageUrl = UpdateRegioneDto.imageUrl;
       
        //save to database
        nZWalkDBContext.SaveChanges();

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
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            //Check if the region exists in the database
            var existingRegion = nZWalkDBContext.Regions.FirstOrDefault(r => r.Id == id);
            if (existingRegion == null)
            {
                return NotFound();
            }
            //delete from database
            nZWalkDBContext.Regions.Remove(existingRegion);
            nZWalkDBContext.SaveChanges();
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