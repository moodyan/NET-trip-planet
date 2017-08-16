using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Planners")]
    public class Planner
    {
        public Planner()
        {
            this.Trips = new HashSet<Trip>();
        }
        [Key]
        public int PlannerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public byte Image { get; set; }
        public string Hometown { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
        
    }
}
