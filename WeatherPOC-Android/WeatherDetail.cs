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
using WeatherPOC_ShareCode;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_Android
{
    [Activity(Label = "WeatherDetail")]
    public class WeatherDetail : Activity
    {
        private string departamentName;
        private TextView _temperature;
        private TextView _weatherName;
        private TextView _windDirection;
        private TextView _windSpeed;
        private TextView _atmosHumidity;
        private TextView _atmosPressure;
        private TextView _atmosVisibility;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            departamentName =Intent.GetStringExtra(GlobalConstants.DEPARTMENT_NAME);

            SetContentView(Resource.Layout.WeatherDetail);

            _temperature = FindViewById<TextView>(Resource.Id.Temperature);
            _weatherName = FindViewById<TextView>(Resource.Id.WeatherName);
            _windDirection = FindViewById<TextView>(Resource.Id.WindDirection);
            _windSpeed = FindViewById<TextView>(Resource.Id.WindSpeed);
            _atmosHumidity = FindViewById<TextView>(Resource.Id.AtmosHumidity);
            _atmosPressure = FindViewById<TextView>(Resource.Id.AtmosPressure);
            _atmosVisibility = FindViewById<TextView>(Resource.Id.AtmosVisibility);

            this.SetVisible(false);

            Task.Run(() => LoadWeatherDetail());
        }

        private void LoadWeatherDetail() {
            string[] infoDepart = departamentName.Split(',');
            WeatherRequests request = new WeatherRequests();
            WeatherData departmentDetail = request.GetAllInfoOneCity(infoDepart[0], infoDepart[1]);

            RunOnUiThread(() => {
                _temperature.Text = departmentDetail.Item.Condition.Temp;
                _weatherName.Text = departmentDetail.Item.Condition.Text;
                this.SetVisible(true);
            });
            Task.Delay(1000);
        }
    }
}