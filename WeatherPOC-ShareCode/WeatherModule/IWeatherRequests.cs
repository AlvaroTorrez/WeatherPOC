﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.WeatherModule
{
    public interface IWeatherRequests
    {
        List<WeatherData> GetListDepartamentShortInfo();
        WeatherData GetAllInfoOneCity(string cityName, string country);
    }
}
