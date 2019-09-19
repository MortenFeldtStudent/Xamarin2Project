using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            Navigation.PushAsync(new WeatherPage());
        }

        private void BrowseSMS_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SMSPage());
        }

        private void showLocationPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage());
        }
    }
}
