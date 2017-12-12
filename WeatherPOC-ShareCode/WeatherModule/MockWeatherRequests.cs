using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.WeatherModule
{
    public class MockWeatherRequests : IWeatherRequests
    {
        public WeatherData GetAllInfoOneCity(string cityName, string country)
        {
            throw new NotImplementedException();
        }

        public List<WeatherData> GetListDepartamentShortInfo()
        {
            throw new NotImplementedException();
        }
    }
}
