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
                BarBackgroundColor = Color.Black,
                BarTextColor = Color.White,
                BackgroundColor = Color.FromHex("#484747")
            };
        }

        public static DeviceInformationStartup Entries { get; set; }
        protected override void OnStart()
        {
            DeviceInformation item1 = new DeviceInformation { DevInfoTitle = "Model:", DevInfoDetail = DeviceInfo.Model };
            DeviceInformation item2 = new DeviceInformation { DevInfoTitle = "Manufacturer:", DevInfoDetail = DeviceInfo.Manufacturer };
            DeviceInformation item3 = new DeviceInformation { DevInfoTitle = "Name:", DevInfoDetail = DeviceInfo.Name };
            DeviceInformation item4 = new DeviceInformation { DevInfoTitle = "OS Version:", DevInfoDetail = DeviceInfo.VersionString };
            Entries.AddItemToList(item1);
            Entries.AddItemToList(item2);
            Entries.AddItemToList(item3);
            Entries.AddItemToList(item4);
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
