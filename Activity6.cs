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
    [Activity(Label = "Activity6")]
    public class Activity6 : Activity
    {
        private Button tohomepage6;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout6);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage6 = FindViewById<Button>(Resource.Id.tohomepage6);
            tohomepage6.Click += test2;

        }

        public void test2(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}