using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab08
{
    [Activity(Label = "@string/ApplicationName", Theme = "@android:style/Theme.Holo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);

            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this);

            //HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);

            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);

            //UserNameTextView.Text = GetString(Resource.String.UserName);

            //MainLayout.AddView(UserNameTextView);
        }

        private async void Validate()
        {
            var ServiceClient = new SALLab08.ServiceClient();
            
            string StudentEmail = "jarc_software@hotmail.com";
            string Password = "Jrosales23";

            string myDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(
                StudentEmail, Password, myDevice);

            var UserNameValue = FindViewById<TextView>(Resource.Id.UserNameValue);
            var StatusValue = FindViewById<TextView>(Resource.Id.StatusValue);
            var TokenValue = FindViewById<TextView>(Resource.Id.TokenValue);

            UserNameValue.Text = $"{Result.Fullname}";
            StatusValue.Text = $"{Result.Status}";
            TokenValue.Text = $"{Result.Token}";
        }
    }
}

