

using beer_app_management.Dtos.WSStock;
using beer_app_management.Models;

namespace beer_app_management.Mappers
{
    public static class WSStockMappers
    {
        public static WSStockDto ToStockDto (this WSStock stockModel)
        {
            return new WSStockDto
            {
                Id = stockModel.Id,
                Quantity = stockModel.Quantity,
                Beer = stockModel.Beer?.ToBeweryBeerDto(),
            };
        }
        public static WSStock ToStockFromUpdateStockDto (this AddToStockRequestDto AddStockRequestDto)
        {
            return new WSStock
            {
                Quantity = AddStockRequestDto.Quantity,
                BeerId = AddStockRequestDto.BeerId,
            };
        }   
    }
}