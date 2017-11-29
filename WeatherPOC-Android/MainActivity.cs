﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace WeatherPOC_Android {
    [Activity(Label = "WeatherPOC_Android", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

