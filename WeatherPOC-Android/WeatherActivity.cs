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
using WeatherPOC_ShareCode.LoginModule;
using System.Threading.Tasks;

namespace WeatherPOC_Android
{
    [Activity(Label = "WeatherActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class WeatherActivity : Activity
    {
        private List<WeatherData> listOfDepartamens;
        private LoginUser loginUser;

        private ProgressDialog _progress;
        private ListView _listDepartaments;
        private Toolbar _toolbar;
        private WeatherItem adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            loginUser = JsonConvert.DeserializeObject<LoginUser>(Intent.GetStringExtra(GlobalConstants.USER_SESSION));

            SetContentView(Resource.Layout.Weather);
            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _listDepartaments = FindViewById<ListView>(Resource.Id.ListDepartaments);

            _progress = new ProgressDialog(this)
            {
                Indeterminate = true
            };
            _progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            _progress.SetMessage("Loading... Please wait...");
            _progress.SetCancelable(false);
            _progress.Show();

            listOfDepartamens = new List<WeatherData>();
            adapter = new WeatherItem(this, listOfDepartamens);
            _listDepartaments.Adapter = adapter;
            _listDepartaments.TextFilterEnabled = true;
            _listDepartaments.ItemClick += SelectedItem;

            Task.Run(() => LoadingDepartmentData());

            SetActionBar(_toolbar);
            ActionBar.Title = "Bolivia Weather";
        }

        private void LoadingDepartmentData()
        {
            
            WeatherRequests request = new WeatherRequests();
            listOfDepartamens = request.GetListDepartamentShortInfo();
            //WeatherData oneW = request.GetAllInfoOneCity("Cochabamba", "Bolivia");
            // Create your application here
            RunOnUiThread(() => {
                adapter.Items = listOfDepartamens;
                adapter.NotifyDataSetChanged();
                _progress.Dismiss();
            });
            Task.Delay(1000);
        }

        private void SelectedItem(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = listOfDepartamens[e.Position];
            Android.Widget.Toast.MakeText(this, t.Location.City, Android.Widget.ToastLength.Short).Show();
            var wheatherDetail = new Intent(this, typeof(WeatherDetail));
            wheatherDetail.PutExtra(GlobalConstants.DEPARTMENT_NAME, t.Location.City + ", " + t.Location.Country);
            StartActivity(wheatherDetail);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.topMenus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.TitleFormatted.ToString() == "Sign out")
            {
                Toast.MakeText(this, item.TitleFormatted, ToastLength.Short).Show();
                LogountAction();
            }
            else if (item.TitleFormatted.ToString() == "Reload")
            {
                RunOnUiThread(() => {
                    _progress.Show();
                });
                Task.Run(() => LoadingDepartmentData());
            }
            
            return base.OnOptionsItemSelected(item);
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
    }
}