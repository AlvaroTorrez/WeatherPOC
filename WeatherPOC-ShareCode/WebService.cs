
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode {
    public class WebService {

        public bool Successful { get; private set; }
        public string Data { get; private set; }

        private string EndPoint;


        private WebService(string endPoint) {
            this.EndPoint = endPoint;
        }

        private void FillInfoConnectionFaild() {
            throw new NotImplementedException();
        }

        public static async Task<WebService> GetRequest(string url) {
            WebService info = new WebService(url);
            bool isConnected = CrossConnectivity.Current.IsConnected;
            if (isConnected) {
                // do the conection
                try
                {
                    HttpClient client = new HttpClient();
                    HttpResponseMessage result = await client.GetAsync(url).ConfigureAwait(false);
                    if (result.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        info.Successful = true;
                        info.Data = await result.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception e) {

                }
                
            } else {
                info.Successful = false;
                info.FillInfoConnectionFaild();
            }
            return info;
        }


    }
}
