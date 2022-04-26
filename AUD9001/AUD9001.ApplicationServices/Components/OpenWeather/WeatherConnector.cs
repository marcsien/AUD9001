using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Components.OpenWeather
{
    public class WeatherConnector : IWeatherConnector
    {
        private readonly IConfiguration _configuration;
        private readonly RestClient restClient;
        

        public WeatherConnector(IConfiguration configuration)
        {
            _configuration = configuration;
            this.restClient = new RestClient(_configuration.GetValue<string>("OpenWeatherConnection:BaseUrl"));
            
    }
        public async Task<Weather> Fetch(string city)
        {
            var request = new RestRequest("data/2.5/weather", Method.Get);
            request.AddParameter("appid", this._configuration.GetValue<string>("OpenWeatherConnection:ApiKey"));
            request.AddParameter("q",city);
            var queryResult = await restClient.ExecuteAsync(request);
            var weather = JsonConvert.DeserializeObject<Weather>(queryResult.Content);
            return weather;
        }
    }
}
