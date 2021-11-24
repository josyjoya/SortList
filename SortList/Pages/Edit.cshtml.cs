using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SortList.Data;
using SortList.Models;

namespace SortList.Pages
{
    public class EditModel : PageModel
    {
        private readonly SortList.Data.RazorPagesSortListContext _context;

        public EditModel(SortList.Data.RazorPagesSortListContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListDataExists(ListData.Id))
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

        private bool ListDataExists(int id)
        {
            return _context.ListData.Any(e => e.Id == id);
        }
    }
}
