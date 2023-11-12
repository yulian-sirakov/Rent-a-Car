using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class CarCategory
    {
        [Key]
        public int CarCategoryId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Max length for category name is 50")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Car> Cars {  get; set; }
        private CarCategory()
        {
            Cars = new List<Car>();
        }

       
        public CarCategory(int carCategoryId, string name, string description)
        {
            CarCategoryId = carCategoryId;
            Name = name;
            Description = description;
            Cars = new List<Car>();
        }
    }
}
