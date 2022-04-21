using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
