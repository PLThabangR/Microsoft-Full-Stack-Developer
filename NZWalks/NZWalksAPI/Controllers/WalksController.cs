using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.CustomAction;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Dtos;
using NZWalksAPI.Reositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase{
    private readonly IMapper mapper;
    private readonly IWalkRepository walkRepository;
    //Consrtructor to inject mapper
    public WalksController(IMapper mapper, IWalkRepository walkRepository)
    {
        this.mapper = mapper;
        this.walkRepository = walkRepository;
    }
    [HttpPost]
// POST : https://localhost:7000/api/Walks
 [ValidateModel]
public async Task<IActionResult> AddWalkAsync([FromBody] CreateWalkDto createWalkDto)
{  
    
    //map dto to domain model
        var walkDomain = mapper.Map<Walk>(createWalkDto);

        //Add domain model to database
        walkDomain = await walkRepository.AddAsync(walkDomain);

        //map domain model back to dto
        var walkDto = mapper.Map<WalkDto>(walkDomain);

        return  Ok(walkDto); //return as 201 created
    
    
} //End of add method

    //GET : https://localhost:7000/api/Walks
    [HttpGet]
    public async Task<IActionResult> GetAllWalksAsync()
    {   //Get all walks from the database
        var walksDomain = await walkRepository.GetAllAsync();
        //convert domain model to dto list
        var walksDto = mapper.Map<List<WalkDto>>(walksDomain);
        return Ok(walksDto);
    }//End of get method

    //GET : https://localhost:7000/api/Walks/{id}
    [HttpGet]
    [Route("{id:guid}")] //,make it type safe
    public async Task<IActionResult> GetWalkAsync([FromRoute]Guid id)
    {
        //Get the region from the database
        var walkDomain = await walkRepository.GetAsync(id);
        //check if the region is null
        if (walkDomain == null)
        {
            return NotFound();
        }
        //convert domain model to dto
        var walkDto = mapper.Map<WalkDto>(walkDomain);
        return Ok(walkDto);
    }//End of get method

    //UPDATE
    //PUT : https://localhost:7000/api/Walks/{id}
    [HttpPut]
    [Route("{id:guid}")] //,make it type safe
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto)
    {   
        
    
        //MAp dto to doimain model
        var walkDomain = mapper.Map<Walk>(updateWalkDto);
        //Check if the region exists in the database the save
        walkDomain = await walkRepository.UpdateAsync(id, walkDomain);
            //Not found
        if (walkDomain == null)
        {
            return NotFound();
        }

        //convert domain model to dto
        var walkDto = mapper.Map<WalkDto>(walkDomain);
        return Ok(walkDto);
       
    }//End of update method

    //DELETE an existing region
    //DELETE : https://localhost:7000/api/Regions/{id}
    [HttpDelete]
    [Route("{id:guid}")] //,make it type safe
    public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
    {
        //Check if the region exists in the database
        var walkDomain = await walkRepository.DeleteAsync(id);
        //check if it exist
        if (walkDomain == null)
        {
            return NotFound();
        }
        //convert domain model to dto
        var walkDto = mapper.Map<WalkDto>(walkDomain);
        return Ok(walkDto);
    }//End of delete method



    }//End of class
}//End of namespace
