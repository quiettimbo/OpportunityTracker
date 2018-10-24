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

            var comp1 = new Company("Solidium");


            var opps = new Opportunity.Opportunity[]
            {
                new Opportunity.Opportunity
                {
                    Time =DateTime.Now,
                    Title ="Software Architect",
                    Description ="Yet another arch role",
                    Company = comp1,
                }
            };
            foreach (var s in opps)
            {
                context.Opportunities.Add(s);
            }
            context.SaveChanges();

        }
    }
}
