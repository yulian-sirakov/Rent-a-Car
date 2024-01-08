using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ReservationManager
    {
        private readonly IDb<Reservation, int> reservationContext;

        public ReservationManager(IDb<Reservation, int> reservationContext)
        {
            this.reservationContext = reservationContext;
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await reservationContext.CreateAsync(reservation);
        }

        public async Task<Reservation> ReadAsync(int key, bool navigationalProperties = false, bool IsReadOnly = true)
        {
            return await reservationContext.ReadAsync(key, navigationalProperties, IsReadOnly);
        }

        public async Task<ICollection<Reservation>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await reservationContext.ReadAllAsync(navigationalProperties, isReadOnly);
        }
        public async Task Update(Reservation reservation, bool navigationalProperties = false)
        {
            await reservationContext.UpdateAsync(reservation, navigationalProperties);
        }

        public async Task Delete(int key)
        {
            await reservationContext.DeleteAsync(key);
        }
    }
}
