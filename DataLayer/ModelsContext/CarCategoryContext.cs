using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines_Layer.Models;
using DataLayer.Common;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.ModelsContext
{
    public class CarCategoryContext : IDb<CarCategory, int>
    {
        private readonly RentACarDbContext dbContext;

        public CarCategoryContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CarCategory item)
        {
            try
            {
                dbContext.CarCategories.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CarCategory> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<CarCategory> query = dbContext.CarCategories;

                if (useNavigationalProperties)
                {
                    query = query.Include(c => c.Cars);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(c => c.Id == key);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<CarCategory>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<CarCategory> query = dbContext.CarCategories;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.Cars);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(CarCategory item, bool useNavigationalProperties = false)
        {
            try
            {
                //Не може чрез навигационните свойства на категорията на кола да се ъпдейтне колата
                // useNavigationalProperties -> NO

                CarCategory carCategoryFromDb = await ReadAsync(item.Id, false, false);
                if (carCategoryFromDb == null)
                {
                    throw new ArgumentException("Car category that you want to update does not exist!");
                }
                //Проверка за null

                carCategoryFromDb.Name = item.Name;
                carCategoryFromDb.Description = item.Description;

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                CarCategory carCategoryFromDb = await ReadAsync(key, false, false);

                if (carCategoryFromDb == null)
                {
                    throw new ArgumentException("Car category with that key does not exist!");
                }

                dbContext.CarCategories.Remove(carCategoryFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }






    }
}
