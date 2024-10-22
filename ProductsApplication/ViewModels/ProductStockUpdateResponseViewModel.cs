namespace Application.ViewModels
{
    public class ProductStockUpdateResponseViewModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
