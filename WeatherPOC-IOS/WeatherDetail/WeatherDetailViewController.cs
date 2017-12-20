using System;

using UIKit;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_IOS.WeatherDetail
{
    public partial class WeatherDetailViewController : UIViewController
    {
        public WeatherData CurrentWeather { get; set; }

        public WeatherDetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

