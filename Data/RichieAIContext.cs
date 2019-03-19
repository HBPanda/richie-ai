using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RichieAI.Models
{
    public class RichieAIContext : DbContext
    {
        public RichieAIContext (DbContextOptions<RichieAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RichieAI.Models.Passenger> Passenger { get; set; }
        public virtual DbSet<RichieAI.Models.Cab> Cab { get; set; }
        public virtual DbSet<RichieAI.Models.CabManager> CabManager { get; set; }
        public virtual DbSet<RichieAI.Models.Experience> Experience { get; set; }
        public virtual DbSet<RichieAI.Models.Request> Request { get; set; }
        public virtual DbSet<RichieAI.Models.UnavailableReport> UnavailableReport { get; set; }
    }
}