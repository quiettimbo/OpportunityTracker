using System;

namespace Opportunity
{
    public class Opportunity
    {
        public IContact Contact { get; set; }
        public Role Role { get; set; }

        public Opportunity(IContact contact)
        {
            Contact = contact;
            Time = DateTime.Now;
        }

        public Opportunity(IContact contact, Company company) : this(contact)
        {
            Company = company;
        }

        public Company Company { get; set; }
        public DateTime Time { get; set; }
    }
}
