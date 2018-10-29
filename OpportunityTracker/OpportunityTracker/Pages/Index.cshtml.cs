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
    public class IndexModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public IndexModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public bool? showIsActive;

        public IList<Opportunity.Opportunity> Opportunity { get;set; }

        public async Task OnGetAsync(bool? isActive)
        {
            showIsActive = isActive;

            IQueryable<Opportunity.Opportunity> query = _context.Opportunities;
            if (isActive.HasValue)
            {
                query = query.Where(o => o.IsActive == isActive.Value);
            }
            Opportunity = await query.ToListAsync();
        }
    }
}
