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

namespace Sprint15
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {

        private Button tohomepage2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout2);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage2 = FindViewById<Button>(Resource.Id.tohomepage1);
            tohomepage2.Click += test3;


        }

        public void test3(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}