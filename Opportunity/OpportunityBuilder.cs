using System;
using System.Collections.Generic;
using System.Text;

namespace OpportunityData
{
    public class OpportunityBuilder : OpportunityBuilder.IActivityBuilder
    {
        private readonly Contact contact;
        private Company company;
        private IList<Activity> activities = new List<Activity>();
        private string Title;
        private string Description;

        public OpportunityBuilder(Contact contact)
        {
            this.contact = contact;

        }
        public Opportunity Opportunity()
        {
            var op = new Opportunity(contact)
            {
                Company = company,
                Title = Title,
                Description = Description,
            };
            foreach(Activity act in activities)
            {
                op.AddActivity(act);
            }
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

        public IOpportunityBuilder As(string title)
        {
            this.Title = title;
            return this;
        }

        public IOpportunityBuilder Doing(string description)
        {
            Description = description;
            return this;
        }

        public IActivityBuilder Action(string desc)
        {
            activities.Add(new Activity { Description = desc });
            return this;
        }

        public IActivityBuilder Action(Activity activity)
        {
            throw new NotImplementedException();
        }

        public interface IOpportunityBuilder
        {
            Opportunity Opportunity();
            IOpportunityBuilder As(string title);
            IOpportunityBuilder Doing(string title);
            IOpportunityBuilder With(Company company);
        }

        public interface IActivityBuilder : IOpportunityBuilder
        {
        }
    }
}
