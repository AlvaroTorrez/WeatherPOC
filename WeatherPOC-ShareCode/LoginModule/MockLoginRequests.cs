using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.LoginModule
{
    public class MockLoginRequests : ILoginRequests
    {
        private Dictionary<String, String> userToPassword = new Dictionary<String, String>(){
            {"a@a.com","a" }
        };

        public bool ValidateLoginUser(string userName, string password)
        {
            bool result = false;
            if (userToPassword.ContainsKey(userName))
            {
                if (userToPassword[userName] == password)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
