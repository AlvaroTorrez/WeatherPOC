using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherPOC_ShareCode.LoginModule
{
    
    public class LoginUser
    {
        public bool SuccessfulLogin  { set; get; }
        public string UserName { set; get; }
        public string ResultInfo { set; get; }
        private ILoginRequests loginRequestService;

        public LoginUser() {
            this.loginRequestService = new LoginRequests();
        }

        public LoginUser(ILoginRequests loginRequestService) {
            this.loginRequestService = loginRequestService;
        }

        public bool VerifyLoginUser(string userName, string password) {
            if (FieldsValidator.isValidEmail(userName)) {
                this.SuccessfulLogin = loginRequestService.ValidateLoginUser(userName, password);
                this.ResultInfo = "Loggin was successful";
                this.UserName = userName;
            } else {
                this.ResultInfo = "Invalid email";
                this.SuccessfulLogin = false;
            }
            return this.SuccessfulLogin;
        }
    }
}
