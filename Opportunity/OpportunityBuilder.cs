using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity
{
    public class OpportunityBuilder : OpportunityBuilder.IRoleBuilder
    {
        private readonly IContact contact;
        private Company company;
        private Role role;

        public OpportunityBuilder(IContact contact)
        {
            this.contact = contact;

        }
        public Opportunity Opportunity()
        {
            var op = new Opportunity(contact)
            {
                Company = company,
                Role = role
            };
            return op;
        }

        public IOpportunityBuilder With(Company company)
        {
            this.company = company;
            return this;
        }

        public IOpportunityBuilder With(string company)
        {
            this.company = new Company(company);
            return this;
        }

        public IOpportunityBuilder As(Role role)
        {
            this.role = role;
            return this;
        }
        public OpportunityBuilder.IRoleBuilder As(string title)
        {
            this.role = new Role
            {
                Title = title
            };
            return this;
        }

        IRoleBuilder IRoleBuilder.Doing(string description)
        {
            role.Description = description;
            return this;
        }

        public interface IRoleBuilder : OpportunityBuilder.IOpportunityBuilder
        {
            OpportunityBuilder.IRoleBuilder Doing(string description);
        }

        public interface IOpportunityBuilder
        {
            Opportunity Opportunity();
            OpportunityBuilder.IRoleBuilder As(string title);
            IOpportunityBuilder As(Role role);
            IOpportunityBuilder With(Company company);
        }
    }
}
