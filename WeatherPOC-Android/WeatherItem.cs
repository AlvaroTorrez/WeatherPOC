﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_Android
{
    class WeatherItem : BaseAdapter<WeatherData>
    {
        List<WeatherData> items;
        Activity context;
        public WeatherItem(Activity context, List<WeatherData> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override WeatherData this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.WeatherItem, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = "AAA";
            view.FindViewById<TextView>(Resource.Id.Text2).Text = "BBB";
            //view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}