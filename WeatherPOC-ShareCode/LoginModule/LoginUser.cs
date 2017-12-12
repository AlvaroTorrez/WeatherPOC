using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherPOC_ShareCode.LoginModule
{

    public class LoginUser
    {
        public bool SuccessfulLogin { set; get; }
        public string UserName { set; get; }
        public string ResultInfo { set; get; }

        private ILoginRequests loginRequestService;

        public LoginUser()
        {
            this.loginRequestService = new LoginRequests();
        }

        public LoginUser(ILoginRequests loginRequestService)
        {
            this.loginRequestService = loginRequestService;
        }

        public bool VerifyLoginUser(string userName, string password)
        {
            if (FieldsValidator.IsValidEmail(userName))
            {
                this.UserName = userName;
                this.SuccessfulLogin = loginRequestService.ValidateLoginUser(userName, password);
                if (this.SuccessfulLogin)
                {
                    this.ResultInfo = "Loggin was successful";
                }
                else
                {
                    this.ResultInfo = "An error was heppening, login faild";
                }
            }
            else
            {
                this.ResultInfo = "Invalid email";
                this.SuccessfulLogin = false;
            }
            return this.SuccessfulLogin;
        }
    }
}
