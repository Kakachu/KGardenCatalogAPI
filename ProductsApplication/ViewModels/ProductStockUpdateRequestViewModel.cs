using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProductStockUpdateRequestViewModel
    {
        [Range(1, 9999, ErrorMessage = "Stock value must be between {1} and {2}")]
        public float Stock { get; set; }
    }
}
