using Bussines_Layer.Models;
using DataLayer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ModelsContext
{
    public class LocationContext : IDb<Location, int>
    {
        private readonly RentACarDbContext dbContext;


        public LocationContext(RentACarDbContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task CreateAsync(Location item)
        {
            try
            {
                dbContext.Locations.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            Location locationFromDb = await ReadAsync(key,false,false);

            if (locationFromDb != null)
            {
                throw new ArgumentException("The location don't exist!");
            }

            dbContext.Locations.Remove(locationFromDb);
            dbContext.SaveChanges();
        }

        public async Task<ICollection<Location>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Location> query = dbContext.Locations;

            if (useNavigationalProperties)
            {
                query = query.Include(x => x.Reservation);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            return await query.ToListAsync();
        }

        public async Task<Location> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Location> query = dbContext.Locations;
                if (useNavigationalProperties)
                {
                    query = query.Include(x => x.Reservation);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(x=>x.Id == key);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Location item, bool useNavigationalProperties = false)
        {
            Location locationFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

            locationFromDb.Town = item.Town;
            locationFromDb.Adress = item.Adress;

            if (useNavigationalProperties)
            {
                Reservation reservationFromDb = await dbContext.Reservations.FindAsync(locationFromDb.ReservationId);
                if (reservationFromDb != null)
                {
                    locationFromDb.Reservation = reservationFromDb;
                }
                else
                {
                    locationFromDb.Reservation = item.Reservation;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
