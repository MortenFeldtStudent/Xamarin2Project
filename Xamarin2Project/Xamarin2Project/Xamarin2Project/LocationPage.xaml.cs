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
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    locationObj = new LocationInformation
                    { latitude = location.Latitude, longitude = location.Longitude, altitude = (double)location.Altitude };

                    //navigatetoNikolaiHomeButtonSubmit.IsVisible = true;

                    locationInfo.Text = locationObj.ToString();

                    
                    //await NavigateToBuilding25(locationObj.latitude, locationObj.longitude);
                    //latitudeTextDetail.Text = locationObj.latitude.ToString();
                    //longitudeTextDetail.Text = locationObj.longitude.ToString();
                    //altitudeTextDetail.Text = locationObj.altitude.ToString();
                    //BindingContext = locationObj;
                    //latitude.Text = $"Latitude: { location.Latitude}";
                    //longitude.Text = $"Longitude: { location.Longitude}";
                    //altitude.Text = $"Altitude: { location.Altitude}";
                }
                else
                {
                    await DisplayAlert("Info", "Location was not found. Try again!", "OK", "CANCEL");
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("EXCEPTION", "There was a permission exception for location.", "Cancel");
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }

        private async void NavigatetoNikolaiHomeButtonSubmit_Clicked(object sender, EventArgs e)
        {
            await RouteToNikolai(55.7303971573384, 12.2945576793848);
        }

        public async Task RouteToNikolai(double latitude, double longitude)
        {
            //var locationMap = new Location(47.645160, -122.1306032);
            var locationMap = new Location(latitude, longitude);
            await Map.OpenAsync(locationMap);
        }
    }
}
