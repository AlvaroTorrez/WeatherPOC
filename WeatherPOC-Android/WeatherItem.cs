using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WeatherPOC_ShareCode.WeatherModule;

namespace WeatherPOC_Android
{
    class WeatherItem : BaseAdapter<WeatherData>
    {
        public List<WeatherData> Items { get; set; }
        Activity context;
        public WeatherItem(Activity context, List<WeatherData> items) : base()
        {
            this.context = context;
            this.Items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override WeatherData this[int position]
        {
            get { return Items[position]; }
        }

        public override int Count
        {
            get { return Items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = Items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.WeatherItem, null);
            view.FindViewById<TextView>(Resource.Id.DepartName).Text = item.Location.City;
            view.FindViewById<TextView>(Resource.Id.Temperature).Text = item.Item.Condition.Temp + "º" + item.Units.Temperature;
            var imageBitmap = GetImageBitmapFromUrl("http://l.yimg.com/a/i/us/we/52/" + item.Item.Condition.Code + ".gif");
            view.FindViewById<ImageView>(Resource.Id.WeatherIcon).SetImageBitmap(imageBitmap);
            return view;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }
}