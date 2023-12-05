using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bussines_Layer.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Max length for customer name is 100")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length for customer email is 50")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Max length for customer phone number is 20")]
        public string PhoneNumber { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Review> Reviews { get; set; }

        private Customer()
        {
            Reservations = new List<Reservation>();
            Reviews = new List<Review>();
        }
        public Customer(int id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Reservations = new List<Reservation>();
            Reviews = new List<Review>();
        }

    }




}
