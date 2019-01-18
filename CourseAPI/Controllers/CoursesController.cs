using System.Collections.Generic;
using CourseAPI.Models;
using CourseAPI.Services;
using AuthAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [Route("api/courses")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        private readonly SessionsService _sessionsService;

        public CourseController(CourseService courseService, SessionsService sessionsService)
        {
            _courseService = courseService;
            _sessionsService = sessionsService;
        }

        private bool isAuthorized(string Authorization)
        {
            return this._sessionsService.GetSession(Authorization) != null;
        }

        private bool isUserATeacher(string Authorization)
        {
            var user = this._sessionsService.GetUser(Authorization);

            return user != null
                ? user.Role == "teacher"
                : false;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get([FromHeaderAttribute] string Authorization)
        {
            if (isAuthorized(Authorization))
            {
                return _courseService.Get();
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("search/{title}")]
        [HttpGet]
        public ActionResult<List<Course>> searchByTitle([FromHeaderAttribute] string Authorization, string title)
        {
            if (isAuthorized(Authorization))
            {
                List<Course> course = _courseService.GetByTitle(title);

                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetCourse")]
        public ActionResult<Course> Get([FromHeaderAttribute] string Authorization, string id)
        {

            if (isAuthorized(Authorization))
            {
                var course = _courseService.Get(id);

                if (course == null)
                {
                    return NotFound();
                }

                return course;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public ActionResult<Course> Create([FromHeaderAttribute] string Authorization, Course course)
        {
            if (isAuthorized(Authorization) && isUserATeacher(Authorization))
            {
                _courseService.Create(course);
                return CreatedAtRoute("GetCourse", new { id = course._id.ToString() }, course);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromHeaderAttribute] string Authorization, string id, Course courseIn)
        {
            if (isAuthorized(Authorization))
            {
                var course = _courseService.Get(id);

                if (course == null)
                {
                    return NotFound();
                }

                _courseService.Update(id, courseIn);

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
                var course = _courseService.Get(id);

                if (course == null)
                {
                    return NotFound();
                }

                _courseService.Remove(course._id);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}