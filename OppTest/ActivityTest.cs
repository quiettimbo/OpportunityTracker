using OpportunityData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace OppTest
{
    public class ActivityTest
    {
        private const string fname1 = "P1";
        private const string lname1 = "l1f";
        private const string email1 = "test@example.org";
        private readonly Company company1 = new Company("Solidium");

        //[Fact]
        //public void ActivityTest1()
        //{
        //    Person person = new Person();
        //    Opportunity.Opportunity opportunity = new Opportunity.Opportunity();
        //    DateTime create = new DateTime();
        //    var a1 = new Activity
        //    {
        //        Description = fname1,
        //        Contact = person,
        //        Position = opportunity,
        //        Date = create,
        //        Result = Activity.ResultType.NoResponse
        //    };

        //    Assert.Equal(person, a1.Contact);
        //    Assert.Equal(fname1, a1.Description);
        //    Assert.Equal(opportunity, a1.Position);
        //    Assert.Equal(Activity.ResultType.NoResponse, a1.Result);
        //    Assert.Equal(create, a1.Date);

        //    Assert.Equal(a1, a1.Position.Activities.First());
        //}

    }
}
