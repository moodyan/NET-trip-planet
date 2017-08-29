using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Lodgings")]
    public class Lodging
    {
        [Key]
        public int LodgingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [DisplayName("Arrival Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }
        public decimal Cost { get; set; }
        public bool Booked { get; set; }
        [DisplayName("Confirmation Number")]
        public string Confirmation { get; set; }
        public int CityId { get; set; }
        public virtual City Cities { get; set; }
    }
}
