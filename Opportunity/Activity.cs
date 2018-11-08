using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpportunityData
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityID { get; set; }
        public string Description { get; set; }
        public Contact Contact { get; set; }

        public int OpportunityID { get; set; }
        public Opportunity Opportunity { get; set; }

        public DateTime Date { get; set; }
        public ResultType Result { get; set; }

        //public Opportunity Position
        //{
        //    get
        //    {
        //        return Opportunity;
        //    }
        //    set
        //    {
        //        Opportunity = value;
        //        value.AddActivity(this);
        //    }
        //}

        public enum ResultType
        {
            NoResponse,
            NoWork,
            FollowUpRequested
        }
    }
}