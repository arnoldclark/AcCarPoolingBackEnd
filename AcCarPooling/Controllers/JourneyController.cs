using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Http;
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
        }
    }
}