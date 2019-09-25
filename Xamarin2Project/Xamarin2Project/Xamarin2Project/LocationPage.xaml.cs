using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Xamarin2Project.Objects;

namespace Xamarin2Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        private LocationInformation locationObj;
        public LocationPage()
        {
            InitializeComponent();
            navigatetoNikolaiHomeButtonSubmit.IsVisible = false;
            locationButtonSubmit.Clicked += fetchLocationAsync;
            navigatetoNikolaiHomeButtonSubmit.Clicked += NavigatetoNikolaiHomeButtonSubmit_Clicked;
        }
        private async void fetchLocationAsync(object sender, EventArgs e)
        {
            Vibration.Vibrate();
            navigatetoNikolaiHomeButtonSubmit.IsVisible = true;

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    locationObj = new LocationInformation
                    { latitude = location.Latitude, longitude = location.Longitude, altitude = (double)location.Altitude };


                    locationInfo.Text = locationObj.ToString();

                }
                else
                {
                    await DisplayAlert("Info", "Location was not found. Try again!", "OK", "CANCEL");
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", "Location is not supported on this device!", "OK", "CANCEL");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Error", "Location is not enabled on this device!", "OK", "CANCEL");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("EXCEPTION", "There was a permission exception for location.", "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error has occured. Try again later!", "OK", "CANCEL");
            }
        }

        private async void NavigatetoNikolaiHomeButtonSubmit_Clicked(object sender, EventArgs e)
        {
            await RouteToNikolai(55.7303971573384, 12.2945576793848);
        }

        public async Task RouteToNikolai(double latitude, double longitude)
        {
            var locationMap = new Location(latitude, longitude);
            await Map.OpenAsync(locationMap);
        }
    }
}
