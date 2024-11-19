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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBeerRequestDto updateBeerDto)
        {
            var beerModel = _context.Beer.FirstOrDefault(b => b.Id == id);

            if(beerModel == null)
            {
                return NotFound();
            }

            beerModel.Name = updateBeerDto.Name;
            beerModel.Alcohol = updateBeerDto.Alcohol;
            beerModel.Price = updateBeerDto.Price;

            _context.SaveChanges();

            return Ok(beerModel.ToBeweryBeerDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var beerModel = _context.Beer.FirstOrDefault(b => b.Id == id);

            if(beerModel == null)
            {
                return NotFound();
            }

            _context.Beer.Remove(beerModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}