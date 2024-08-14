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

        public string? Name { get; private set; }

        public string? Description { get; private set; }

        public string? ImageUrl { get; private set; }

        public decimal Price { get; private set; }

        public float Stock { get; private set; }

        public DateTime DateCreated { get; private set; }

        public Guid? CategoryId { get; private set; }

        public Category? Category { get; private set; }
    }
}
