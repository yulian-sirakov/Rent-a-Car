using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CarCategoryManager
    {
        private readonly IDb<CarCategory, int> carCategoryContext;

        public CarCategoryManager(IDb<CarCategory, int> carCategoryContext)
        {
            this.carCategoryContext = carCategoryContext;
        }

        public async Task CreateAsync(CarCategory carCategory)
        {
            await carCategoryContext.CreateAsync(carCategory);
        }

        public async Task<CarCategory> ReadAsync(int key, bool navigationalProperties = false, bool IsReadOnly = true )
        {
            return await carCategoryContext.ReadAsync(key, navigationalProperties, IsReadOnly);
        }

        public async Task<ICollection<CarCategory>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await carCategoryContext.ReadAllAsync(navigationalProperties, isReadOnly);
        }
        public async Task Update(CarCategory carCategory, bool navigationalProperties = false)
        {
            await carCategoryContext.UpdateAsync(carCategory,navigationalProperties);
        }

        public async Task Delete(int key)
        {
            await carCategoryContext.DeleteAsync(key);
        }
    }
}
