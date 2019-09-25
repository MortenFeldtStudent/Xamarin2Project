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
        public bool IsSeparatorVisible = true;
        private List<WeatherDTO> weatherDTOList = new List<WeatherDTO>();
        //private string search = "copenhagen";
        private HttpClient client = new HttpClient();
        private string Url = "https://www.mortenfeldtstudent.dk/WeatherApiProject/api/weather/5days/";
        //private string weatherXaml = "";
        public WeatherPage()
        {
            InitializeComponent();
            weatherView.ItemTapped += WeatherView_ItemTapped;
        }

        private async void WeatherView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            WeatherDTO weatherDTO = e.Item as WeatherDTO;
            await DisplayAlert("TEST", weatherDTO.dayOfWeek, "OK");
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            citySearched.Text = entryCity.Text;
            GetDataFromAPIAsync(entryCity.Text);
            entryCity.Text = "";
            entryCity.Focus();
        }
        private async void GetDataFromAPIAsync(string city)
        {
            var response = await client.GetStringAsync(Url + city);

            var weatherList = JsonConvert.DeserializeObject<List<WeatherDTO>>(response);

            for (var i = 0; i < weatherList.Count; i++)
            {
                weatherList[i].setImageUrl();
                weatherList[i].setmaxTempRaw();
                weatherList[i].setDayOfWeek();
            }

            weatherView.ItemsSource = weatherList;
        }

        private string CapitalLetter(string str)
        {
            string uppercase = str.ToUpper();
            string lowercase = str.ToLower();
            return uppercase.Substring(0, 1) + lowercase.Substring(1);
        }
    }
}