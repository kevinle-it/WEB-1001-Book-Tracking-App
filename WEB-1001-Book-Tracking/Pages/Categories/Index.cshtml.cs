using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_1001_Book_Tracking.Data;
using WEB_1001_Book_Tracking.Models;

namespace WEB_1001_Book_Tracking.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly WEB_1001_Book_Tracking.Data.BookTrackingDbContext _context;

        public IndexModel(WEB_1001_Book_Tracking.Data.BookTrackingDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories
                .Include(c => c.Type).ToListAsync();
        }
    }
}
