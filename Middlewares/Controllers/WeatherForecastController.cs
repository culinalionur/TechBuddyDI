using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     

        [HttpGet]
        public string Get()
        {
            
            return "Ok";
            
        }
        [HttpGet("Student")]
        public Student GetStudent()
        {
            return new Student()
            {
                Id = 1,
                FullName = "Onur Akýncý"
            };
        }
        [HttpPost("Student")]
        public string CreateStudent([FromBody]Student student)
        {
            return "Öðrenci oluþturuldu";
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

    }
}