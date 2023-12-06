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
    [Activity(Label = "Activity7")]
    public class Activity7 : Activity
    {
        private Button tohomepage7;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout7);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage7 = FindViewById<Button>(Resource.Id.tohomepage7);
            tohomepage7.Click += test2;

        }

        public void test2(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}