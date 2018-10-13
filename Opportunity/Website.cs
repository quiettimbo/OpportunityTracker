using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity
{
    public class Website : IContact
    {
        public Website(Uri uri)
        {
            Uri = uri;
        }

        public Uri Uri { get; set; }

        public string DisplayName => Uri.ToString();
    }
}
