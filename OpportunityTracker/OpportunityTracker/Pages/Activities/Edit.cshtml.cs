using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Activities
{
    public class EditModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public EditModel(OpportunityTracker.Data.OpportunityTrackerContext context)
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
           ViewData["OpportunityID"] = new SelectList(_context.Opportunities, "OpportunityID", "OpportunityID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int OId, int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(Activity.ActivityID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Opportunities/Details", new { id = OId });
        }

        private bool ActivityExists(int id)
        {
            return _context.Activity.Any(e => e.ActivityID == id);
        }
    }
}
