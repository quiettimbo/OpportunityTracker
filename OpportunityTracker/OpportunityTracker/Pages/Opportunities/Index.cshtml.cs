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
        private readonly OpportunityTrackerContext _context;


        public IndexModel(OpportunityTrackerContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string TimeSort { get; set; }
        public string DescriptionSort { get; set; }
        public string CompanySort { get; set; }
        public bool? IsActiveFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<OpportunityData.Opportunity> Opportunity { get;set; }

        public async Task OnGetAsync(string sortOrder, bool? isActive,
            int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            TimeSort = sortOrder == "Time" ? "Time_desc" : "Time";
            DescriptionSort = sortOrder == "Description" ? "Desc_desc" : "Description";
            CompanySort = sortOrder == "Company" ? "Company_desc" : "Company";
            if (isActive.HasValue)
            {
                pageIndex = 1;
            }
            else
            {
                isActive = IsActiveFilter;
            }
            IsActiveFilter = isActive;

            IQueryable<OpportunityData.Opportunity> query = _context.Opportunities
                .Include(o => o.Company);

            if (IsActiveFilter.HasValue)
            {
                query = query.Where(o => o.IsActive == IsActiveFilter.Value);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    query = query.OrderByDescending(o => o.Title);
                    break;
                case "Description":
                    query = query.OrderBy(o => o.Description);
                    break;
                case "Desc_desc":
                    query = query.OrderByDescending(o => o.Description);
                    break;
                case "Company":
                    query = query.OrderBy(o => o.Company.Name);
                    break;
                case "Company_desc":
                    query = query.OrderByDescending(o => o.Company.Name);
                    break;
                case "Time":
                    query = query.OrderBy(o => o.Time);
                    break;
                case "Time_desc":
                    query = query.OrderByDescending(o => o.Time);
                    break;
                default:
                    query = query.OrderBy(o => o.Title);
                    break;
            }

            int pageSize = 5;
            Opportunity = await PaginatedList<OpportunityData.Opportunity>
                .CreateAsync(query.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
