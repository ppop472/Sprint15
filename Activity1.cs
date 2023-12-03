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
using Android.Content;

namespace Sprint15
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {

        private Button tohomepage1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.layout1);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            tohomepage1 = FindViewById<Button>(Resource.Id.tohomepage1);
            tohomepage1.Click += test2;

        }

        public void test2(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

    }
}