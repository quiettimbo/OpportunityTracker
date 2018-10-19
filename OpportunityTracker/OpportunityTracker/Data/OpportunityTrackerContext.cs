using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opportunity;

namespace OpportunityTracker.Data
{
    public class OpportunityTrackerContext : DbContext
    {
        public OpportunityTrackerContext (DbContextOptions<OpportunityTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Opportunity.Opportunity> Opportunities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
