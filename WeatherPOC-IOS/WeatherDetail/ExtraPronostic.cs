using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;

namespace WeatherPOC_IOS.WeatherDetail
{
    public partial class ExtraPronostic : UIView
    {
        public ExtraPronostic (IntPtr handle) : base (handle)
        {
        }

        public static ExtraPronostic Create()
        {

            var arr = NSBundle.MainBundle.LoadNib("ExtraPronostic", null, null);
            var v = Runtime.GetNSObject<ExtraPronostic>(arr.ValueAt(0));
            return v;
        }

        public override void AwakeFromNib()
        {

            this.DateDay.Text = "hello f";
        }
    }
}