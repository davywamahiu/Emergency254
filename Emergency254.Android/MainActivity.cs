using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android;
using Xamarin.Forms;
using Emergency254.Styles;

namespace Emergency254.Droid
{
    [Activity(Label = "Emergency254", Icon = "@drawable/pop", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            TryToGetPermissions();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            ThemeHelper.ChangeTheme(Emergency254.Util.Settings.ThemeOption, true);
            base.OnConfigurationChanged(newConfig);
        }
        #region RuntimePermissions

        async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                await GetPermissionsAsync();
                return;
            }


        }
        const int RequestLocationId = 0;
        const int RequestInternetId = 1;
        const int RequestStorageId = 2;
        const int RequestWriteId = 3;
        const int RequestSmsId = 4;
        const int RequestSettingsId = 5;
        readonly string[] PermissionsGroupLocation =
            {
                            //TODO add more permissions
                            Manifest.Permission.AccessCoarseLocation,
                            Manifest.Permission.AccessFineLocation,
                            Manifest.Permission.Internet,
                            Manifest.Permission.ReadExternalStorage,
                            Manifest.Permission.WriteExternalStorage,
                            Manifest.Permission.ReadSms,
                            Manifest.Permission.ReceiveSms,
                            Manifest.Permission.WriteSettings
             };
        async Task GetPermissionsAsync()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            const string permission1 = Manifest.Permission.Internet;
            const string permission2 = Manifest.Permission.WriteExternalStorage;
            const string permission3 = Manifest.Permission.ReadExternalStorage;
            const string permission4 = Manifest.Permission.ReadSms;
            const string permission5 = Manifest.Permission.WriteSettings;
            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                //TODO change the message to show the permissions name
                await App.Current.MainPage.DisplayAlert("", "Permission(s) 3 Already Granted", "OK");
                return;
            }
            if (ShouldShowRequestPermissionRationale(permission))
            {
                //set alert for executing the task
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permissions Needed");
                alert.SetMessage("The application need special permissions to continue");
                alert.SetNeutralButton("OK", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestLocationId);
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) =>
                {
                    App.Current.MainPage.DisplayAlert("", "You have Cancelled Request, Crashes will be inevitable.", "OK");
                });

                Dialog dialog = alert.Create();
                dialog.Show();


                return;
            }

            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
            RequestPermissions(PermissionsGroupLocation, RequestInternetId);
            RequestPermissions(PermissionsGroupLocation, RequestStorageId);
            RequestPermissions(PermissionsGroupLocation, RequestWriteId);
            RequestPermissions(PermissionsGroupLocation, RequestSmsId);
            RequestPermissions(PermissionsGroupLocation, RequestSettingsId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion
    }
}
