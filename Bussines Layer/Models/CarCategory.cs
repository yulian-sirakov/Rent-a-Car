using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer.Models
{
    public class CarCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Max length for category name is 50")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Car> Cars { get; set; }
        private CarCategory()
        {
            Cars = new List<Car>();
        }


        public CarCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            Cars = new List<Car>();
        }
    }
}
