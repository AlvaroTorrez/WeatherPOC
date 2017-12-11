using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.WeatherModule
{
    public class WeatherRequests : IWeatherRequests
    {
        private string URL_GET_WHEATHER = "https://query.yahooapis.com/v1/public/yql?format=json&q=";

        private List<City> listDepartament = new List<City>
        {
            new City("Cochabamba", "Bolivia"),
            new City("Oruro", "Bolivia")
        };

        public WeatherListData GetListDepartamentShortInfo()
        {
            WeatherListData result = null;
            string queryWeather = GetQueryEscape("units, location, item.condition", listDepartament);
            WebService info = WebService.GetRequest(URL_GET_WHEATHER + queryWeather).Result;
            if (info.Successful)
            {
                result = JsonConvert.DeserializeObject<WeatherListData>(info.Data);
            }
            return result;
        }

        public WeatherData GetAllInfoOneCity(string cityName, string country)
        {
            WeatherData result = null;
            string queryWeather = GetQueryEscape("*", new List<City> { new City(cityName, country) });
            WebService info = WebService.GetRequest(URL_GET_WHEATHER + queryWeather).Result;
            if (info.Successful)
            {
                result = JsonConvert.DeserializeObject<WeatherData>(info.Data);
            }
            return result;
        }

        private string GetQueryEscape(string fieldsToGet, List<City> citiesToGet)
        {
            string result = "select " + fieldsToGet + " from weather.forecast where woeid in (select woeid from geo.places(1) where text in ("
                    + String.Join(", ", citiesToGet) + ")) and u=\"c\"";
            result = System.Uri.EscapeDataString(result);
            return result;
        }
    }

    class City
    {
        private string cityName;
        private string countryName;

        public City(string cityName, string countryName)
        {
            this.cityName = cityName;
            this.countryName = countryName;
        }

        public override string ToString()
        {
            return "\"" + cityName + ", " + countryName + "\"";
        }
    }
}
