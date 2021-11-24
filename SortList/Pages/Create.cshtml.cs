using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SortList.Data;
using SortList.Models;

namespace SortList.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SortList.Data.RazorPagesSortListContext _context;

        public CreateModel(SortList.Data.RazorPagesSortListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListData ListData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ListData.Add(ListData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
