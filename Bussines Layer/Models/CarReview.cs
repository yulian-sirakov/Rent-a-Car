using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer.Models
{
    public class CarReview
    {
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; }
        1
        [Required]
        public int CarId { get; set; }

        [ForeignKey(nameof(ReviewId))]
        public Review Review { get; set; }

        [Required]
        public int ReviewId { get; set; }

        private CarReview()
        {
            
        }

        public CarReview(Car car,Review review)
        {
            Car = car;
            CarId = car.Id;
            Review = review;
            ReviewId = review.Id;
        }
    }
}
