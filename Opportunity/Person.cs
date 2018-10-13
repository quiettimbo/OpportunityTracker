using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity
{
    public class Person : IContact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }

        public string DisplayName => $"{LastName}, {FirstName}";

        public object Email { get; set; }
    }
}
