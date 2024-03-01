using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines_Layer.Models;
using DataLayer.Common;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.ModelsContext
{
    public class CarContext : IDb<Car, int>
    {
        private readonly RentACarDbContext dbContext;

        public CarContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Car item)
        {
            try
            {
                CarCategory carCategoryFromDb = await dbContext.CarCategories.FindAsync(item.CarCategoryId);
                if (carCategoryFromDb != null)
                {
                    item.Category = carCategoryFromDb;
                }
                dbContext.Cars.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Car> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Car> query = dbContext.Cars;
                if (useNavigationalProperties)
                {
                    query = query.Include(c => c.Category).Include(c=>c.Reviews);
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

        public async Task<ICollection<Car>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Car> query = dbContext.Cars;
                if (useNavigationalProperties)
                {
                    query = query.Include(c => c.Category).Include(c=>c.Reviews);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateAsync(Car item, bool useNavigationalProperties = false)
        {
            Car carFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);
            carFromDb.Brand = item.Brand;
            carFromDb.Model = item.Model;
            carFromDb.Year = item.Year;
            carFromDb.DailyRent = item.DailyRent;
            carFromDb.Description = item.Description;
            carFromDb.IsReserved = item.IsReserved;

            if (useNavigationalProperties)
            {
                CarCategory carCategoryFromDb = await dbContext.CarCategories.FindAsync(item.Category.Id);
                if (carCategoryFromDb != null)
                {
                    carFromDb.Category = carCategoryFromDb;
                }
                else
                {
                    carFromDb.Category = item.Category;
                }
            }
            dbContext.SaveChanges();
        }
        public async Task DeleteAsync(int key)
        {
            try
            {
                Car carFromDb = await ReadAsync(key, false, false);
                if (carFromDb == null)
                {
                    throw new ArgumentException("Car with that key does not exist!");
                }
                dbContext.Cars.Remove(carFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }






    }
}
