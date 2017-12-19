using System;
using Foundation;
using Newtonsoft.Json;
using UIKit;
using WeatherPOC_IOS.Helpers;
using WeatherPOC_ShareCode;
using WeatherPOC_ShareCode.LoginModule;

namespace WeatherPOC_IOS.Login
{
    public partial class LoginViewController : UIViewController
    {
        private LoginUser loginUser;
        private LoadingOverlay loadPop;

        public LoginViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SignIn.TouchUpInside += SignIn_TouchButton;
            var bounds = UIScreen.MainScreen.Bounds;

            loadPop = new LoadingOverlay(bounds);
            View.Add(loadPop);
        }

        public override void ViewDidAppear(bool animated) {
            string jsonLogin = NSUserDefaults.StandardUserDefaults.StringForKey(GlobalConstants.LOGIN_USER_INFORMATION);
            if (!String.IsNullOrEmpty(jsonLogin)) 
            {
                loginUser = JsonConvert.DeserializeObject<LoginUser>(jsonLogin);
                if (loginUser != null && loginUser.SuccessfulLogin)
                {
                    PerformSegue("GoWeatherView", this);
                }    
            }
            loadPop.Hide();
        }

        private void SignIn_TouchButton(object sender, EventArgs ea)
        {
            loginUser = new LoginUser(new MockLoginRequests());
            loginUser.VerifyLoginUser(UserName.Text, Password.Text);

            if (loginUser.SuccessfulLogin) 
            {
                string output = JsonConvert.SerializeObject(loginUser);
                NSUserDefaults.StandardUserDefaults.SetString(output, GlobalConstants.LOGIN_USER_INFORMATION);

                PerformSegue("GoWeatherView", this);
            }
            else 
            {
                var alert = UIAlertController.Create("Login Failed", "The user or password are incorrect.", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }



    }
}

