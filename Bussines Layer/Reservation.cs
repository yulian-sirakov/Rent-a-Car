using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public partial class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public ReservationStatus Status { get; set; }

        public Reservation()
        {
                
        }
        public Reservation(int id, int customerId, int carId, DateTime startDate, DateTime endDate, decimal totalPrice, ReservationStatus status)
        {
            Id = id;
            CustomerId = customerId;
            CarId = carId;
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
            Status = status;
        }
    }
}
