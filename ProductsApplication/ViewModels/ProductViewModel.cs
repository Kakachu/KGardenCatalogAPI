using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.ViewModels
{
    public class ProductViewModel : IValidatableObject
    {
        [JsonPropertyName("id")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "A value for the field name is required")]
        [StringLength(80, ErrorMessage = "The field name must be between 5 and 80 characters long.", MinimumLength = 5)]
        public string? Name { get; set; }

        [StringLength(300, ErrorMessage = "Length of the field description must not exceed {1}}")]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "The price must be between {1} and {2}")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("stock")]
        [Range(1, 9999, ErrorMessage = "Stock value must be between {1} and {2}")]
        public float Stock { get; set; }

        public Guid? CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        {
            if (!string.IsNullOrEmpty(this.Name))
            {

                var firstLetter = this.ToString()[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("The first letter of the field 'Product Name' must be uppercase", new[] { nameof(this.Name) });
                }

                //if (this.Stock <= 0)
                //{
                //    yield return new ValidationResult("The field 'Stock' must be greater than 0", new[] { nameof(this.Stock) });
                //}
            }
        }

    }
}
