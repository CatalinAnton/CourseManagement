using System.Collections.Generic;
using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return _usersService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _usersService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user._id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _usersService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _usersService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _usersService.Remove(user._id);

            return NoContent();
        }
    }
}