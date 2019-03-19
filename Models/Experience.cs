using System;

namespace RichieAI.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }

        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
        public virtual CabManager ExperienceNavigation { get; set; }
    }
}