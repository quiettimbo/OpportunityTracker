using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpportunityData
{
    public class Person : Contact
    {
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        public override string DisplayName
        {
            get
            {
                return Company != null 
                    ? $"{LastName}, {FirstName} of {Company.Name}"
                    : $"{LastName}, {FirstName}";
            }
        }

        [DataType(DataType.EmailAddress)]
        [StringLength(1024, ErrorMessage = "Email cannot be longer than 1000 characters.")]
        public string Email { get; set; }
    }
}
