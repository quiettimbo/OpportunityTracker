using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity
{
    public class Person : Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }

        public override string DisplayName => $"{LastName}, {FirstName}";

        public object Email { get; set; }
    }
}
