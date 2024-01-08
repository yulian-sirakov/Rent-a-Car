using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Bussines_Layer.Models;
using DataLayer.Common;

namespace ServiceLayer
{
    public class CarManager
    {
        private readonly IDb<Car, int> carContext;

        public CarManager(IDb<Car,int> carContext)
        {
            this.carContext = carContext;
        }

        public async Task CreateAsync(Car car)
        {
            await carContext.CreateAsync(car);
        }

        public async Task<Car> ReadAsync(int key, bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await carContext.ReadAsync(key,navigationalProperties, isReadOnly);
        }

        public async Task<IEnumerable<Car>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await carContext.ReadAllAsync(navigationalProperties,isReadOnly);
        }

        public async Task UpdateAsync(Car car, bool navigationalProperties = false)
        {
            await carContext.UpdateAsync(car,navigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await carContext.DeleteAsync(key);
        }


    }
}
