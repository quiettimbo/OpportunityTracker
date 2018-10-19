using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opportunity
{
    public class Opportunity
    {
        public Contact Contact { get; set; }
        public Role Role { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Opportunity()
        {

        }

        public Opportunity(Contact contact):this()
        {
            Contact = contact;
            Time = DateTime.Now;
        }

        public Opportunity(Contact contact, Company company) : this(contact)
        {
            Company = company;
        }

        public Company Company { get; set; }
        public DateTime Time { get; set; }
    }
}
