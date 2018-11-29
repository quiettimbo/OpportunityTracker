using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpportunityData;
using OpportunityTracker.Data;
using OpportunityTracker.Pages.Opportunities;

namespace OpportunityTracker.Pages.Contacts
{
    public class CreateModel : CompanyNamesPageModel
    {
        private readonly OpportunityTracker.Data.OpportunityTrackerContext _context;

        public CreateModel(OpportunityTracker.Data.OpportunityTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateCompaniesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Website Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contact.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}