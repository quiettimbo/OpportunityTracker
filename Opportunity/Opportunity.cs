using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opportunity
{
    public class Opportunity
    {
        private readonly IList<Activity> activities = new List<Activity>();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Contact PrimaryContact { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public DateTime Time { get; set; }
        public IEnumerable<Activity> Activities { get => activities; }
        public bool IsActive { get; set; }

        public Opportunity()
        {

        }

        public Opportunity(Contact contact):this()
        {
            PrimaryContact = contact;
            Time = DateTime.Now;
        }

        public Opportunity(Contact contact, Company company) : this(contact)
        {
            Company = company;
        }

        public Opportunity(Contact contact, Company company, IEnumerable<Activity> activities) : this(contact, company)
        {
            foreach(Activity act in activities)
            {
                this.activities.Add(act);
            }
        }

        internal void AddActivity(Activity act)
        {
            this.activities.Add(act);
        }

    }
}
