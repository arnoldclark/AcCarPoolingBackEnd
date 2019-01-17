using System.Collections.Generic;
using System.Linq;
using AcCarPooling.Database;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcCarPooling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CarPoolContext _carPoolContext;

        public UsersController(CarPoolContext carPoolContext)
        {
            _carPoolContext = carPoolContext;
        }

        // GET api/values
        [HttpPost]
        public ActionResult SignUp([FromBody] User user)
        {
            _carPoolContext.Users.Add(user);
            _carPoolContext.SaveChanges();

            return Ok();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_carPoolContext.Users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_carPoolContext.Users.FirstOrDefault(u => u.Id == id));
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            _carPoolContext.Users.Update(user);
            _carPoolContext.SaveChanges();
        }
    }
}
