using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin2Project.Objects
{
    public class LocationInformationShow
    {
        private readonly Dictionary<string, LocationInformation> location = new Dictionary<string, LocationInformation>();

        public Task AddAsync(LocationInformation entry)
        {
            location.Add(entry.Id, entry);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<LocationInformation>> GetAllAsync()
        {
            IEnumerable<LocationInformation> result = location.Values.ToList();
            return Task.FromResult(result);
        }
    }
}