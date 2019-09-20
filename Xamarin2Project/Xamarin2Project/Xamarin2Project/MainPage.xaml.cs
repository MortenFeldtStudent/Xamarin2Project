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
        public MainPage()
        {
            InitializeComponent();
            browseLocation.Clicked += showLocationPage;
            browseSMS.Clicked += BrowseSMS_Clicked;
            browseWeather.Clicked += BrowseWeather_Clicked;
        }

        private void BrowseWeather_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate();
            Navigation.PushAsync(new WeatherPage());
        }

        private void BrowseSMS_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate();
            Navigation.PushAsync(new SMSPage());
        }

        private void showLocationPage(object sender, EventArgs e)
        {
            Vibration.Vibrate();
            Navigation.PushAsync(new LocationPage());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //DeviceInformation item1 = new DeviceInformation { DevInfoTitle = "Model:", DevInfoDetail = DeviceInfo.Model };
            //DeviceInformation item2 = new DeviceInformation { DevInfoTitle = "Manufacturer:", DevInfoDetail = DeviceInfo.Manufacturer };
            //DeviceInformation item3 = new DeviceInformation { DevInfoTitle = "Name:", DevInfoDetail = DeviceInfo.Name };
            //DeviceInformation item4 = new DeviceInformation { DevInfoTitle = "OS Version:", DevInfoDetail = DeviceInfo.VersionString };
            //await App.Entries.AddAsync(item1);
            //await App.Entries.AddAsync(item2);
            //await App.Entries.AddAsync(item3);
            //await App.Entries.AddAsync(item4);
            entries.ItemsSource = await App.Entries.GetAllAsync();
        }
    }
}
