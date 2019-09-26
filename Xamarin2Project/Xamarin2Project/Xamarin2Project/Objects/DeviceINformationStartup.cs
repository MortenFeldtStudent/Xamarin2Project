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
        public void AddItemToList(DeviceInformation entry)
        {
            entries.Add(entry.DevInfoTitle, entry);
        }

        public List<DeviceInformation> GetAllItemsFromList()
        {
            return entries.Values.ToList();
        }
    }
}
