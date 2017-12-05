using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using WeatherPOC_ShareCode;
using Android.Content;
using System.Threading;

namespace WeatherPOC_Android {
    [Activity(Label = "WeatherPOC_Android", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class MainActivity : Activity {

        private LoginUser loginUser;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            new Thread(new ThreadStart(() => {
                Thread.Sleep(4 * 1000);
                this.RunOnUiThread(() => {
                    validateLogin();
                });
            })).Start();
        }

        private void validateLogin() {
            loginUser = new LoginUser();
            Intent nextActivity;
            if (loginUser.userWasLogged()) {
                nextActivity = new Intent(this, typeof(WeatherActivity));
            } else {
                nextActivity = new Intent(this, typeof(LoginActivity));
            }
            StartActivity(nextActivity);
        }
    }
}

