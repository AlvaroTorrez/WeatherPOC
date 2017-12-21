// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WeatherPOC_IOS.WeatherDetail
{
    [Register ("ExtraPronostic")]
    partial class ExtraPronostic
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateDay { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelMaxTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelMinTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MaxTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MinTemp { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView WeatherIcon { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateDay != null) {
                DateDay.Dispose ();
                DateDay = null;
            }

            if (LabelMaxTemp != null) {
                LabelMaxTemp.Dispose ();
                LabelMaxTemp = null;
            }

            if (LabelMinTemp != null) {
                LabelMinTemp.Dispose ();
                LabelMinTemp = null;
            }

            if (MaxTemp != null) {
                MaxTemp.Dispose ();
                MaxTemp = null;
            }

            if (MinTemp != null) {
                MinTemp.Dispose ();
                MinTemp = null;
            }

            if (WeatherIcon != null) {
                WeatherIcon.Dispose ();
                WeatherIcon = null;
            }
        }
    }
}