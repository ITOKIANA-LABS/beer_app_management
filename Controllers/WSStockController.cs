using api.Data;
using beer_app_management.Dtos.WSStock;
using beer_app_management.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace beer_app_management.Controllers
{
    [Route("api/v1/wsstocks")]
    [ApiController]
    public class WSStockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public WSStockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.WSStock.ToList();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.WSStock.Find(id);

            if(stock == null)
            {
                return NotFound();
            }
            
            return Ok(stock);
        }

        [HttpPost]
        public IActionResult AddToStock([FromBody] AddToStockRequestDto stockDto)
        {
            var wsStockModel = stockDto.ToStockFromUpdateStockDto();
            _context.WSStock.Add(wsStockModel);
            _context.SaveChanges();

            var beerModel = _context.Beer.Find(stockDto.BeerId);

            if(beerModel == null)
            {
                return StatusCode(500, "No type of beer found");
            }

            return CreatedAtAction(nameof(GetById), new { id = wsStockModel.Id }, wsStockModel.ToStockDto(beerModel));
        }

        [HttpPut]
        [Route("{beerId}/update_stock")]
        public IActionResult UpdateStock([FromRoute] int beerId, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var wSStockModel = _context.WSStock.FirstOrDefault(b => b.BeerId == beerId);
            var beerModel = _context.Beer.Find(beerId);

            if(wSStockModel == null || beerModel == null)
            {
                return NotFound();
            }

            wSStockModel.Quantity += updateStockDto.Quantity;

            _context.SaveChanges();

            return Ok(wSStockModel.ToStockDto(beerModel));
        }

        [HttpPut]
        [Route("{beerId}/new_order")]
        public IActionResult Order([FromRoute] int beerId, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var wSStockModel = _context.WSStock.FirstOrDefault(b => b.BeerId == beerId);
            var beerModel = _context.Beer.Find(beerId);
            var qtyOrder = updateStockDto.Quantity;
            decimal priceTTC = 0;
            string discount = "0%";

            if(wSStockModel == null || beerModel == null)
            {
                return NotFound();
            }

            if(wSStockModel.Quantity < qtyOrder)
            {
                return StatusCode(500, "The number of beers ordered cannot be greater than the wholesaler's stock");
            }

            wSStockModel.Quantity -= qtyOrder;

            _context.SaveChanges();

            var totalBasePrice = beerModel.Price * qtyOrder;
            if(qtyOrder >= 10 && qtyOrder < 20)
            {
                priceTTC = totalBasePrice - (totalBasePrice * (decimal)0.1);
                discount = "10%";
            }
            if(qtyOrder >= 20)
            {
                priceTTC = totalBasePrice - (totalBasePrice * (decimal)0.2);
                discount = "20%";
            }

            return Ok(wSStockModel.ToOrderDto(beerModel, qtyOrder, priceTTC, discount));
        }
    }
}