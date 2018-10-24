using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opportunity
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }

        private Opportunity position;

        public DateTime Date { get; set; }
        public ResultType Result { get; set; }

        public Opportunity Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                value.AddActivity(this);
            }
        }

        public enum ResultType
        {
            NoResponse,
            NoWork,
            FollowUpRequested
        }
    }
}