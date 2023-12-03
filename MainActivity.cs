using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Android.Content;
using Android.Views;



namespace Sprint15
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        private Button buttonToPage2;
        private Button buttonToPage3;
       

        public int nummer = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            SetContentView(Resource.Layout.activity_main);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            buttonToPage2 = FindViewById<Button>(Resource.Id.buttonToPage2);
            buttonToPage3 = FindViewById<Button>(Resource.Id.buttonToPage3);

            buttonToPage2.Click += OnButtonClickPagetwo;
            buttonToPage3.Click += OnButtonClickPagethree;

            // test

            /*var scale = Resources.DisplayMetrics.Density; // density i.e., pixels per inch or cms
            var widthPixels = Resources.DisplayMetrics.WidthPixels; // getting the width in pixels
            var widthDp = (double)(widthPixels / scale); // width in dp

            ImageView imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            imageView.LayoutParameters.Width = ViewGroup.LayoutParams.MatchParent;
            imageView.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
            imageView.RequestLayout();*/



        }

        public void OnButtonClickPagetwo(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity1));
            StartActivity(intent);
        }

        public void OnButtonClickPagethree(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
