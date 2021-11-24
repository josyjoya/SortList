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
    public class DetailsModel : PageModel
    {
        private readonly SortList.Data.RazorPagesSortListContext _context;

        public DetailsModel(SortList.Data.RazorPagesSortListContext context)
        {
            _context = context;
        }

        public ListData ListData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListData = await _context.ListData.FirstOrDefaultAsync(m => m.Id == id);

            if (ListData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
