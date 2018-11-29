using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpportunityData
{
    public class Company
    {
        public Company()
        {

        }

        public Company(string company1):this()
        {
            this.Name = company1;
        }

        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }

        public string Description { get; set; }
        [StringLength(4096, ErrorMessage = "Website cannot be longer than 4000 characters.")]
        public string Website { get; set; }
        [StringLength(4096, ErrorMessage = "LinkedIn Url cannot be longer than 4000 characters.")]
        public string LinkedInUrl { get; set; }
    }
}
