using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcCarPooling.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcCarPooling.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        [HttpPost]
        public ActionResult SignUp([FromBody] User user)
        {
            return Ok();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new List<User>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(new User());
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
        }
    }
}
