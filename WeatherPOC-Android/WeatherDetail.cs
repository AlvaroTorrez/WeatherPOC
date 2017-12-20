using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using WeatherPOC_Android.Helper;
using WeatherPOC_ShareCode;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_Android
{
    [Activity(Label = "WeatherDetail")]
    public class WeatherDetail : Activity
    {
        private string departmentName;
        private TextView _temperature;
        private ImageView _imageWeather;
        private TextView _titleDepartamen;
        private TextView _weatherName;
        private TextView _windDirection;
        private TextView _windSpeed;
        private TextView _atmosHumidity;
        private TextView _atmosPressure;
        private TextView _atmosVisibility;
        private ProgressDialog _progress;
        private LinearLayout _RootLayoutl;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            departmentName =Intent.GetStringExtra(GlobalConstants.DEPARTMENT_NAME);

            SetContentView(Resource.Layout.WeatherDetail);

            _temperature = FindViewById<TextView>(Resource.Id.Temperature);
            _imageWeather = FindViewById<ImageView>(Resource.Id.ImagenWeather);
            _weatherName = FindViewById<TextView>(Resource.Id.WeatherName);
            _titleDepartamen = FindViewById<TextView>(Resource.Id.TitleDepartment);
            _windDirection = FindViewById<TextView>(Resource.Id.WindDirection);
            _windSpeed = FindViewById<TextView>(Resource.Id.WindSpeed);
            _atmosHumidity = FindViewById<TextView>(Resource.Id.AtmosHumidity);
            _atmosPressure = FindViewById<TextView>(Resource.Id.AtmosPressure);
            _atmosVisibility = FindViewById<TextView>(Resource.Id.AtmosVisibility);

            _RootLayoutl = FindViewById<LinearLayout>(Resource.Id.DetailView);
            _RootLayoutl.Visibility = ViewStates.Invisible;
            _progress = new ProgressDialog(this)
            {
                Indeterminate = true
            };
            _progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            _progress.SetMessage("Loading... Please wait...");
            _progress.SetCancelable(false);
            _progress.Show();
            Task.Run(() => LoadWeatherDetail());

        }

        private void LoadWeatherDetail() {
            string[] infoDepart = departmentName.Split(',');
            WeatherRequests request = new WeatherRequests();
            WeatherData departmentDetail = request.GetAllInfoOneCity(infoDepart[0], infoDepart[1]);

            RunOnUiThread(() => {
                _temperature.Text = departmentDetail.Item.Condition.Temp + "°" + departmentDetail.Units.Temperature;
                var imageBitmap = HelperImage.GetImageBitmapFromUrl("http://l.yimg.com/a/i/us/we/52/" + departmentDetail.Item.Condition.Code + ".gif");
                _imageWeather.SetImageBitmap(imageBitmap);
                _weatherName.Text = departmentDetail.Item.Condition.Text;
                _titleDepartamen.Text = departmentDetail.Location.City + ", " + departmentDetail.Location.Country;
                _windDirection.Text = departmentDetail.wind.Direction;
                _windSpeed.Text = departmentDetail.wind.Speed;
                _atmosHumidity.Text = departmentDetail.Atmosphere.Humidity;
                _atmosPressure.Text = departmentDetail.Atmosphere.Pressure;
                _atmosVisibility.Text = departmentDetail.Atmosphere.Visibility;
                _progress.Dismiss();
                _RootLayoutl.Visibility = ViewStates.Visible;
            });
            Task.Delay(1000);
        }
    }
}