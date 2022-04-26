using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.Components.OpenWeather
{
    public class MainData
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

    }
}
