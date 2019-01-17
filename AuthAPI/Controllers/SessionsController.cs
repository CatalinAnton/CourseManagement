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
        private readonly SessionService _sessionService;

        public SessionsController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public ActionResult<Session> Create(User user)
        {
            var session = _sessionService.Create(user);

            if (session != null)
            {
                return CreatedAtRoute("GetSession", new { id = session._id.ToString() }, session);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{token:length(24)}")]
        public IActionResult Delete(string token)
        {
            var session = _sessionService.Get(token);

            if (session == null)
            {
                return NotFound();
            }

            _sessionService.Remove(session._id);

            return NoContent();
        }
    }
}