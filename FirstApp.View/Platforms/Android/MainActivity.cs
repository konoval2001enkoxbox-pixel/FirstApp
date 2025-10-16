using Android.App;
using Android.Content.PM;
using Android.OS;
using static AndroidX.Core.SplashScreen.SplashScreen;

namespace FirstApp.View
{
    //[Activity(Theme = "@style/Theme.Animated", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        //protected override void OnCreate(Bundle? savedInstanceState)
        //{
        //    var splash = InstallSplashScreen(this);
        //    base.OnCreate(savedInstanceState);

        //}
    }
}
