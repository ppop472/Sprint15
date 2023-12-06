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
    [Activity(Label = "Activity8")]
    public class Activity8 : Activity
    {
        private Button tohomepage8;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout8);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage8 = FindViewById<Button>(Resource.Id.tohomepage8);
            tohomepage8.Click += test2;

        }

        public void test2(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}