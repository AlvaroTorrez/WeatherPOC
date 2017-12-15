using System;

using UIKit;
using WeatherPOC_ShareCode.LoginModule;

namespace WeatherPOC_IOS.Login
{
    public partial class LoginViewController : UIViewController
    {
        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SignIn.TouchUpInside += SignIn_TouchButton;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void SignIn_TouchButton(object sender, EventArgs ea)
        {
            LoginUser loginUser = new LoginUser(new MockLoginRequests());
            loginUser.VerifyLoginUser(UserName.Text, Password.Text);
            if (loginUser.SuccessfulLogin) 
            {
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

