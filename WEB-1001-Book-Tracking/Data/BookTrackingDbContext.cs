using Microsoft.EntityFrameworkCore;
using WEB_1001_Book_Tracking.Models;

namespace WEB_1001_Book_Tracking.Data
{
    public class BookTrackingDbContext : DbContext
    {
        public BookTrackingDbContext(DbContextOptions<BookTrackingDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
    }
}
