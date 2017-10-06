using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Starting City")]
        public string StartCity { get; set; }
        [DisplayName("Begin Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime BeginDate { get; set; }
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime EndDate { get; set; }
        public int TripLength { get; set; }
        public decimal Budget { get; set; }
        public string Members { get; set; }
        public bool Public { get; set; }
        public virtual ICollection<TripCity> TripCities { get; set; }
        public int PlannerId { get; set; }
        public virtual Planner Planner { get; set; }

        public int GetDuration()
        {
            double doubleDays = (EndDate - BeginDate).TotalDays;
            int days = Convert.ToInt32(doubleDays);
            TripLength = days;
            return days;
        }
    }

}
