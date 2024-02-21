using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
//using Android;
using DemoImagerSwitcher;

namespace lolol
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity
    {
        private ImageSwitcher imageSwitcher;
        private Button btnNext;
        private Button btnPrevious;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            imageSwitcher = FindViewById<ImageSwitcher>(Resource.Id.imageSwitcher);
            imageSwitcher.SetFactory(new ViewSwitcherFactory(this));

            btnNext = FindViewById<Button>(Resource.Id.btnNext);
            btnNext.Click += (sender, e) => Right();

            btnPrevious = FindViewById<Button>(Resource.Id.btnPrev);
            btnPrevious.Click += (sender, e) => Left();
        }

        private void Left()
        {
            // Set the image for the 'Left' action
            imageSwitcher.SetImageResource(Resource.Drawable.left_image);
        }

        private void Right()
        {
            // Set the image for the 'Right' action
            imageSwitcher.SetImageResource(Resource.Drawable.right_image);
        }

        private class ViewSwitcherFactory : Java.Lang.Object, ViewSwitcher.IViewFactory
        {
            private readonly Context _context;

            public ViewSwitcherFactory(Context context)
            {
                _context = context;
            }

            public View MakeView()
            {
                ImageView imageView = new ImageView(_context);
                imageView.SetScaleType(ImageView.ScaleType.FitCenter);
                imageView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                return imageView;
            }
        }
    }
}