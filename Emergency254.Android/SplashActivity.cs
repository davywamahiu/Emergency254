
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace Emergency254.Droid
{
    [Activity(Label = "Emergency254",
   Theme = "@style/SplashTheme",
   MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.AddFlags(ActivityFlags.SingleTop);
            StartActivity(intent);
            Finish();
        }
    }
}