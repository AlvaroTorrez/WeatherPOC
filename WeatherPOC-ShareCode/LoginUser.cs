using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherPOC_ShareCode
{
    
    public class LoginUser
    {
        public bool SuccessfulLogin  { set; get; }
        public string UserName { set; get; }

        public LoginUser(String userName, String password) {
            this.SuccessfulLogin = WebService.loginUserRequest(userName, password);
            this.UserName = userName;
        }
    }
}
