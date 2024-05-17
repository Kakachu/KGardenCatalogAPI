using Domain.Models;
using System.Text.Json.Serialization;

namespace Application.ViewModels
{
    public class ProductViewModel
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("stock")]
        public float Stock { get; set; }

        [JsonPropertyName("categoryId")]
        public Guid? CategoryId { get; set; }
    }
}
