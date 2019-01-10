using System.Collections.Generic;
using CourseAPI.Models;
using CourseAPI.Services;
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

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
            return _courseService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetCourse")]
        public ActionResult<Course> Get(string id)
        {
            var course = _courseService.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            _courseService.Create(course);

            return CreatedAtRoute("GetCourse", new { id = course._id.ToString() }, course);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Course courseIn)
        {
            var course = _courseService.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            _courseService.Update(id, courseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var course = _courseService.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            _courseService.Remove(course._id);

            return NoContent();
        }
    }
}