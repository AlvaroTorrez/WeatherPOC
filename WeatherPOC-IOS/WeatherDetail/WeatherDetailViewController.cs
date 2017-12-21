using System;

using UIKit;
using WeatherPOC_ShareCode.WeatherModule;
using WeatherPOC_IOS.Helpers;
using Foundation;

namespace WeatherPOC_IOS.WeatherDetail
{
    public partial class WeatherDetailViewController : UIViewController
    {
        public WeatherData CurrentWeather { get; set; }
        private LoadingOverlay loadPop;

        public WeatherDetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var bounds = UIScreen.MainScreen.Bounds;
            loadPop = new LoadingOverlay(bounds);
            this.Add(loadPop);
            UIView one = ExtraPronostic.Create();
            // Perform any additional setup after loading the view, typically from a nib.
            StackExtraPronostic.AddArrangedSubview(one);

        }

        public override void ViewDidAppear(bool animated)
        {
            this.View.Hidden = true;
            LoadDataDetail();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void LoadDataDetail()
        {
            WeatherRequests request = new WeatherRequests();
            WeatherData departmentDetail = request.GetAllInfoOneCity(CurrentWeather.Location.City, CurrentWeather.Location.Country);
            InvokeOnMainThread(() => {
                this.TitleDepartment.Text = departmentDetail.Location.City + ", " + departmentDetail.Location.Country;
                this.Weatherimage.Image = FromUrl("http://l.yimg.com/a/i/us/we/52/" + departmentDetail.Item.Condition.Code + ".gif");
                this.Temperature.Text = departmentDetail.Item.Condition.Temp + "º" + departmentDetail.Units.Temperature;
                this.WeatherData.Text = departmentDetail.Item.Condition.Text;
                this.WindDirection.Text = departmentDetail.wind.Direction;
                this.WindSpeed.Text = departmentDetail.wind.Speed;
                this.AtmosHumidity.Text = departmentDetail.Atmosphere.Humidity;
                this.AtmosPressure.Text = departmentDetail.Atmosphere.Pressure;
                this.AtmosVisibility.Text = departmentDetail.Atmosphere.Visibility;
                loadPop.Hide();
                this.View.Hidden = false;
                //NavigationController.SetNavigationBarHidden(false, true);
            });
        }

        private UIImage FromUrl(string uri)
        {
            var dataImage = NSData.FromUrl(new NSUrl(uri));
            return UIImage.LoadFromData(dataImage);
        }
    }
}

