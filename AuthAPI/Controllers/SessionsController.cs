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

        // [HttpDelete("{token:length(24)}")]
        // public IActionResult Delete(string token)
        // {
        //     var session = _sessionsService.Get(token);

        //     if (session == null)
        //     {
        //         return NotFound();
        //     }

        //     _sessionsService.Remove(session._id);

        //     return NoContent();
        // }
    }
}