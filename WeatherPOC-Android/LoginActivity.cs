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
using Android.Preferences;
using Newtonsoft.Json;

namespace WeatherPOC_Android {
    [Activity(Label = "LoginActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class LoginActivity : Activity {
        private TextView _userEmail;
        private TextView _userPassword;
        private TextView _loginButton;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.Login);

            _loginButton = FindViewById<TextView>(Resource.Id.loginButton);
            _userEmail = FindViewById<TextView>(Resource.Id.userEmail);
            _userPassword = FindViewById<TextView>(Resource.Id.userPassword);

            _loginButton.Touch += ActionLoginTouch;
        }

        private void ActionLoginTouch(object sender, View.TouchEventArgs e) {
            
            LoginUser loginUser = new LoginUser(_userEmail.Text, _userPassword.Text);
            if (loginUser.SuccessfulLogin) {
                string output = JsonConvert.SerializeObject(loginUser);
                Context mContext = Android.App.Application.Context;
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString(GlobalConstants.LOGIN_USER_INFORMATION, output);
                editor.Apply();

                var wheather = new Intent(this, typeof(WeatherActivity));
                wheather.PutExtra(GlobalConstants.USER_SESSION, output);
                StartActivity(wheather);
            } else {
                Console.WriteLine("Error the user is wrong");
            }
        }
    }
}