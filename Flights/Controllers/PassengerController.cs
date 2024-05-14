using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
using Flights.ReadModels;
namespace Flights.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        static private IList<NewPassengerDto> passengers = new List<NewPassengerDto>();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Register( NewPassengerDto dto ) {

            passengers.Add(dto);
            System.Diagnostics.Debug.WriteLine(passengers.Count());
            return CreatedAtAction(nameof(Find), new { email = dto.Email});

        }
        [HttpGet("{email}")]
        public ActionResult<PassengerRm> Find(string email ) {

            var passenger = passengers.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());   

            if (passenger == null) 
                return NotFound();
            else
                return Ok(passenger);
        }
    }
}
