using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TripPlanet.Models
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public string Description { get; set; }
        public byte Image { get; set; }
        
    }
}
