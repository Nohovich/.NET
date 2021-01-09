using AttributeRouting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AttributeRouting.Controllers
{
    // class level [RoutePrefix](base Route)
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
        new Student() { Id = 1, Name = "Tom" },
        new Student() { Id = 2, Name = "Sam" },
        new Student() { Id = 3, Name = "John" }
        };

        /// <summary>
        /// because we are using [RoutePrefix](base Route) on a class level we just need to write the continuous that we want for this method
        /// </summary>
        /// <returns></returns>
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        // Specifies values
        //[Route("{id:int:min(1):max(3)}")]

        // passing a integer and the name of the method to call in the code is "GetStudentById"
        [Route("{id:int}", Name = "GetStudentById")]
        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }

        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new
                        Uri(Url.Link("GetStudentById", new { id = student.Id }));
            return response;
        }
        // name is the parameter and alpha(string) is the type
        [Route("{name:alpha}")]
        public IHttpActionResult get(string name)
        {
             var student = students.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
            return Ok(student);
        }
        // base Route passing the ID then /courses
        [Route("{id}/courses")]
        public IHttpActionResult GetStudentCourses(int id)
        {
            if (id == 1)
                return Ok( new List<string>() { "C#", "ASP.NET", "SQL Server" });
            else if (id == 2)
                return Ok( new List<string>() { "ASP.NET Web API", "C#", "SQL Server" });
            else
                return Ok(new List<string>() { "Bootstrap", "jQuery", "AngularJs" });
        }

        // use ~/ to override the base Route
        [Route("~/api/teachers")]
        public IHttpActionResult GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
              new Teacher() { Id = 1, Name = "Rob" },
              new Teacher() { Id = 2, Name = "Mike" },
              new Teacher() { Id = 3, Name = "Mary" }
            };

            return Ok(teachers);
        }


    }
}
