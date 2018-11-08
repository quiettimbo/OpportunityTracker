using System;
using System.Collections.Generic;
using System.Text;

namespace OpportunityData
{
    public class Website : Contact
    {
        public Website()
        {

        }

        public string Uri { get; set; }

        public override string DisplayName => Uri.ToString();
    }
}
