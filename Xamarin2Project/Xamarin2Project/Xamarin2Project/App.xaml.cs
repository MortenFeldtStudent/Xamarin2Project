using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin2Project.Objects;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Xamarin2Project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Entries = new DeviceInformationStartup();

            MainPage = new NavigationPage(new Xamarin2Project.MainPage())
            {
                BarBackgroundColor = Color.CadetBlue,
                BarTextColor = Color.White,
                BackgroundColor = Color.FromHex("#484747")
            };
            //MainPage = new MainPage();
        }

        public static DeviceInformationStartup Entries { get; set; }

        //protected override async void OnStart()
        //{
        //    // Handle when your app sleeps
        //}
        protected override async void OnStart()
        {
            DeviceInformation item1 = new DeviceInformation { DevInfoTitle = "Model:", DevInfoDetail = DeviceInfo.Model };
            DeviceInformation item2 = new DeviceInformation { DevInfoTitle = "Manufacturer:", DevInfoDetail = DeviceInfo.Manufacturer };
            DeviceInformation item3 = new DeviceInformation { DevInfoTitle = "Name:", DevInfoDetail = DeviceInfo.Name };
            DeviceInformation item4 = new DeviceInformation { DevInfoTitle = "OS Version:", DevInfoDetail = DeviceInfo.VersionString };
            await App.Entries.AddAsync(item1);
            await App.Entries.AddAsync(item2);
            await App.Entries.AddAsync(item3);
            await App.Entries.AddAsync(item4);
            //return await App.Entries.GetAllAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
