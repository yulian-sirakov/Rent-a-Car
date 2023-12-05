using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage = "Town name length must be maximum 100 characters!")]
        public string Town { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; }

        private Location()
        {

        }

        public Location(int id, string adress, string town,Reservation reservation)
        {
            Id = id;
            Adress = adress;
            Town = town;
            Reservation = reservation;
            ReservationId = reservation.Id;
        }
    }
}
