using System.Collections.Generic;
using ResourseAPI.Models;
using ResourseAPI.Services;
using AuthAPI.Models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
using ResourseAPI.Utility;

namespace ResourseAPI.Controllers
{
    // localhost:5005/api/resourses
    [Route("api/resourses")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourseService _resourseService;
        private readonly SubscribeService _subscribeService;
        private readonly UsersService _usersService;
        private readonly SessionsService _sessionsService;

        public ResourceController(ResourseService resourseService, SubscribeService subscribeService, UsersService usersService, SessionsService sessionsService)
        {
            _resourseService = resourseService;
            _subscribeService = subscribeService;
            _usersService = usersService;
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

        [HttpGet(Name = "Get")]
        public ActionResult<List<Resourse>> Get([FromHeaderAttribute] string Authorization, string id, string courseId)
        {
            if (isAuthorized(Authorization))
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
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("{id:length(24)}", Name = "GetResourse")]
        public ActionResult<Resourse> GetById([FromHeaderAttribute] string Authorization, string id)
        {
            if (isAuthorized(Authorization))
            {
                var resourse = _resourseService.Get(id);

                if (resourse == null)
                {
                    return NotFound();
                }

                return resourse;
            }
            else
            {
                return Unauthorized();
            }
        }

        // localhost:5005/api/resourses/create
        [HttpPost("create")]
        public ActionResult<Resourse> Create([FromHeaderAttribute] string Authorization, [FromBody] Resourse resourse)
        {
            if (isAuthorized(Authorization) && isUserATeacher(Authorization))
            {
                User user;
                List<Subscribe> subscribes;
                string message;

                subscribes = _subscribeService.GetByCourseId(resourse.CourseId);

                if (subscribes == null)
                {
                    return NotFound();
                }

                foreach (var subscribe in subscribes)
                {
                    user = _usersService.Get(subscribe.ID_User);

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

                return CreatedAtRoute("GetResourse", new { id = resourse._id.ToString() }, resourse);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromHeaderAttribute] string Authorization, string id, Resourse resourseIn)
        {
            if (isAuthorized(Authorization))
            {
            }
            else
            {
                return Unauthorized();
            }
            var resourse = _resourseService.Get(id);

            if (resourse == null)
            {
                return NotFound();
            }

            _resourseService.Update(id, resourseIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete([FromHeaderAttribute] string Authorization, string id)
        {
            if (isAuthorized(Authorization))
            {
                var resourse = _resourseService.Get(id);

                if (resourse == null)
                {
                    return NotFound();
                }

                _resourseService.Remove(resourse._id);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        // [HttpPost("upload")]
        // public async Task<IActionResult> Post(List<Microsoft.AspNetCore.Http.IFormFile> files)
        // {
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