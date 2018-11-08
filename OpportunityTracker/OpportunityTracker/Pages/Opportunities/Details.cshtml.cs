using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Opportunities
{
    public class DetailsModel : PageModel
    {
        private readonly OpportunityTrackerContext _context;

        public DetailsModel(OpportunityTrackerContext context)
        {
            _context = context;
        }

        public OpportunityData.Opportunity Opportunity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Opportunity = await _context.Opportunities
                .Include(o => o.Company)
                .Include(o => o.Activities)
                .ThenInclude(y => y.Contact)
                .ThenInclude(c => (c as Person).Company)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OpportunityID == id);

            if (Opportunity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
