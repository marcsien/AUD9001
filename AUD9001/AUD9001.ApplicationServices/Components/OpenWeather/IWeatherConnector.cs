using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Components.OpenWeather
{
    public interface IWeatherConnector
    {
        Task<Weather> Fetch(string city);
    }
}
