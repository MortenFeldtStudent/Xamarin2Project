using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin2Project.Objects
{
    public class DeviceInformationStartup
    {
        private readonly Dictionary<string, DeviceInformation> entries = new Dictionary<string, DeviceInformation>();

        public Task AddAsync(DeviceInformation entry)
        {
            entries.Add(entry.DevInfoTitle, entry);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<DeviceInformation>> GetAllAsync()
        {
            IEnumerable<DeviceInformation> result = entries.Values.ToList();
            return Task.FromResult(result);
        }
    }
}
