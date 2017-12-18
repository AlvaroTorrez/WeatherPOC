using Foundation;
using System;
using UIKit;

namespace WeatherPOC_IOS
{
    public partial class WeatherListViewController : UIViewController
    {
        public WeatherListViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad() 
        {
            this.Signout.Clicked += PerforLogout;
        }

        private void PerforLogout(object sender, EventArgs e)
        {
            NSUserDefaults.StandardUserDefaults.RemovePersistentDomain(NSBundle.MainBundle.BundleIdentifier);
            NSUserDefaults.StandardUserDefaults.Synchronize();
            PerformSegue("GoLogin", this);

        }
    }
}