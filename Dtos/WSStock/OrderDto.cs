

using beer_app_management.Dtos.Beer;
using beer_app_management.Models;

namespace beer_app_management.Dtos.WSStock
{
    public class OrderDto
    {
        public required BeweryBeerDto Beer { get; set; }
        public int Quantity { get; set; }
        public decimal PriceTTC { get; set; }
        public string Discount { get; set; } = string.Empty;
    }
}