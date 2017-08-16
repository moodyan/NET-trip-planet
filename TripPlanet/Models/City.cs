using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public virtual ICollection<TripCity> TripCities { get; set; }
    }
}
