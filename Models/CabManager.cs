using System;
using System.Collections.Generic;

namespace RichieAI.Models
{
    public class CabManager
    {
        public CabManager(){
            Requests =  new HashSet<Request>();
            UnavailableReports =  new HashSet<UnavailableReport>();
            Experiences =  new HashSet<Experience>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<UnavailableReport> UnavailableReports { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
    }
}