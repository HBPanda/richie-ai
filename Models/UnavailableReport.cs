using System;

namespace RichieAI.Models
{
    public class UnavailableReport
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }

        public int CabId { get; set; }
        public virtual Cab Cab { get; set; }
        public virtual CabManager UnavailableReportNavigation { get; set; }
    }
}