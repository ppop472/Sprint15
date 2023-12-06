using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscoveryMuseum
{
    [Activity(Label = "Activity5")]
    public class Activity5 : Activity
    {
        private Button tohomepage5;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout5);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage5 = FindViewById<Button>(Resource.Id.tohomepage5);
            tohomepage5.Click += test2;

        }

        public void test2(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}