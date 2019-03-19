using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RichieAI.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }
        public bool Confirmation { get; set; }
        public DateTime RequestDate { get; set; }

        public int PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public virtual Passenger Passenger { get; set; }
        public int CabId { get; set; }
        [ForeignKey("CabId")]
        public virtual Cab Cab { get; set; }
        public int ExperienceId { get; set; }
        [ForeignKey("ExperienceId")]
        public virtual Experience Experience { get; set; }
        public virtual CabManager RequestNavigation { get; set; }

    }
}