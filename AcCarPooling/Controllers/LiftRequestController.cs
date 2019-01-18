using System.Collections.Generic;
using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexmo.Api;

namespace AcCarPooling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LiftRequestController : ControllerBase
    {
        private readonly CarPoolContext _carPoolContext;
        private readonly Client _nexmoSmsClient;

        //public LiftRequestController(CarPoolContext carPoolContext, Client nexmoSmsClient)
        public LiftRequestController(CarPoolContext carPoolContext)

        {
            _carPoolContext = carPoolContext;
            //_nexmoSmsClient = nexmoSmsClient;
        }

        [HttpPost]
        public ActionResult Post([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j.Id == liftRequest.JourneyId);

            if (journey == null)
                return NotFound("Journey Not Found");

            if (journey.LiftRequests == null)
            {
                journey.LiftRequests = new List<LiftRequest>();
            }

            journey.LiftRequests.Add(liftRequest);
            
            _carPoolContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j.Id == liftRequest.JourneyId);

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
            var trackedLiftRequest = _carPoolContext.LiftRequests.FirstOrDefault(x=>x.Id == liftRequest.Id);

            if (trackedLiftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys.Include(x=>x.LiftRequests)
                .FirstOrDefault(j => j.Id == trackedLiftRequest.JourneyId);

            if (journey == null)
                return NotFound("Journey Not Found");

            if (!journey.LiftRequests.Remove(trackedLiftRequest))
                return NotFound("Unable to remove LiftRequest from Journey");

            var passenger = _carPoolContext.Users.FirstOrDefault(x => x.Id == liftRequest.PassengerId);

            if (passenger == null)
                return NotFound("Unable to find passenger");

            if(journey.Passengers == null)
                journey.Passengers = new List<User>();

            journey.Passengers.Add(passenger);

            _carPoolContext.SaveChanges();


            //var driver = journey.Passengers.FirstOrDefault(p => p.IsDriver);
            //if(driver != null)
            //{
            //    _nexmoSmsClient.SMS.Send(request: new SMS.SMSRequest
            //    {
            //        from = "",
            //        to = passenger.PhoneNumber,
            //        text = $"Your lift request with {driver.Name} has been accepted."
            //    });
            //}

            return Ok();
        }
    }
}
