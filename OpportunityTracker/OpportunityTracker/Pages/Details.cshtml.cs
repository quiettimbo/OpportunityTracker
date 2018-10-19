using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Opportunity;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public DetailsModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public Opportunity.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opportunity = await _context.Opportunities
                                    .Include(o => o.Role)
                                    .Include(o => o.Company)
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (Opportunity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
