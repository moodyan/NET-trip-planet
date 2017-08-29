using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Transportations")]
    public class Transportation
    {
        [Key]
        public int TransportationId { get; set; }
        [DisplayName("Mode of Transport")]
        public string Mode { get; set; }
        public string Confirmation { get; set; }
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }
        public decimal Cost { get; set; }
        public bool Booked { get; set; }
        public int DepartureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public virtual ICollection<CityTransportation> CityTransportations { get; set; }
    }
}
