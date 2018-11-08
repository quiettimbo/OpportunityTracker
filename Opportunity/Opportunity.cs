using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpportunityData
{
    public class Opportunity
    {
        private readonly IList<Activity> activities = new List<Activity>();

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OpportunityID { get; set; }
        public Contact PrimaryContact { get; set; }
        public string Title { get; set; }
        [StringLength(4096, ErrorMessage = "Description Cannot be longer than 4086 chars")]
        public string Description { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public DateTime Time { get; set; }

        public ICollection<Activity> Activities { get; set; }
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
