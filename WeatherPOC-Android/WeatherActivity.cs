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
        private List<WeatherData> ListOfDepartamens;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string test = Intent.GetStringExtra(GlobalConstants.USER_SESSION);
            Console.WriteLine(" Recover info ------- " + test);

            SetContentView(Resource.Layout.Weather);

            WeatherRequests request = new WeatherRequests();
            ListOfDepartamens = request.GetListDepartamentShortInfo();
            //WeatherData oneW = request.GetAllInfoOneCity("Cochabamba", "Bolivia");
            // Create your application here
            ListView _listDepartaments = FindViewById<ListView>(Resource.Id.ListDepartaments);
            _listDepartaments.Adapter = new WeatherItem(this, ListOfDepartamens);

            _listDepartaments.TextFilterEnabled = true;

            _listDepartaments.ItemClick += SelectedItem;

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Bolivia Weather";
        }

        private void SelectedItem(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = ListOfDepartamens[e.Position];
            Android.Widget.Toast.MakeText(this, t.Location.City, Android.Widget.ToastLength.Short).Show();
            Console.WriteLine("Clicked on " + t.Location.City);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        private void LogountAction()
        {
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.Clear();
            editor.Apply();
            var mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topMenus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.TitleFormatted.ToString() == "Loginout")
            {
                Toast.MakeText(this, item.TitleFormatted, ToastLength.Short).Show();
                LogountAction();
            }
            
            return base.OnOptionsItemSelected(item);
        }
    }
}