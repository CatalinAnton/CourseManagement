using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SubscribeAPI.Models;
using SubscribeAPI.Services;
using SubscribeAPI.Utility;

namespace SubscribeAPI.Controllers
{
    [Route("api/subscribes")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly SubscribeService _subscribeService;
        private readonly UserService _userService;
        private readonly CourseService _courseService;

        public SubscribeController(SubscribeService subscribeService, UserService userService, CourseService courseService)
        {
            _subscribeService = subscribeService;
            _userService = userService;
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Subscribe>> Get()
        {
            return _subscribeService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetSubscribe")]
        public ActionResult<Subscribe> Get(string id)
        {
            var subscribe = _subscribeService.Get(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            return subscribe;
        }

        [HttpPost]
        public ActionResult<Subscribe> Create(Subscribe subscribe)
        {

            User user = _userService.Get(subscribe.ID_User);
            Course course = _courseService.Get(subscribe.ID_Course);
            string message = "Te-ai abonat la cursul: " + course.Title;
            MailHelper.SendMail(user.Email, message);

            _subscribeService.Create(subscribe);
            return CreatedAtRoute("GetSubscribe", new { id = subscribe._id.ToString() }, subscribe);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Subscribe subscribeIn)
        {
            var subscribe = _subscribeService.Get(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            _subscribeService.Update(id, subscribeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var subscribe = _subscribeService.Get(id);

            if (subscribe == null)
            {
                return NotFound();
            }

            _subscribeService.Remove(subscribe._id);

            return NoContent();
        }
    }
}