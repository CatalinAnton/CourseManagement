using System.Collections.Generic;
using ResourseAPI.Models;
using ResourseAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

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

        [HttpPost("upload")]
        public async Task<IActionResult> Post(List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}