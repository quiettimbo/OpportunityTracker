using Opportunity;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OppTest
{
    public class OppTest
    {
        private const string desc = "Called Recruiter";
        private readonly string company1 = "Solidium";
        private readonly string title1 = "Software Architect";

        [Fact]
        public void Ctor1()
        {
            var contact = new Person();
            var op1 = new Opportunity.Opportunity(contact)
            {
                IsActive = true
            };

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.PrimaryContact);
            Assert.Equal(DateTime.Now.Date, op1.Time.Date);
            Assert.True(op1.IsActive);
        }

        [Fact]
        public void Ctor2()
        {
            Company company = new Company(company1);
            var contact = new Person();
            var op1 = new Opportunity.Opportunity(contact, company);

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.PrimaryContact);
        }

        [Fact]
        public void Ctor3()
        {
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.PrimaryContact);

        }

        [Fact]
        public void Ctor4()
        {
            Company company = new Company(company1);
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).With(company).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.PrimaryContact);
        }

        [Fact]
        public void Ctor4b()
        {
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).With(company1).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.PrimaryContact);
        }

        [Fact]
        public void Ctor6()
        {

            var contact = new Person();
            var op1 = new OpportunityBuilder(contact)
                .As(title1)
                .Doing(desc)
                .Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(title1, op1.Title);
            Assert.Equal(desc, op1.Description);
            Assert.Equal(contact, op1.PrimaryContact);
        }

        [Fact]
        public void Ctor7()
        {
            var contact = new Website(new Uri("http://solidium.com"));
            var op1 = new OpportunityBuilder(contact).Action(desc).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.PrimaryContact);
            var act = op1.Activities.First();
            Assert.Equal(desc, act.Description);

        }

        [Fact]
        public void CtorActivity()
        {
            var contact = new Website(new Uri("http://solidium.com"));
            var op1 = new OpportunityBuilder(contact).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.PrimaryContact);

        }


    }


}


