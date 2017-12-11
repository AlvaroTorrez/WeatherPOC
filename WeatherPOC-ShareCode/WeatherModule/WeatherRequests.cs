using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.WeatherModule
{
    public class WeatherRequests : IWeatherRequests {
        private string URL_GET_WHEATHER = "https://query.yahooapis.com/v1/public/yql?format=json&q=";
    }
}
