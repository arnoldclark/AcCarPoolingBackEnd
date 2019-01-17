using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcCarPooling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly CarPoolContext _carPoolContext;

        public JourneyController(CarPoolContext carPoolContext)
        {
            _carPoolContext = carPoolContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Journey> Get()
        {
            var journey = _carPoolContext.Journeys
                .Include(j => j.Users);

            return Ok(journey);
        }

        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<Journey> Get(int id)
        {
            var journey = _carPoolContext.Journeys
                .Include(j => j.Users)
                .FirstOrDefault(x => x.Id == id);

            return Ok(journey);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Journey journey)
        {
            _carPoolContext.Journeys.Add(journey);
            _carPoolContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] Journey journey)
        {
            _carPoolContext.Update(journey);
            _carPoolContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("AddLiftRequest")]
        public ActionResult AddLiftRequest([FromBody] LiftRequest liftRequest)
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

        // PUT api/values/5
        [HttpPut("RejectLiftRequest")]
        public ActionResult RejectLiftRequest([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j == liftRequest.Journey);

            if (journey == null)
                return NotFound("Journey Not Found");

            if(!journey.LiftRequests.Remove(liftRequest))
                return NotFound("Unable to remove LiftRequest from Journey");
        
            _carPoolContext.SaveChanges();

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("AcceptLiftRequest")]
        public ActionResult AcceptLiftRequest([FromBody] LiftRequest liftRequest)
        {
            if (liftRequest == null)
                return BadRequest();

            var journey = _carPoolContext.Journeys
                .FirstOrDefault(j => j == liftRequest.Journey);

            if (journey == null)
                return NotFound("Journey Not Found");

            if (!journey.LiftRequests.Remove(liftRequest))
                return NotFound("Unable to remove LiftRequest from Journey");

            journey.Users.Add(liftRequest.Passenger);

            _carPoolContext.SaveChanges();

            return Ok();
        }
    }
}