using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers

// https://localhost:7288/api/students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ///GET https://localhost:7288/api/students/getallstudents
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = new List<string> { "John", "Jane", "Bob" };
            return Ok(students);
        }
    }
}
