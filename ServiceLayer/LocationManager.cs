using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class LocationManager
    {
        private readonly IDb<Location, int> locationContext;

        public LocationManager(IDb<Location, int> locationContext)
        {
            this.locationContext = locationContext;
        }

        public async Task CreateAsync(Location location)
        {
            await locationContext.CreateAsync(location);
        }

        public async Task<Location> ReadAsync(int key, bool navigationalProperties = false, bool IsReadOnly = true)
        {
            return await locationContext.ReadAsync(key, navigationalProperties, IsReadOnly);
        }

        public async Task<ICollection<Location>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await locationContext.ReadAllAsync(navigationalProperties, isReadOnly);
        }
        public async Task Update(Location location, bool navigationalProperties = false)
        {
            await locationContext.UpdateAsync(location, navigationalProperties);
        }

        public async Task Delete(int key)
        {
            await locationContext.DeleteAsync(key);
        }
    }
}
