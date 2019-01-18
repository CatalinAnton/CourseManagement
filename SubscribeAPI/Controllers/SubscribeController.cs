using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SubscribeAPI.Models;
using SubscribeAPI.Services;
using AuthAPI.Models;
using AuthAPI.Services;
using SubscribeAPI.Utility;

namespace SubscribeAPI.Controllers
{
    [Route("api/subscribes")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly SubscribeService _subscribeService;
        private readonly UsersService _usersService;
        private readonly CourseService _courseService;
        private readonly SessionsService _sessionsService;

        public SubscribeController(SubscribeService subscribeService, UsersService usersService, CourseService courseService, SessionsService sessionsService)
        {
            _subscribeService = subscribeService;
            _usersService = usersService;
            _courseService = courseService;
            _sessionsService = sessionsService;
        }

        private bool isAuthorized(string Authorization)
        {
            return this._sessionsService.GetSession(Authorization) != null;
        }

        [HttpGet]
        public ActionResult<List<Subscribe>> Get([FromHeaderAttribute] string Authorization)
        {
            return _subscribeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetSubscribe")]
        public ActionResult<Subscribe> Get([FromHeaderAttribute] string Authorization, string id)
        {
            if (isAuthorized(Authorization))
            {
                var subscribe = _subscribeService.Get(id);

                if (subscribe == null)
                {
                    return NotFound();
                }

                return subscribe;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public ActionResult<Subscribe> Create([FromHeaderAttribute] string Authorization, Subscribe subscribe)
        {
            if (isAuthorized(Authorization))
            {
                User user = _usersService.Get(subscribe.ID_User);
                Course course = _courseService.Get(subscribe.ID_Course);
                string message = "Te-ai abonat la cursul: " + course.Title;
                MailHelper.SendMail(user.Email, message);

                _subscribeService.Create(subscribe);
                return CreatedAtRoute("GetSubscribe", new { id = subscribe._id.ToString() }, subscribe);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromHeaderAttribute] string Authorization, string id, Subscribe subscribeIn)
        {
            if (isAuthorized(Authorization))
            {
                var subscribe = _subscribeService.Get(id);

                if (subscribe == null)
                {
                    return NotFound();
                }

                _subscribeService.Update(id, subscribeIn);

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
            if (isAuthorized(Authorization))
            {
                var subscribe = _subscribeService.Get(id);

                if (subscribe == null)
                {
                    return NotFound();
                }

                _subscribeService.Remove(subscribe._id);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}