using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
            DateCreated = DateTime.Now;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; private set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; private set; }

        public DateTime DateCreated { get; private set; }   

        public List<Product> Products { get; private set; }
    }
}
