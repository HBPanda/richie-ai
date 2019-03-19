using System;
using System.Collections.Generic;

namespace RichieAI.Models
{
    public class Cab
    {
        public Cab(){
            UnavailableReports = new HashSet<UnavailableReport>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Availability {get; set; }
        public string TRN { get; set; }

        public int RequestId { get;  set; }
        public virtual Request RequestIdNavigation { get; set; }
        public virtual ICollection<UnavailableReport> UnavailableReports { get; set; }
    }
}