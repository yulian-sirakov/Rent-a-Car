using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussines_Layer.Enums;

namespace Bussines_Layer.Models
{
    public partial class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public ReservationStatus Status { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }


        private Reservation()
        {

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
            CustomerId = customer.Id;
            CarId = car.Id;
        }
    }
}
