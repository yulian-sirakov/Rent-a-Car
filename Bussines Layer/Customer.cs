using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bussines_Layer
{
    public  class Customer
    {
        [Key]
        [Required]
        [MaxLength(50,ErrorMessage ="Max length for customer id is 50")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Max length for customer name is 50 ")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Max length for customer email is 50")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="Max length for customer phone number is 20")]
        public string PhoneNumber { get; set; }

        private Customer()
        {
        }
        public Customer(int id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
    

    
   
}
