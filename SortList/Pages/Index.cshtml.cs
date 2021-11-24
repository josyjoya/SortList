using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SortList.Data;
using SortList.Models;

namespace SortList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SortList.Data.RazorPagesSortListContext _context;

        public IndexModel()
        {
        }

        public IndexModel(SortList.Data.RazorPagesSortListContext context)
        {
            _context = context;
        }

        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }
        public string CurrentSort { get; set; }

        
        public IList<ListData> ListData { get;set; }

        public async Task OnGetAsync(string sortBy)
        {
            FirstNameSort = String.IsNullOrEmpty(sortBy) ? "firstName" : "";
            LastNameSort = String.IsNullOrEmpty(sortBy) ? "lastName" : "";

            IQueryable<ListData> listDataForSort = from lst in _context.ListData select lst;

            switch(sortBy)
            {
                case "firstName":
                    listDataForSort = listDataForSort.OrderBy(f => f.FirstName);
                    break;
                case "lastName":
                    listDataForSort = listDataForSort.OrderBy(l => l.LastName);
                    break;
                default:
                    listDataForSort = listDataForSort.OrderBy(f => f.FirstName).ThenBy(l => l.LastName) ;
                    break;
            }

            ListData = await listDataForSort.AsNoTracking().ToListAsync();
        }
    }
}
