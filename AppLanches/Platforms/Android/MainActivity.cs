using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace AppLanches;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Change status bar color
        Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#c92a2a")); // Replace with your desired color

        //if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
        //{
        //    Window?.InsetsController?.SetSystemBarsAppearance(
        //        (int)WindowInsetsControllerAppearance.LightStatusBars,
        //        (int)WindowInsetsControllerAppearance.LightStatusBars);
        //}

    }

}
