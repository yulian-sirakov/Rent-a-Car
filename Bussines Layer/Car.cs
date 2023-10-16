using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Brand max length is 50")]
        public string Brand {  get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Model max length is 50")]
        public string Model { get; set; }

        [Required]
        [Range(1900,2024,ErrorMessage ="Year should be between 1900 and 2024")]
        public int Year {  get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Max daily rent is 1000")]
        public decimal DailyRent {  get; set; }
        
        public string Description {  get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public bool IsReserved { get; set; }

        private Car()
        {
                
        }
        public Car(int id, string brand, string model, int year, decimal dailyRent, string description, CarCategory category,bool isReserved)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRent = dailyRent;
            Description = description;
            Category = category;
            IsReserved = isReserved;
        }
    }
}
