using api.Data;
using beer_app_management.Dtos.Beer;
using beer_app_management.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace beer_app_management.Controllers
{
    [Route("api/v1/beers")]
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

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var beer = _context.Beer.Find(id);

            if(beer == null)
            {
                return NotFound();
            }
            
            return Ok(beer.ToBeweryBeerDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddBeerRequestDto beerDto)
        {
            var beerModel = beerDto.ToBeerFromAddBeerDto();
            _context.Beer.Add(beerModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = beerModel.Id }, beerModel.ToBeweryBeerDto());
        }
    }
}