using Opportunity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunityTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(OpportunityTrackerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any opportunities.
            if (context.Opportunities.Any())
            {
                return;   // DB has been seeded
            }

            var roles = new Role[]
            {
                new Role{Title="Software Architect", Description="Yet another arch role"}
            };

            foreach (var rr in roles)
            {
                context.Roles.Add(rr);
            }

            var opps = new Opportunity.Opportunity[]
            {
                new Opportunity.Opportunity{ Time=DateTime.Now, Role = roles[0]}
            };
            foreach (var s in opps)
            {
                context.Opportunities.Add(s);
            }
            context.SaveChanges();

        }
    }
}
