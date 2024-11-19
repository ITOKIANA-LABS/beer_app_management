using api.Data;
using beer_app_management.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace beer_app_management.Controllers
{
    [Route("api/v1/beer")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public BeerController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var beers = _context.Beer.ToList()
            .Select(b => b.ToBeweryBeerDto());

            return Ok(beers);
        }
    }
}