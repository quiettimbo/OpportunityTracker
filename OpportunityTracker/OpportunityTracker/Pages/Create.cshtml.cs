using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Opportunity;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages
{
    public class CreateModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public CreateModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Opportunity.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyOpportunity = new Opportunity.Opportunity();

            // prevents overposting - alternatively use a ViewModel
            if (await TryUpdateModelAsync<Opportunity.Opportunity>(
                emptyOpportunity,
                "opportunity",
                o => o.Time))
            {
                _context.Opportunities.Add(emptyOpportunity);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}