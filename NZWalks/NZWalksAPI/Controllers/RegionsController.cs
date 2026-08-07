using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalksAPI.CustomAction;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Dtos;
using NZWalksAPI.Reositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//Attribute 
    public class RegionsController : ControllerBase
    {
        // private variable to hold the region repositor
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        //inject the region repository into the controller
        //Constructor injection of the region repository
        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {

            //assign the injected region repository to the private variable
           
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        // GET : https://localhost:7000/api/Regions
        public async  Task<IActionResult> GetAllRegions()
        {
            //Get all regions from the database
            var regionDomain = await regionRepository.GetAllAsync();

            // domain models to dtos if needed, but for now we will return the domain models directly
            
            ///Use auuto mapper this replace the need for a loop
            var regionsDto = mapper.Map<List<RegionDto>>(regionDomain);
            

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
            var region = await regionRepository.GetAsync(id);
            //check if the region is null
            if (region == null)
            {   //return not found
                return NotFound();
            }

            // convert domain model to dto
            ///Use auuto mapper this replace the need for a loop
           var regionDto = mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }// end of GetRegionById

        ///Create a new region
        //POST : https://localhost:7000/api/Regions
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
           
                //Validate the incoming request


                //convert dto to domain model
                var regionDomain = mapper.Map<Region>(addRegionDto);
                //save to database
                regionDomain = await regionRepository.AddAsync(regionDomain);


                //convert domain model to dto
                var regionDtoToReturn = mapper.Map<RegionDto>(regionDomain);

                //return the created region
                return CreatedAtAction(nameof(GetRegionById), new { id = regionDtoToReturn.Id }, regionDtoToReturn);

        

         
        }// end of CreateRegion

    //UPDATE an existing region
    //PUT : https://localhost:7000/api/Regions/{id}
    [HttpPut]
    [Route("{id:guid}")] //,make it type safe
        [ValidateModel]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
    {
            
                //MAp dto to doimain model
                var regionDomain = mapper.Map<Region>(updateRegionDto);


                //Check if the region exists in the database the save
                var existingRegion = await regionRepository.UpdateAsync(id, regionDomain);

                if (existingRegion == null)
                {
                    return NotFound();
                }

                //convert dto to domain model

                //Convert domain model to dto
                var regiondto = mapper.Map<RegionDto>(existingRegion);

                return Ok(regiondto);
           

            
    }// end of UpdateRegion

        //DELETE an existing region
        //DELETE : https://localhost:7000/api/Regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //Check if the region exists in the database
            var existingRegion = await regionRepository.DeleteAsync(id);
            //check if it exist
            if (existingRegion == null)
            {
                return NotFound();
            }
            //delete from database
            // Remove does not have a async method
             
            //Convert domain model to dto
            var regiondto = mapper.Map<RegionDto>(existingRegion);
            return Ok(regiondto);
        }// end of DeleteRegion


    }// end of RegionsController
}// end of namespace