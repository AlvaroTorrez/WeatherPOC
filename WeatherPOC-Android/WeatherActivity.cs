using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Preferences;

using WeatherPOC_ShareCode;
using Newtonsoft.Json;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_Android
{
    [Activity(Label = "WeatherActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class WeatherActivity : Activity
    {
        private Button _Logout;
        private TextView _TempJson;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string test = Intent.GetStringExtra(GlobalConstants.USER_SESSION);
            Console.WriteLine(" Recover info ------- " + test);

            SetContentView(Resource.Layout.Weather);

            _Logout = FindViewById<Button>(Resource.Id.Logout);
            _TempJson = FindViewById<TextView>(Resource.Id.tempJson);

            _Logout.Click += logountAction;
            WeatherRequests request = new WeatherRequests();
            WeatherListData listW = request.GetListDepartamentShortInfo();
            WeatherData oneW = request.GetAllInfoOneCity("Cochabamba", "Bolivia");
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private void logountAction(object sender, EventArgs e) {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.Clear();
            editor.Apply();
            var mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }
    }
}