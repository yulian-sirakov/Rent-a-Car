using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Range(1, 5, ErrorMessage = "Рейтингът трябва да бъде между 1 и 5.")]
        public double Rating { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }

        public Review()
        {

        }


        public Review(int id, Customer customer, string reviewText, int rating,Car car)
        {
            Id = id;
            Customer = customer;
            ReviewText = reviewText;
            Rating = rating;
            CustomerId = customer.Id;
            Car = car;
            CarId = car.Id;
        }
    }
}
