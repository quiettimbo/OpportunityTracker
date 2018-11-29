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
    public class DetailsModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public DetailsModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public Activity Activity { get; set; }

        public async Task<IActionResult> OnGetAsync(int OId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity = await _context.Activity
                .Where(a => a.OpportunityID == OId)
                .Include(a => a.Opportunity)
                .FirstOrDefaultAsync(m => m.ActivityID == id);

            if (Activity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
