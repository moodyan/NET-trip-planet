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
        //UserId connects to Identity
        public string UserName { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }

        public Planner(string firstName, string lastName, DateTime birthdate, string hometown)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Hometown = hometown;
        }
        public override bool Equals(System.Object otherPlanner)
        {
            if (!(otherPlanner is Planner))
            {
                return false;
            }
            else
            {
                Planner newPlanner = (Planner)otherPlanner;
                bool firstNameEquality = (this.FirstName == newPlanner.FirstName);
                bool lastNameEquality = (this.LastName == newPlanner.LastName);
                bool birthdateEquality = (this.Birthdate == newPlanner.Birthdate);
                bool hometownEquality = (this.Hometown == newPlanner.Hometown);

                return (firstNameEquality && lastNameEquality && birthdateEquality && hometownEquality);
            }
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode();
        }
    }
}
