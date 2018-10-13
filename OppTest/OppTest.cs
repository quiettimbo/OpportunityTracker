using Opportunity;
using System;
using System.Collections.Generic;
using Xunit;

namespace OppTest
{
    public class OppTest
    {
        private readonly string company1 = "Solidium";
        private readonly string title1 = "Software Architect";

        [Fact]
        public void Ctor1()
        {
            var contact = new Person();
            var op1 = new Opportunity.Opportunity(contact);

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.Contact);
            Assert.Equal(DateTime.Now.Date, op1.Time.Date);

        }

        [Fact]
        public void Ctor2()
        {
            Company company = new Company(company1);
            var contact = new Person();
            var op1 = new Opportunity.Opportunity(contact, company);

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.Contact);
        }

        [Fact]
        public void Ctor3()
        {
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.Contact);

        }

        [Fact]
        public void Ctor4()
        {
            Company company = new Company(company1);
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).With(company).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.Contact);
        }

        [Fact]
        public void Ctor4b()
        {
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).With(company1).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(company1, op1.Company.Name);
            Assert.Equal(contact, op1.Contact);
        }

        [Fact]
        public void Ctor5()
        {
            var role = new Role()
            {
                Title = "Software Architect",
                Description = "Do Everything"
            };
            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).As(role).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(role, op1.Role);
            Assert.Equal(contact, op1.Contact);
        }

        [Fact]
        public void Ctor6()
        {

            var contact = new Person();
            var op1 = new OpportunityBuilder(contact).As(title1).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(title1, op1.Role.Title);
            Assert.Equal(contact, op1.Contact);
        }

        [Fact]
        public void Ctor7()
        {
            var contact = new Website(new Uri("http://solidium.com"));
            var op1 = new OpportunityBuilder(contact).Opportunity();

            Assert.NotNull(op1);
            Assert.Equal(contact, op1.Contact);

        }


    }


}


