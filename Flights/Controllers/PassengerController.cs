using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flights.Dtos;
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
        public IActionResult Register( NewPassengerDto dto) {

            passengers.Add(dto);
            System.Diagnostics.Debug.WriteLine(passengers.Count());
            return Ok() ; 
        
        }
    }
}
