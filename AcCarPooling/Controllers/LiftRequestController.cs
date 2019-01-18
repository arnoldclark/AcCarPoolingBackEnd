using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Mvc;
using Nexmo.Api;

namespace AcCarPooling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LiftRequestController : ControllerBase
    {
        private readonly CarPoolContext _carPoolContext;
        private readonly Client _nexmoSmsClient;

        public LiftRequestController(CarPoolContext carPoolContext, Client nexmoSmsClient)
        {
            _carPoolContext = carPoolContext;
            _nexmoSmsClient = nexmoSmsClient;
        }

        [HttpPost]
        public ActionResult Post([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j == liftRequest.Journey);

            if (journey == null)
                return NotFound("Journey Not Found");

            journey.LiftRequests.Add(liftRequest);

            _carPoolContext.Add(journey);
            _carPoolContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j == liftRequest.Journey);

            if (journey == null)
                return NotFound("Journey Not Found");

            if (!journey.LiftRequests.Remove(liftRequest))
                return NotFound("Unable to remove LiftRequest from Journey");

            _carPoolContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j == liftRequest.Journey);

            if (journey == null)
                return NotFound("Journey Not Found");

            if (!journey.LiftRequests.Remove(liftRequest))
                return NotFound("Unable to remove LiftRequest from Journey");

            journey.Passengers.Add(liftRequest.Passenger);

            _carPoolContext.SaveChanges();


            var driver = journey.Passengers.FirstOrDefault(p => p.IsDriver);
            if(driver != null)
            {
                _nexmoSmsClient.SMS.Send(request: new SMS.SMSRequest
                {
                    from = "",
                    to = liftRequest.Passenger.PhoneNumber,
                    text = $"Your lift request with {driver.Name} has been accepted."
                });
            }

            return Ok();
        }
    }
}
