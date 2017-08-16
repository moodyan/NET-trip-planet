using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Trips")]
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        public string Name { get; set; }
        public string StartCity { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TripLength { get; set; }
        public decimal Budget { get; set; }
        public string Members { get; set; }
        public bool Public { get; set; }
        public virtual ICollection<TripCity> TripCities { get; set; }
    }
}
