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

        }

        public void FillInfo(WeatherData data)
        {
            this.DepartName.Text = data.Location.City;
            this.Temperature.Text = data.Item.Condition.Temp + "º" + data.Units.Temperature;
            this.WeatherIcon.Image = FromUrl("http://l.yimg.com/a/i/us/we/52/" + data.Item.Condition.Code + ".gif");

        }

        private UIImage FromUrl(string uri)
        {
            var dataImage = NSData.FromUrl(new NSUrl(uri));
            return UIImage.LoadFromData(dataImage);
        }
    }


}
