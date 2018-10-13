using Opportunity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OppTest
{
    public class PersonTest
    {
        private const string fname1 = "P1";
        private const string lname1 = "l1f";
        private const string email1 = "test@example.org";
        private readonly Company company1 = new Company("Solidium");

        [Fact]
        public void PersonTest1()
        {
            var p1 = new Person
            {
                FirstName = fname1,
                LastName = lname1,
                Email = email1
            };

            Assert.Equal(fname1, p1.FirstName);
            Assert.Equal(lname1, p1.LastName);
            Assert.Equal(email1, p1.Email);

            Assert.Equal($"{lname1}, {fname1}", p1.DisplayName);
        }

        [Fact]
        public void PersonTest2()
        {
            var p1 = new Person
            {
                Company = company1
            };

            Assert.Equal(company1, p1.Company);
        }

    }
}
