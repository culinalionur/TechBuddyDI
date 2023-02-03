using Microsoft.AspNetCore.Mvc;

namespace TechBuddyDependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly INumGenerator2 _numGenerator2;
        private readonly INumGenerator _numGenerator;

        public WeatherForecastController(INumGenerator2 numGenerator2,INumGenerator numGenerator)
        {
            _numGenerator2 = numGenerator2;
           _numGenerator = numGenerator;
        }

        [HttpGet]
        public string Get()
        {
            int random1 = _numGenerator.RandomValue;
            int random2 = _numGenerator2.GetNumGeneratorRandomNumber();
            return $"NumGenerator2.RandomValue = {random1}, NumGenerator.RandomValue = {random2}" ;
         }
    }
}