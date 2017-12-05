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
using WeatherPOC_ShareCode;

namespace WeatherPOC_Android {
    [Activity(Label = "LoginActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class LoginActivity : Activity {
        private TextView _userEmail;
        private TextView _userPassword;
        private TextView _loginButton;
        private LoginUser loginUser;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            loginUser = new LoginUser();
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            _loginButton = FindViewById<TextView>(Resource.Id.loginButton);
            _userEmail = FindViewById<TextView>(Resource.Id.userEmail);
            _userPassword = FindViewById<TextView>(Resource.Id.userPassword);

            _loginButton.Touch += ActionLoginTouch;
        }

        private void ActionLoginTouch(object sender, View.TouchEventArgs e) {
            Console.WriteLine("Action button");
            var nextActivity = new Intent(this, typeof(WeatherActivity));
            StartActivity(nextActivity);
        }
    }
}