using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Android.Content;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Graphics;

namespace DiscoveryMuseum
{
    [Activity(Label = "Discovery Museum Plattegrond", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText editText;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private ImageView imageView;
        private float scaleFactor = 1.0f;
        private float initialDistance = 0f;
        private PointF startPoint = new PointF(0, 0);

        public int nummer = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            button1 = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            button3 = FindViewById<Button>(Resource.Id.button3);
            button4 = FindViewById<Button>(Resource.Id.button4);
            button5 = FindViewById<Button>(Resource.Id.button5);
            button6 = FindViewById<Button>(Resource.Id.button6);
            button7 = FindViewById<Button>(Resource.Id.button7);
            button8 = FindViewById<Button>(Resource.Id.button8);
            imageView = FindViewById<ImageView>(Resource.Id.imageView1);

            button1.Click += OnButtonClickPageone;
            button2.Click += OnButtonClickPagetwo;
            button3.Click += OnButtonClickPagethree;
            button4.Click += OnButtonClickPagefour;
            button5.Click += OnButtonClickPagefive;
            button6.Click += OnButtonClickPagesix;
            button7.Click += OnButtonClickPageseven;
            button8.Click += OnButtonClickPageeight;
            SetupZoomGesture();
        }

        private void SetupZoomGesture()
        {
            imageView.Touch += (object sender, View.TouchEventArgs e) =>
            {
                // Handle pinch gesture for zooming and panning
                HandlePinchZoom(e);
            };
        }

        private void HandlePinchZoom(View.TouchEventArgs e)
        {
            if (e.Event.PointerCount == 1)
            {
                switch (e.Event.Action)
                {
                    case MotionEventActions.Down:
                        startPoint.Set(e.Event.GetX(), e.Event.GetY());
                        break;

                    case MotionEventActions.Move:
                        if (imageView.ScaleX > 1.0f) // Check if zoomed in
                        {
                            float deltaX = e.Event.GetX() - startPoint.X;
                            float deltaY = e.Event.GetY() - startPoint.Y;

                            // Apply translation to the ImageView
                            imageView.TranslationX += deltaX;
                            imageView.TranslationY += deltaY;

                            startPoint.Set(e.Event.GetX(), e.Event.GetY());

                            // Limit translation to keep the image within bounds
                            LimitTranslation();
                        }
                        break;
                }
            }
            else if (e.Event.PointerCount == 2)
            {
                // Handle pinch gesture for zooming
                switch (e.Event.ActionMasked)
                {
                    case MotionEventActions.PointerDown:
                        initialDistance = CalculateDistance(e);
                        break;

                    case MotionEventActions.Pointer2Down:
                        initialDistance = CalculateDistance(e);
                        break;

                    case MotionEventActions.Move:
                        float currentDistance = CalculateDistance(e);

                        if (initialDistance > 0)
                        {
                            float delta = currentDistance - initialDistance;
                            float scale = delta / 1000.0f;

                            // Apply the scale to the ImageView
                            imageView.ScaleX += scale;
                            imageView.ScaleY += scale;

                            // Ensure the scale factor is within bounds
                            if (imageView.ScaleX < 0.1f)
                                imageView.ScaleX = 0.1f;
                            if (imageView.ScaleY < 0.1f)
                                imageView.ScaleY = 0.1f;
                            if (imageView.ScaleX > 5.0f)
                                imageView.ScaleX = 5.0f;
                            if (imageView.ScaleY > 5.0f)
                                imageView.ScaleY = 5.0f;

                            // Adjust the translation to keep the image centered
                            AdjustTranslation(scale, 0, 0);

                            initialDistance = currentDistance;
                        }
                        break;

                    case MotionEventActions.Pointer2Up:
                        initialDistance = 0f;
                        break;

                    case MotionEventActions.Up:
                        initialDistance = 0f;
                        break;
                }
            }
        }

        private float CalculateDistance(View.TouchEventArgs e)
        {
            float x = e.Event.GetX(0) - e.Event.GetX(1);
            float y = e.Event.GetY(0) - e.Event.GetY(1);
            return (float)System.Math.Sqrt(x * x + y * y);
        }

        private void AdjustTranslation(float scale, float x, float y)
        {
            float[] delta = { x, y };
            Matrix matrix = new Matrix(imageView.ImageMatrix);

            // Apply the scale factor
            matrix.PostScale(scale, scale, imageView.Width / 2, imageView.Height / 2);

            // Get the new translation values
            matrix.MapPoints(delta);

            // Adjust the translation to keep the image centered
            matrix.PostTranslate(-delta[0], -delta[1]);

            imageView.ImageMatrix = matrix;
        }

        private void LimitTranslation()
        {
            float imageWidth = imageView.Width * imageView.ScaleX;
            float imageHeight = imageView.Height * imageView.ScaleY;

            float minX = (imageView.Width - imageWidth) / 2;
            float maxX = (imageView.Width + imageWidth) / 2;

            float minY = (imageView.Height - imageHeight) / 2;
            float maxY = (imageView.Height + imageHeight) / 2;

            // Limit translation for the left edge
            if (imageView.TranslationX < minX)
                imageView.TranslationX = minX;

            // Limit translation for the right edge
            float maxTranslationX = maxX - imageView.Width;
            if (imageView.TranslationX > maxTranslationX)
                imageView.TranslationX = maxTranslationX;

            // Limit translation for the top edge
            if (imageView.TranslationY < minY)
                imageView.TranslationY = minY;

            // Limit translation for the bottom edge
            float maxTranslationY = maxY - imageView.Height;
            if (imageView.TranslationY > maxTranslationY)
                imageView.TranslationY = maxTranslationY;
        }


        public void OnButtonClickPlus(object sender, System.EventArgs e)
        {
            nummer++;
            editText.Text = Convert.ToString(nummer);
        }

        public void OnButtonClickMin(object sender, System.EventArgs e)
        {
            nummer = nummer - 1;
            editText.Text = Convert.ToString(nummer);
        }

        public void OnButtonClickPageone(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity1));
            StartActivity(intent);
        }

        public void OnButtonClickPagetwo(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }

        public void OnButtonClickPagethree(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity3));
            StartActivity(intent);
        }

        public void OnButtonClickPagefour(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity4));
            StartActivity(intent);
        }

        public void OnButtonClickPagefive(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity5));
            StartActivity(intent);
        }

        public void OnButtonClickPagesix(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity6));
            StartActivity(intent);
        }

        public void OnButtonClickPageseven(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity7));
            StartActivity(intent);
        }

        public void OnButtonClickPageeight(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Activity8));
            StartActivity(intent);
        }
    }
}