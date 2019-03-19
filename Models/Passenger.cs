using System;

namespace RichieAI.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RequestId { get;  set; }
        public virtual Request RequestIdNavigation { get; set; }
    }
}