using System;

using Foundation;
using UIKit;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_IOS.WeatherList
{
    public partial class Cell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("Cell");
        public static readonly UINib Nib;

        static Cell()
        {
            Nib = UINib.FromName("Cell", NSBundle.MainBundle);
        }

        protected Cell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

        }

        public void FillInfo(WeatherData data)
        {
            this.DepartName.Text = data.Location.City;
            this.Temperature.Text = data.Item.Condition.Temp + "º" + data.Units.Temperature;
            this.WeatherIcon.Image = FromUrl("http://l.yimg.com/a/i/us/we/52/" + data.Item.Condition.Code + ".gif");

        }

        private UIImage FromUrl(string uri)
        {
            using (var url = new NSUrl(uri))
            using (var data = NSData.FromUrl(url))
                return UIImage.LoadFromData(data);
        }
    }


}
