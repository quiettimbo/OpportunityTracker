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
    public class DeleteModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public DeleteModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Activity Activity { get; set; }

        public async Task<IActionResult> OnGetAsync(int OId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity = await _context.Activity
                .Include(a => a.Opportunity).FirstOrDefaultAsync(m => m.ActivityID == id);

            if (Activity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int OId, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Activity = await _context.Activity.FindAsync(id);

            if (Activity != null)
            {
                _context.Activity.Remove(Activity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Opportunities/Details", new { id = OId });
        }
    }
}
