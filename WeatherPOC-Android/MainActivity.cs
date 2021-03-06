﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using WeatherPOC_ShareCode;
using WeatherPOC_ShareCode.LoginModule;
using Android.Content;
using System.Threading;
using Android.Preferences;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WeatherPOC_Android
{
    [Activity(Label = "WeatherPOC_Android", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", NoHistory = true)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Task.Run(() => ValidateLogin());
        }

        private void ValidateLogin()
        {
            // Retrive the keeped information of the session
            Context mContext = Android.App.Application.Context;
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            string loginInfo = prefs.GetString(GlobalConstants.LOGIN_USER_INFORMATION, "");

            LoginUser loginUser = JsonConvert.DeserializeObject<LoginUser>(loginInfo);

            Intent nextActivity;
            if ((loginUser != null) && loginUser.SuccessfulLogin)
            {
                nextActivity = new Intent(this, typeof(WeatherActivity));
                nextActivity.PutExtra(GlobalConstants.USER_SESSION, loginInfo);
            }
            else
            {
                nextActivity = new Intent(this, typeof(LoginActivity));
            }
            StartActivity(nextActivity);
        }
    }
}

