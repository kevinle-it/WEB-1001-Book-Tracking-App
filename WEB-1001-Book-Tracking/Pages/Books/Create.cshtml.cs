using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_1001_Book_Tracking.Data;
using WEB_1001_Book_Tracking.Models;

namespace WEB_1001_Book_Tracking.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly WEB_1001_Book_Tracking.Data.BookTrackingDbContext _context;

        public CreateModel(WEB_1001_Book_Tracking.Data.BookTrackingDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "NameToken", "NameToken");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
