using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines_Layer.Models;
using DataLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataLayer.ModelsContext
{
    public class ReviewContext : IDb<Review, int>
    {
        private readonly RentACarDbContext dbContext;

        public ReviewContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Review item)
        {
            try
            {
                Customer customerFromDb = await dbContext.Customers.FindAsync(item.CustomerId);
                if (customerFromDb != null)
                {
                    item.Customer = customerFromDb;
                }


                dbContext.Reviews.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Review> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Review> query = dbContext.Reviews;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Car).Include(r => r.Customer);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(r => r.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<Review>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Review> query = dbContext.Reviews;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Car).Include(r => r.Customer);
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



        public async Task UpdateAsync(Review item, bool useNavigationalProperties = false)
        {
            try
            {
                Review reviewFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                reviewFromDb.ReviewText = item.ReviewText;
                reviewFromDb.Rating = item.Rating;

                if (useNavigationalProperties)
                {
                    Customer customerFromDb = await dbContext.Customers.FindAsync(item.CustomerId);

                    if (customerFromDb != null)
                    {
                        reviewFromDb.Customer = customerFromDb;
                    }
                    else
                    {
                        reviewFromDb.Customer = item.Customer;
                    }

                    Car carFromDb = await dbContext.Cars.FindAsync(item.CarId);

                    if (carFromDb != null)
                    {
                        reviewFromDb.Car = carFromDb;
                    }
                    else
                    {
                        reviewFromDb.Car = item.Car;
                    }
                }

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
                Review reviewFromDb = await ReadAsync(key, false, false);
                if (reviewFromDb == null)
                {
                    throw new ArgumentException("Review with that id does not exist!");
                }

                dbContext.Reviews.Remove(reviewFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
