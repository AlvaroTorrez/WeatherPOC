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
        public string resultInfo { set; get; }

        public LoginUser(string userName, string password) {
            if (FieldsValidator.isValidEmail(userName)) {
                this.SuccessfulLogin = WebService.loginUserRequest(userName, password);
                this.resultInfo = "Loggin was successful";
                this.UserName = userName;
            } else {
                this.resultInfo = "Invalid email";
                this.SuccessfulLogin = false;
            }
        }
    }
}
