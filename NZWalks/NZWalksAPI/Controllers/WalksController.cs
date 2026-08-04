using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }



    }//End of class
}//End of namespace
