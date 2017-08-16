using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    public class TripCity
    {
        public int TripId { get; set; }
        public int CityId { get; set; }
        public Trip Trip { get; set; }
        public City City { get; set; }
    }
}
