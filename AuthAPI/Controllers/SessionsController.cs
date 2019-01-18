using System.Collections.Generic;
using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly SessionsService _sessionsService;

        public SessionsController(SessionsService sessionsService)
        {
            _sessionsService = sessionsService;
        }

        private bool isAuthorized(string Authorization)
        {
            return this._sessionsService.GetSession(Authorization) != null;
        }

        [HttpPost]
        public ActionResult<Token> Create(User user)
        {
            var session = _sessionsService.Create(user);

            if (session != null)
            {
                return session;
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromHeaderAttribute] string Authorization)
        {
            var session = _sessionsService.GetSession(Authorization);

            if (session == null)
            {
                return NotFound();
            }

            _sessionsService.Remove(session._id);

            return NoContent();
        }
    }
}