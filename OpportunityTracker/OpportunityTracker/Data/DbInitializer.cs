using OpportunityData;
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
            //context.Database.EnsureCreated();

            // Look for any opportunities.
            if (context.Opportunities.Any())
            {
                return;   // DB has been seeded
            }

            var comp1 = new Company("Solidium");
            var comp2 = new Company("Powersoft");
            var comp3 = new Company("Logica");

            context.Companies.Add(comp1);
            context.Companies.Add(comp2);
            context.Companies.Add(comp3);

            var opps = new OpportunityData.Opportunity[]
            {
                new OpportunityData.Opportunity
                {
                    Time =DateTime.Now,
                    Title ="Software Architect",
                    Description ="Yet another arch role",
                    Company = comp1,
                    Activities = new Activity[]
                    {
                        new Activity
                        {
                            Date = DateTime.Now,
                            Description = "Just called him",
                            Result = Activity.ResultType.NoWork,
                            Contact = new Person
                            {
                                FirstName = "Fred",
                                LastName = "Blogs",
                                Company = comp1
                            }
                        }
                    }
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
