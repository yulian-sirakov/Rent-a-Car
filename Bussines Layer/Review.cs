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
        [Range(0,50,ErrorMessage ="Id must be between 0 and 50")]
        public int ReviewId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Maxlength for customer name is 50")]
        public string CustomerName { get; set; }

        [Required]
        [Range(0,50,ErrorMessage ="Car id must between 0 and 50")]

        public int CarId { get; set; }

        
        public string ReviewText { get; set; }
        
        [Range(1, 5, ErrorMessage = "Рейтингът трябва да бъде между 1 и 5.")]
        public int Rating { get; set; }

        
        private Review()
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
