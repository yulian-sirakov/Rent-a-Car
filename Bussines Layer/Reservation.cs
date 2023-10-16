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
        public Customer Customer { get; set; }

        [Required]
        public Car Car { get; set; }


        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        public List<Review> Reviews { get; set; }


        private Reservation()
        {
            Reviews = new List<Review>();
        }
        public Reservation(int id, Customer customer, Car car, DateTime startDate, DateTime endDate, decimal totalPrice, ReservationStatus status)
        {
            Id = id;
            Customer = customer;
            Car = car;
            StartDate = startDate;
            EndDate = endDate;
            TotalPrice = totalPrice;
            Status = status;
            Reviews = new List<Review>();
        }
    }
}
