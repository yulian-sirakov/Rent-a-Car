using Bussines_Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReservationContext : IDb<Reservation, int>
    {
        private readonly RentACarDbContext dbContext;

        public ReservationContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Reservation item)
        {
            try
            {
                dbContext.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Reservation> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Car).Include(r => r.Customer).Include(r => r.Reviews);
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

        public async Task<ICollection<Reservation>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Car).Include(r => r.Customer).Include(r => r.Reviews);
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

        public async Task UpdateAsync(Reservation item, bool useNavigationalProperties = false)
        {
            try
            {
                Reservation reservationFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);
                reservationFromDb.StartDate = item.StartDate;
                reservationFromDb.EndDate = item.EndDate;
                reservationFromDb.TotalPrice = item.TotalPrice;
                reservationFromDb.Status = item.Status;

                //REVIEWS,CUSTOMER,CAR
                if (useNavigationalProperties)
                {
                    List<Review> reviews = new List<Review>(item.Reviews.Count);
                    foreach (Review review in item.Reviews)
                    {
                        Review reviewFromDb = await dbContext.Reviews.FindAsync(review.ReviewId);
                        if (reviewFromDb != null)
                        {
                            reviews.Add(reviewFromDb);
                        }
                        else
                        {
                            reviews.Add(review);
                        }
                    }
                    reservationFromDb.Reviews = reviews;

                    Customer customerFromDb = await dbContext.Customers.FindAsync(item.Customer.Id);
                    if (customerFromDb != null)
                    {
                        reservationFromDb.Customer = customerFromDb;
                    }
                    else
                    {
                        reservationFromDb.Customer = item.Customer;
                    }

                    Car carFromDb = await dbContext.Cars.FindAsync(item.Car.Id);
                    if (carFromDb != null)
                    {
                        reservationFromDb.Car = carFromDb;
                    }
                    else
                    {
                        reservationFromDb.Car= item.Car;
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
                Reservation reservationFromDb = await ReadAsync(key,false,false);
                if (reservationFromDb == null)
                {
                    throw new ArgumentException("Reservation with that id does not exist");
                }

                dbContext.Reservations.Remove(reservationFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
