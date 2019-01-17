using System.Collections.Generic;
using ResourseAPI.Models;
using ResourseAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using ResourseAPI.Utility;
using System;

namespace ResourseAPI.Controllers
{
    // localhost:5005/api/resourses
    [Route("api/resourses")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourseService _resourseService;
        private readonly SubscribeService _subscribeService;
        private readonly UserService _userService;

        public ResourceController(ResourseService resourseService, SubscribeService subscribeService, UserService userService)
        {
            _resourseService = resourseService;
            _subscribeService = subscribeService;
            _userService = userService;
        }

        [HttpGet(Name = "Get")]
        public ActionResult<List<Resourse>> Get(string id, string courseId)
        {
            if ((id != null && !id.Equals("")) || (courseId != null && !courseId.Equals("")))
            {
                List<Resourse> resourse = null;
                if (id != null && !id.Equals(""))
                {
                    resourse = new List<Resourse>();
                    Resourse resource = _resourseService.Get(id);
                    if (resource != null) resourse.Add(resource);
                }
                else
                {
                    resourse = _resourseService.GetByCourseId(courseId);
                }

                if (resourse == null)
                {
                    return NotFound();
                }

                return resourse;
            }
            else
            {
                return _resourseService.Get();
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetResourse")]
        public ActionResult<Resourse> GetById(string id)
        {
            var resourse = _resourseService.Get(id);

            if (resourse == null)
            {
                return NotFound();
            }

            return resourse;
        }

        // localhost:5005/api/resourses/create
        [HttpPost("create")]
        public ActionResult<Resourse> Create([FromBody] Resourse resourse)
        {
            User user;
            List<Subscribe> subscribes;
            string message;

           subscribes =  _subscribeService.GetByCourseId(resourse.CourseId);

            if (subscribes == null)
            {
                return NotFound();
            }
            foreach (var subscribe in subscribes)
            {
                user = _userService.Get(subscribe.ID_User);
     
                if (user == null)
                {
                    return NotFound();
                }

                message = "S-a incarcat o noua resursa cu titlul " + resourse.Title + "\n"
                          + "Cu descrierea: " + resourse.Description + "\n"
                          + "Resursa poate fi accesata la: " + resourse.Link;
        
                MailHelper.SendMail(user.Email, message);

            }
            _resourseService.Create(resourse);
            return CreatedAtRoute("Get", new { id = resourse._id.ToString() }, resourse);
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

        // [HttpPost("upload")]
        // public async Task<IActionResult> Post(List<Microsoft.AspNetCore.Http.IFormFile> files)
        // {
        //     System.Console.WriteLine("******************");
        //     long size = files.Sum(f => f.Length);

        //     // full path to file in temp location
        //     var filePath = Path.GetTempFileName();

        //     foreach (var formFile in files)
        //     {
        //         if (formFile.Length > 0)
        //         {
        //             using (var stream = new FileStream(filePath, FileMode.Create))
        //             {
        //                 System.Console.WriteLine("******************");
        //                 await formFile.CopyToAsync(stream);
        //             }
        //         }
        //     }

        //     // process uploaded files
        //     // Don't rely on or trust the FileName property without validation.

        //     return Ok(new { count = files.Count, size, filePath });
        // }

    }
}