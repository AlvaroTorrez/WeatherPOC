using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherPOC_ShareCode
{
    
    public class LoginUser
    {

        public LoginUser() {
            // Loading some cache if there is.
        }

        public bool canLogin(String userName, String password) {
            // In this section we use the API to validate the user.
            return true;
        }

        public bool userWasLogged() {
            return false;
        }
    }
}
