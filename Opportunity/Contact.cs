using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OpportunityData
{
    public class Contact : IContact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Company Company { get; set; }
        public int? CompanyID { get; set; }

        public virtual string DisplayName => throw new NotImplementedException();
    }
}
