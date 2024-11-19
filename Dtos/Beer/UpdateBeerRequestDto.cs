

namespace beer_app_management.Dtos.Beer
{
    public class UpdateBeerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Alcohol { get; set; }
        public decimal Price { get; set; }
    }
}