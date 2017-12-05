using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using WeatherPOC_ShareCode;
using Android.Content;

namespace WeatherPOC_Android {
    [Activity(Label = "WeatherPOC_Android", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class MainActivity : Activity {

        private TextView _userEmail;
        private TextView _userPassword;
        private TextView _loginButton;
        private LoginUser loginUser;


        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            loginUser = new LoginUser();
            if (loginUser.userWasLogged()) {
                var startMainWeatherActivity = new Intent(this, typeof(MainWeatherActivity));
                StartActivity(startMainWeatherActivity);
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _loginButton = FindViewById<TextView>(Resource.Id.loginButton);
            _userEmail = FindViewById<TextView>(Resource.Id.userEmail);
            _userPassword = FindViewById<TextView>(Resource.Id.userPassword);

            _loginButton.Touch += ActionLoginTouch;
        }

        private void ActionLoginTouch(object sender, View.TouchEventArgs e)
        {
            Console.WriteLine("Action button");
        }
    }
}

