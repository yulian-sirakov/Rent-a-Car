using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.ModelsContext
{
    public class LocationContext : IDb<Location, int>
    {
        private readonly RentACarDbContext dbContext;
        public LocationContext(RentACarDbContext dbContext)
        {
            this.dbContext = dbContext;
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
        public async Task<Location> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Location> query = dbContext.Locations;
                if (useNavigationalProperties)
                {
                    query = query.Include(l => l.Reservation);
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
        public async Task DeleteAsync(int key)
        {
            try
            {
                Location locationFromDb = await ReadAsync(key, false, false);
                if (locationFromDb != null)
                {
                    throw new ArgumentException();
                }
                dbContext.Locations.Remove(locationFromDb);
                await dbContext.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Location>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Location> query = dbContext.Locations;
            if (useNavigationalProperties)
            {
                query = query.Include(l => l.Reservation);

            }
            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }
            return await query.ToListAsync();

        }



        public async Task UpdateAsync(Location item, bool useNavigationalProperties = false)
        {
            try
            {
                Location locationFromDb = await ReadAsync(item.Id, false, false);
                if (locationFromDb == null)
                {
                    throw new ArgumentException();
                }
                locationFromDb.Adress = item.Adress;
                locationFromDb.Reservation = item.Reservation;
                locationFromDb.Town = item.Town;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
