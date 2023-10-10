using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class Car
    {
        [Key]
        [Required]
        public int Id {  get; set; }
        [Required]
        public string Brand {  get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year {  get; set; }
        [Required]
        public decimal DailyRent {  get; set; }
        [Required]
        public string Description {  get; set; }
            
        private Car()
        {
                
        }
        public Car(int id, string brand, string model, int year, decimal dailyRent, string description)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            DailyRent = dailyRent;
            Description = description;
        }
    }
}
