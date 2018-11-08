using System;
using System.Collections.Generic;
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
    }
}
