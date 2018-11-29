using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpportunityTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunityTracker.Pages.Opportunities
{
    public class CompanyNamesPageModel : PageModel
    {
        public SelectList CompanyNameSL { get; set; }

        public void PopulateCompaniesDropDownList(OpportunityTrackerContext _context,
                                                    object selectedCompany = null)
        {
            var companiesQuery = from c in _context.Companies
                                   orderby c.Name // Sort by name.
                                   select c;

            CompanyNameSL = new SelectList(companiesQuery.AsNoTracking(),
                        "CompanyID", "Name", selectedCompany);
        }

    }
}
