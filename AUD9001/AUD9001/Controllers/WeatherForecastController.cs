using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AUD9001.ApplicationServices.Components.OpenWeather;
using Microsoft.Extensions.Configuration;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherConnector _weatherConnector;
        

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherConnector weatherConnector)
        {
            _logger = logger;
            _weatherConnector = weatherConnector;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("weather/{city}")]
        public async Task<IActionResult> GetWeather([FromRoute] string city)
        {
            var response = await this._weatherConnector.Fetch(city);
            return this.Ok(response);
        }
    }
}
