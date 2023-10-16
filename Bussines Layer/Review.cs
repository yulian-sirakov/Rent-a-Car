using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Reservation Reservation { get; set; }

        [Required]
        public string ReviewText { get; set; }
        
        [Range(1, 5, ErrorMessage = "Рейтингът трябва да бъде между 1 и 5.")]
        public double Rating { get; set; }

        
        private Review()
        {

        }

       
        public Review(int reviewId, Customer customer, Reservation reservation, string reviewText, int rating)
        {
            ReviewId = reviewId;
            Customer = customer;
            Reservation = reservation;
            ReviewText = reviewText;
            Rating = rating;
        }
    }
}
