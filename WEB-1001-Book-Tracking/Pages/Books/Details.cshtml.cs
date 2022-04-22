using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_1001_Book_Tracking.Data;
using WEB_1001_Book_Tracking.Models;

namespace WEB_1001_Book_Tracking.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_1001_Book_Tracking.Data.BookTrackingDbContext _context;

        public DetailsModel(WEB_1001_Book_Tracking.Data.BookTrackingDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books
                .Include(b => b.Category).FirstOrDefaultAsync(m => m.ISBN == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
