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
    public class DeleteModel : PageModel
    {
        private readonly SortList.Data.RazorPagesSortListContext _context;

        public DeleteModel(SortList.Data.RazorPagesSortListContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListData = await _context.ListData.FindAsync(id);

            if (ListData != null)
            {
                _context.ListData.Remove(ListData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
