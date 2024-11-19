
using beer_app_management.Dtos.Beer;

namespace beer_app_management.Dtos.WSStock
{
    public class WSStockDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public BeweryBeerDto? Beer { get; set; }
    }
}