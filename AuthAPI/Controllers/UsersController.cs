using System.Collections.Generic;
using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace AuthAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly SessionsService _sessionsService;

        public UsersController(UsersService usersService, SessionsService sessionsService)
        {
            _usersService = usersService;
            _sessionsService = sessionsService;
        }

        private bool isAuthorized(string Authorization)
        {
            return this._sessionsService.GetSession(Authorization) != null;
        }

        private bool isUserIdentical(string Authorization, string id)
        {
            var user = this._sessionsService.GetUser(Authorization);
            var docId = new ObjectId(id);

            return user != null
                ? user._id == docId
                : false;
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
        public IActionResult Update([FromHeaderAttribute] string Authorization, string id, User userIn)
        {
            if (isAuthorized(Authorization) && isUserIdentical(Authorization, id))
            {
                var user = _usersService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                _usersService.Update(id, userIn);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromHeaderAttribute] string Authorization, string id)
        {
            if (isAuthorized(Authorization) && isUserIdentical(Authorization, id))
            {
                var user = _usersService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                _usersService.Remove(user._id);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}