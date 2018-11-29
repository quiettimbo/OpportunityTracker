using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public IndexModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public IList<Activity> Activity { get;set; }

        public async Task OnGetAsync(int OId)
        {
            Activity = await _context.Activity
                .Where(a => a.OpportunityID == OId)
                .Include(a => a.Opportunity).ToListAsync();
        }
    }
}
