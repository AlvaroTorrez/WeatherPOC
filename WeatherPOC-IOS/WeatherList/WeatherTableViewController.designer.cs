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

namespace WeatherPOC_IOS
{
    [Register ("WeatherTableViewController")]
    partial class WeatherTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem NavBarWeatherList { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Refresh { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem Signout { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NavBarWeatherList != null) {
                NavBarWeatherList.Dispose ();
                NavBarWeatherList = null;
            }

            if (Refresh != null) {
                Refresh.Dispose ();
                Refresh = null;
            }

            if (Signout != null) {
                Signout.Dispose ();
                Signout = null;
            }
        }
    }
}