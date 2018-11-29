using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpportunityData
{
    public class Website : Contact
    {
        public Website()
        {

        }

        [DataType(DataType.Url)]
        [StringLength(4096, ErrorMessage = "Email cannot be longer than 4000 characters.")]
        public string Uri { get; set; }

        public override string DisplayName => Uri.ToString();
    }
}
