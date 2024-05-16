using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; private set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; private set; }
    }
}
