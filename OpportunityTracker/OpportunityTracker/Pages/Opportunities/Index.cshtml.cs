using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.Opportunity
{
    public class IndexModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public IndexModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public IList<OpportunityData.Opportunity> Opportunity { get;set; }

        public async Task OnGetAsync()
        {
            Opportunity = await _context.Opportunities
                .Include(o => o.Company).ToListAsync();
        }
    }
}
