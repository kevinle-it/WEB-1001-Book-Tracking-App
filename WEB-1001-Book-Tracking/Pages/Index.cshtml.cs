using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_1001_Book_Tracking.Data;
using local = WEB_1001_Book_Tracking.Models;
using schema = Schema.NET;

namespace WEB_1001_Book_Tracking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_1001_Book_Tracking.Data.BookTrackingDbContext _context;

        public IndexModel(WEB_1001_Book_Tracking.Data.BookTrackingDbContext context)
        {
            _context = context;
        }

        public ICollection<schema.Thing> JSONLD { get; set; }

        public IList<local.Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Category)
                .ThenInclude(c => c.Type)
                .ToListAsync();

            List<schema.Thing> list = new List<schema.Thing>();
            foreach (var book in Book)
            {
                list.Add(book.GetJson());
            }

            JSONLD = list;
        }
    }
}
