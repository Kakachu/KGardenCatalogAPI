using Newtonsoft.Json;

namespace Application.ViewModels
{
    public class CategoryViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("products")]
        public List<ProductViewModel> Products { get; set; }
    }
}
