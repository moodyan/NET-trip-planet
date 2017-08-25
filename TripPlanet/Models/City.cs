﻿using System;
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
        public City()
        {
            this.Lodgings = new HashSet<Lodging>();
            this.Activities = new HashSet<Activity>();
        }
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public virtual ICollection<TripCity> TripCities { get; set; }
        public virtual ICollection<CityTransportation> CityTransportations { get; set; }
        public virtual ICollection<Lodging> Lodgings { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
