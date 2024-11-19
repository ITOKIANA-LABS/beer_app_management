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

            return CreatedAtAction(nameof(GetById), new { id = wsStockModel.Id }, wsStockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{beerId}")]
        public IActionResult UpdateStock([FromRoute] int beerId, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var wSStockModel = _context.WSStock.FirstOrDefault(b => b.BeerId == beerId);

            if(wSStockModel == null)
            {
                return NotFound();
            }

            wSStockModel.Quantity = updateStockDto.Quantity;

            _context.SaveChanges();

            return Ok(wSStockModel.ToStockDto());
        }
    }
}