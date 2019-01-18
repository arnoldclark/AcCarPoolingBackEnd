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
        
        [HttpPost]
        public ActionResult<User> SignUp([FromBody] User user)
        {
            _carPoolContext.Users.Add(user);
            _carPoolContext.SaveChanges();

            return Ok(user);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_carPoolContext.Users);
        }
        
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_carPoolContext.Users.FirstOrDefault(u => u.Id == id));
        }
        
        [HttpPut]
        public void Put([FromBody] User user)
        {
            _carPoolContext.Users.Update(user);
            _carPoolContext.SaveChanges();
        }

        [HttpGet("GetByEmail/{email}")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = _carPoolContext.Users.FirstOrDefault(u => u.Email == email);
            return Ok(user);
        }
    }
}
