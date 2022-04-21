using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_1001_Book_Tracking.Models
{
    public class Category
    {
        [Key]
        [Required]
        public string NameToken { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("CategoryType")]
        [Display(Name = "Category Type")]
        [Required]
        public string CategoryTypeId { get; set; }

        public CategoryType Type { get; set; }
    }
}
