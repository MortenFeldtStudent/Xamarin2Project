using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin2Project.Objects
{
    public class LocationInformation
    {
        public string Id { get; set; }

        public LocationInformation()
        {
            Id = Guid.NewGuid().ToString();
        }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }

        public override string ToString()
        {
            return "Latitude: " + latitude + "\n"
            + "Longitude: " + longitude + "\n"
            + "Altitude: " + altitude;
        }
    }
}