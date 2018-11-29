using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OpportunityData;
using OpportunityTracker.Data;

namespace OpportunityTracker.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public IndexModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public IList<Person> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact
                .Include(c => c.Company)
                .Where(c=> c is Person)
                .Cast<Person>()
                .ToListAsync();
        }
    }
}
