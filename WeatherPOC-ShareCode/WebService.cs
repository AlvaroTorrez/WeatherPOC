﻿
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode {
    class WebService {
        private const string LOGIN_SERVICE_URL = "test";

        public string data { set; get; }

        
        private WebService(string endPoint) {
            bool co = CrossConnectivity.Current.IsConnected;
            System.Diagnostics.Debug.WriteLine(" ++++ IsConnected " + co);
        }
    }
}
