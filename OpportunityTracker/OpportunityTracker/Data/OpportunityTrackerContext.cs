using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpportunityData;

namespace OpportunityTracker.Data
{
    public class OpportunityTrackerContext : DbContext
    {
        public OpportunityTrackerContext (DbContextOptions<OpportunityTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<OpportunityData.Opportunity> Opportunities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<OpportunityData.Contact> Contact { get; set; }
        public DbSet<OpportunityData.Activity> Activity { get; set; }
    }
}
