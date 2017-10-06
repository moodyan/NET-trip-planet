using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TripPlanet.Models
{
    [Table("Cities")]
    public class City
    {
        public City()
        {
            this.Lodgings = new HashSet<Lodging>();
            this.Activities = new HashSet<Activity>();
            this.Transportations = new HashSet<Transportation>();
        }
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Duration { get; set; }
        [DisplayName("Arrival Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime ArrivalDate { get; set; }
        [DisplayName("Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime DepartureDate { get; set; }
        public int TripId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<TripCity> TripCities { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Lodging> Lodgings { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Activity> Activities { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Transportation> Transportations { get; set; }

        public int GetDuration()
        {
            double doubleDays = (DepartureDate - ArrivalDate).TotalDays;
            int days = Convert.ToInt32(doubleDays);
            Duration = days;
            return days;
        }

        

    }
}
