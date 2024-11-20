
using beer_app_management.Dtos.WSStock;
using beer_app_management.Models;

namespace beer_app_management.Mappers
{
    public static class WSStockMappers
    {
        public static WSStockDto ToStockDto (this WSStock stockModel, Beer beer)
        {
            return new WSStockDto
            {
                Id = stockModel.Id,
                Quantity = stockModel.Quantity,
                Beer = beer.ToBeweryBeerDto(),
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
        public static OrderDto ToOrderDto (this WSStock stockModel, Beer beer, int qtyOrder, decimal priceTTC, string discount)
        {
            return new OrderDto
            {
                Beer = beer.ToBeweryBeerDto(),
                Quantity = qtyOrder,
                PriceTTC = priceTTC,
                Discount = discount
            };
        }
    }
}