using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlingController : ControllerBase
    {
        [HttpGet("division")]
        public IActionResult  Getdivision(int numerator,int denominator)
        {
            try
            {
                var result = numerator / denominator;
                return Ok("Here is the results "+ result);
                
            }catch(Exception ex)
            {     Console.WriteLine(ex.Message);  
                return BadRequest(ex.Message);
            }
        }
    }
}