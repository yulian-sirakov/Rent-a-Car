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
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

       
        public CarCategory()
        {
        }

       
        public CarCategory(int carCategoryId, string name, string description)
        {
            CarCategoryId = carCategoryId;
            Name = name;
            Description = description;
        }
    }
}
