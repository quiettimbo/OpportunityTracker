using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Activities
{
    public class CreateModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public CreateModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int OId)
        {
            Opportunity = await _context.Opportunities.FindAsync(OId);
            Activity = new Activity
            {
                Date = DateTime.Now
            };
            return Page();
        }

        [BindProperty]
        public Activity Activity { get; set; }

        public OpportunityData.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnPostAsync(int OId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Activity.OpportunityID = OId;

            _context.Activity.Add(Activity);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Opportunities/Details", new { id = OId });
        }
    }
}