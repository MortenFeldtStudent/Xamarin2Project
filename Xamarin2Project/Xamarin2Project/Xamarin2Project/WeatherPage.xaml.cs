﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin2Project.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;


namespace Xamarin2Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        private List<WeatherDTO> weatherDTOList = new List<WeatherDTO>();
        private HttpClient client = new HttpClient();
        private string Url = "https://www.mortenfeldtstudent.dk/WeatherApiProject/api/weather/5days/";
        public WeatherPage()
        {
            InitializeComponent();
            weatherView.ItemTapped += WeatherView_ItemTapped;
        }

        private async void WeatherView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            WeatherDTO weatherDTO = e.Item as WeatherDTO;
            await DisplayAlert(weatherDTO.dayOfWeek, weatherDTO.ToString(), "OK");
            ((ListView)sender).SelectedItem = null;
        }
        private void SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            GetDataFromAPIAsync(searchBar.Text);
            citySearched.Text = searchBar.Text;
            searchBar.Text = "";
        }
        private async void GetDataFromAPIAsync(string city)
        {
            try
            {
                var response = await client.GetStringAsync(Url + city);

                var weatherList = JsonConvert.DeserializeObject<List<WeatherDTO>>(response);

                for (var i = 0; i < weatherList.Count; i++)
                {
                    weatherList[i].setImageUrl();
                    weatherList[i].setTempsRaw();
                    weatherList[i].setDayOfWeek();
                }

                weatherView.ItemsSource = weatherList;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not find weather for the requested city!\n\n" + ex.Message, "OK");
            }
        }
    }
}