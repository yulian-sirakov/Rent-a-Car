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
        public string CustomerName { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Range(1, 5, ErrorMessage = "Рейтингът трябва да бъде между 1 и 5.")]
        public int Rating { get; set; }

        
        public Review()
        {
        }

       
        public Review(int reviewId, string customerName, int carId, string reviewText, int rating)
        {
            ReviewId = reviewId;
            CustomerName = customerName;
            CarId = carId;
            ReviewText = reviewText;
            Rating = rating;
        }
    }
}
