using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity
{
    public class Website : Contact
    {
        public Website()
        {

        }

        public Website(Uri uri):this()
        {
            Uri = uri;
        }

        public Uri Uri { get; set; }

        public override string DisplayName => Uri.ToString();
    }
}
