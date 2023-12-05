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
    public class CustomerContext : IDb<Customer, int>
    {
        private readonly RentACarDbContext dbContext;

        public CustomerContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Customer item)
        {
            dbContext.Customers.Add(item);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Customer> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Customer> query = dbContext.Customers;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.Reservations).Include(c => c.Reviews);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            return await query.FirstOrDefaultAsync(c => c.Id == key);


        }
        public async Task<ICollection<Customer>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Customer> query = dbContext.Customers;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.Reservations).Include(c => c.Reviews);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            return await query.ToListAsync();
        }
        public async Task UpdateAsync(Customer item, bool useNavigationalProperties = false)
        {
            try
            {
                Customer customerFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                customerFromDb.Name = item.Name;
                customerFromDb.Email = item.Email;
                customerFromDb.PhoneNumber = item.PhoneNumber;

                if (useNavigationalProperties)
                {
                    List<Reservation> reservations = new List<Reservation>(item.Reservations.Count);
                    List<Review> reviews = new List<Review>(item.Reviews.Count);

                    foreach (Reservation reservation in item.Reservations)
                    {
                        Reservation revervationFromDb = await dbContext.Reservations.FindAsync(reservation.Id);
                        if (revervationFromDb == null)
                        {
                            reservations.Add(reservation);
                        }
                        else
                        {
                            reservations.Add(revervationFromDb);
                        }
                        customerFromDb.Reservations = reservations;
                    }
                    foreach (Review review in item.Reviews)
                    {
                        Review reviewFromDb = await dbContext.Reviews.FindAsync(review.Id);
                        if (reviewFromDb == null)
                        {
                            reviews.Add(review);
                        }
                        else
                        {
                            reviews.Add(reviewFromDb);
                        }
                        customerFromDb.Reviews = reviews;
                    }
                    await dbContext.SaveChangesAsync();
                }
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
                Customer customerFromDb = await ReadAsync(key);

                if (customerFromDb == null)
                {
                    throw new ArgumentException("Customer with that Id does not exist!");
                }

                dbContext.Customers.Remove(customerFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }






    }
}
