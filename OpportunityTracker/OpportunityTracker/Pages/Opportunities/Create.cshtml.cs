using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Opportunities
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
        ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID");
            return Page();
        }

        [BindProperty]
        public OpportunityData.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Opportunities.Add(Opportunity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}