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

namespace OpportunityTracker.Pages.Opportunities
{
    public class EditModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public EditModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OpportunityData.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opportunity = await _context.Opportunities
                .Include(o => o.Company)
                .FirstOrDefaultAsync(m => m.OpportunityID == id);

            if (Opportunity == null)
            {
                return NotFound();
            }

            ViewData["CompanyID"] = new SelectList(_context.Companies, "CompanyID", "CompanyID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Opportunity).State = EntityState.Modified;
            var oppToUpdate = await _context.Opportunities.FindAsync(id);

            if (await TryUpdateModelAsync(
                oppToUpdate,
                "opportunity",
                o => o.Description, o => o.Title, o => o.IsActive, o => o.CompanyID, o => o.Time))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpportunityExists(Opportunity.OpportunityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private bool OpportunityExists(int id)
        {
            return _context.Opportunities.Any(e => e.OpportunityID == id);
        }
    }
}
