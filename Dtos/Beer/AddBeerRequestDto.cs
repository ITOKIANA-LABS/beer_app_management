
namespace beer_app_management.Dtos.Beer
{
    public class AddBeerRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Alcohol { get; set; }
        public decimal Price { get; set; }
    }
}