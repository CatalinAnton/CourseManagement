using System.Collections.Generic;
using ResourseAPI.Models;
using ResourseAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResourseAPI.Controllers
{
    [Route("api/resourses")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourseService _resourseService;

        public ResourceController(ResourseService resourseService)
        {
            _resourseService = resourseService;
        }

        [HttpGet]
        public ActionResult<List<Resourse>> Get()
        {
            return _resourseService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetResourse")]
        public ActionResult<Resourse> Get(string id)
        {
            var resourse = _resourseService.Get(id);

            if (resourse == null)
            {
                return NotFound();
            }

            return resourse;
        }

        [HttpPost]
        public ActionResult<Resourse> Create([FromBody] Resourse resourse)
        {
           _resourseService.Create(resourse);     

            return CreatedAtRoute("GetResourse", new { id = resourse._id.ToString() }, resourse);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Resourse resourseIn)
        {
            var resourse = _resourseService.Get(id);

            if (resourse == null)
            {
                return NotFound();
            }

            _resourseService.Update(id, resourseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var resourse = _resourseService.Get(id);

            if (resourse == null)
            {
                return NotFound();
            }

            _resourseService.Remove(resourse._id);

            return NoContent();
        }
    }
}