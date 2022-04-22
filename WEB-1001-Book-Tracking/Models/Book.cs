using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using schema = Schema.NET;

namespace WEB_1001_Book_Tracking.Models
{
    public class Book
    {
        [Key]
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [ForeignKey("Category")]
        [Display(Name = "Category")]
        [Required]
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public schema.Book GetJson()
        {
            schema.Book book = new schema.Book();

            book.Isbn = this.ISBN;
            book.Name = this.Title;
            book.Author = new schema.Person() { Name = this.Author };
            book.About = new schema.CreativeWork()
                {
                    Genre = this.Category.NameToken,
                    IsPartOf = new schema.CreativeWork() { Genre = this.Category.Type.Name }
                };

            return book;
        }
    }
}
