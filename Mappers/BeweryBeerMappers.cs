

using beer_app_management.Dtos.Beer;
using beer_app_management.Models;

namespace beer_app_management.Mappers
{
    public static class BeweryBeerMappers
    {
        public static BeweryBeerDto ToBeweryBeerDto (this Beer beerModel)
        {
            return new BeweryBeerDto
            {
                Id = beerModel.Id,
                Name = beerModel.Name,
                Alcohol = beerModel.Alcohol,
                Price = beerModel.Price
            };
        }

        public static Beer ToBeerFromAddBeerDto (this AddBeerRequestDto addBeerRequestDto)
        {
            return new Beer
            {
                Name = addBeerRequestDto.Name,
                Alcohol = addBeerRequestDto.Alcohol,
                Price = addBeerRequestDto.Price
            };
        }
    }
}