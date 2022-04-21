using System.ComponentModel.DataAnnotations;

namespace WEB_1001_Book_Tracking.Models
{
    public class CategoryType
    {
        [Key]
        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
