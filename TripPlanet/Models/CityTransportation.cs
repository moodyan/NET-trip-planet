using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    public class CityTransportation
    {
        public int TransportationId { get; set; }
        public int CityId { get; set; }
        public Transportation Transportation { get; set; }
        public City City { get; set; }
    }
}
