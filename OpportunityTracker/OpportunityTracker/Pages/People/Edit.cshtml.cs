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
using OpportunityTracker.Pages.Opportunities;

namespace OpportunityTracker.Pages.People
{
    public class EditModel : CompanyNamesPageModel

    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public EditModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact
                .Include(c => c.Company)
                .Where(c => c is Person)
                .Cast<Person>()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Contact == null)
            {
                return NotFound();
            }
            PopulateCompaniesDropDownList(_context);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.Id))
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

        private bool ContactExists(string id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}
