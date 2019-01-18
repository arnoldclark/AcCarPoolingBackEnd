using System.Collections.Generic;
using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using AcCarPooling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcCarPooling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly CarPoolContext _carPoolContext;
        private readonly IJourneyService _journeyService;

        public JourneyController(CarPoolContext carPoolContext, IJourneyService journeyService)
        {
            _carPoolContext = carPoolContext;
            _journeyService = journeyService;
        }
        
        [HttpGet]
        public ActionResult<Journey> Get()
        {
            var journeys = _journeyService.GetAllJourneys();

            return Ok(journeys);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Journey>> Get(int id)
        {
            var journey = _carPoolContext.Journeys
                .Include(j => j.Passengers)
                .Where(j => j.Passengers.Any(u => u.Id == id));

            return Ok(journey);
        }

        [HttpPost]
        public void Post([FromBody] Journey journey)
        {
            _journeyService.AddJourney(journey);
        }

        [HttpPut]
        public void Put([FromBody] Journey journey)
        {
            _journeyService.UpdateJourney(journey);
        }
    }
}