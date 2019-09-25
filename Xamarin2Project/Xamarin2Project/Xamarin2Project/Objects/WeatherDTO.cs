using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin2Project.Objects
{
    public class WeatherDTO
    {
        public ulong id { get; set; }
        public double min_temp { get; set; }
        public double max_temp { get; set; }
        public double the_temp { get; set; }
        public double wind_speed { get; set; }
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public string wind_direction_compass { get; set; }
        public string applicable_date { get; set; }
        public string image_url { get; set; }
        public string maxTempRaw { get; set; }
        public string dayOfWeek { get; set; }

        public void setImageUrl()
        {
            image_url = "https://www.metaweather.com/static/img/weather/ico/" + weather_state_abbr + ".ico";
        }

        public void setmaxTempRaw()
        {
            maxTempRaw = Convert.ToString(Convert.ToInt32(max_temp)) + "°C";
        }

        public void setDayOfWeek()
        {
            string[] arr = applicable_date.Split('-');
            int year = Convert.ToInt32(arr[0]);
            int month = Convert.ToInt32(arr[1]);
            int day = Convert.ToInt32(arr[2]);
            DateTime dateValue = new DateTime(year, month, day);
            dayOfWeek = capitalLetter(dateValue.ToString("ddddddd"));
        }

        private string capitalLetter(string strInput)
        {
            return strInput.Substring(0, 1).ToUpper() + strInput.Substring(1, strInput.Length - 1).ToLower();
        }
    }
}
