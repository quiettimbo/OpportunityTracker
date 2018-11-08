using System;
using System.Collections.Generic;
using System.Text;

namespace OpportunityData
{
    public class Person : Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }

        public override string DisplayName
        {
            get
            {
                return Company != null 
                    ? $"{LastName}, {FirstName} of {Company.Name}"
                    : $"{LastName}, {FirstName}";
            }
        }

        public string Email { get; set; }
    }
}
