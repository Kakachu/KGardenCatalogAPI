using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Products")]
    public class Product
    {
        public Product(string name, string description, string imageUrl, decimal price, float stock, Guid? categoryId)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Stock = stock;
            DateCreated = DateTime.Now;
            CategoryId = categoryId;
        }

        public Product(Product _this, string name, string description, string imageUrl, decimal price, float stock, Guid? categoryId)
        {
            Id = _this.Id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            Price = price;
            Stock = stock;
            DateCreated = _this.DateCreated;
            CategoryId = categoryId;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; private set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; private set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; private set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; private set; }

        public float Stock { get; private set; }

        public DateTime DateCreated { get; private set; }

        public Guid? CategoryId { get; private set; }

        public Category? Category { get; private set; }
    }
}
