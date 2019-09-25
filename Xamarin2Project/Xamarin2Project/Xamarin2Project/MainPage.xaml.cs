using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin2Project.Objects;

namespace Xamarin2Project
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool light;
        public MainPage()
        {
            InitializeComponent();
            browseLocation.Clicked += showLocationPage;
            browseSMS.Clicked += BrowseSMS_Clicked;
            browseWeather.Clicked += BrowseWeather_Clicked;
        }

        private async void BrowseWeather_Clicked(object sender, EventArgs e)
        {
            //Vibration.Vibrate();
            await Navigation.PushAsync(new WeatherPage());
        }

        private void BrowseSMS_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate();
            Navigation.PushAsync(new SMSPage());
        }

        private void showLocationPage(object sender, EventArgs e)
        {
            //Vibration.Vibrate();
            Navigation.PushAsync(new LocationPage());
        }
        private async void OnLightOnOff(object sender, EventArgs e)
        {
            if (light)
            {
                await Flashlight.TurnOffAsync();
                light = false;
            }
            else
            {
                await Flashlight.TurnOnAsync();
                light = true;
            }
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            entries.ItemsSource = await App.Entries.GetAllAsync();
        }
    }
}
