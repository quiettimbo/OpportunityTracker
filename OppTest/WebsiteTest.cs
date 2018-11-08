using OpportunityData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OppTest
{
    public class WebsiteTest
    {
        private const string UriString = "http://microsoft.com";

        [Fact]
        public void Website1()
        {
            var w1 = new Website
            {
                Uri = UriString
            };
        }
    }
}
