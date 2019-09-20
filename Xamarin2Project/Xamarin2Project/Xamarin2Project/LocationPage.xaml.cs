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
            locationButtonSubmit.Clicked += fetchLocationAsync;
        }

        private async void fetchLocationAsync(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    locationObj = new LocationInformation
                    { latitude = location.Latitude, longitude = location.Longitude, altitude = (double)location.Altitude };

                    locationInfo.Text = locationObj.ToString();
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
    }
}
