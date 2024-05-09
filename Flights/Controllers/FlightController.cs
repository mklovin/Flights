using Flights.ReadModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Flights.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class FlightController : ControllerBase
    {

        private readonly ILogger<FlightController> logger;
        static Random _random = new Random();
        static private FlightRm[] flights =  new FlightRm[]
               {
        new (   Guid.NewGuid(),
                "American Airlines",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Los Angeles",DateTime.Now.AddHours(_random.Next(1, 3))),
                new TimePlaceRm("Istanbul",DateTime.Now.AddHours(_random.Next(4, 10))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                "Deutsche BA",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Munchen",DateTime.Now.AddHours(_random.Next(1, 10))),
                new TimePlaceRm("Schiphol",DateTime.Now.AddHours(_random.Next(4, 15))),
                _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                "British Airways",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("London, England",DateTime.Now.AddHours(_random.Next(1, 15))),
                new TimePlaceRm("Vizzola-Ticino",DateTime.Now.AddHours(_random.Next(4, 18))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                   "Basiq Air",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Amsterdam",DateTime.Now.AddHours(_random.Next(1, 21))),
                new TimePlaceRm("Glasgow, Scotland",DateTime.Now.AddHours(_random.Next(4, 21))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                   "BB Heliag",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Zurich",DateTime.Now.AddHours(_random.Next(1, 23))),
                new TimePlaceRm("Baku",DateTime.Now.AddHours(_random.Next(4, 25))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                   "Adria Airways",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Ljubljana",DateTime.Now.AddHours(_random.Next(1, 15))),
                new TimePlaceRm("Warsaw",DateTime.Now.AddHours(_random.Next(4, 19))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                   "ABA Air",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Praha Ruzyne",DateTime.Now.AddHours(_random.Next(1, 55))),
                new TimePlaceRm("Paris",DateTime.Now.AddHours(_random.Next(4, 58))),
                    _random.Next(1, 853)),
        new (   Guid.NewGuid(),
                   "AB Corporate Aviation",
                _random.Next(90, 5000).ToString(),
                new TimePlaceRm("Le Bourget",DateTime.Now.AddHours(_random.Next(1, 58))),
                new TimePlaceRm("Zagreb",DateTime.Now.AddHours(_random.Next(4, 60))),
                    _random.Next(1, 853))
               };
    
 
        private readonly ILogger<FlightController> _logger;

        public FlightController( ILogger<FlightController> logger )
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FlightRm>), 200)]
        public IEnumerable<FlightRm> Search()
             => flights;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FlightRm), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<FlightRm> Find( Guid id )
        {

            var flight = flights.SingleOrDefault(x => x.Id == id);
            if(flight == null)
                return NotFound();

            return Ok(flight); 
        }
    }
        
}