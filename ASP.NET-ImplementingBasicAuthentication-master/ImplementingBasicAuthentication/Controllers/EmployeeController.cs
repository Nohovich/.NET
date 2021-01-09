using EmployeeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace ImplementingBasicAuthentication.Controllers
{
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// https://csharp-video-tutorials.blogspot.com/2016/10/implementing-basic-authentication-in.html
        /// Basic authentication is a method for an HTTP user agent (e.g. a web browser, postman) to provide a user name and password when making a request.
        /// In basic HTTP authentication, a request contains a header field in the form of Authorization: Basic <credentials>,
        /// where credentials is the base64 encoding of id and password joined by a single colon :
        /// here we are using the  [BasicAuthentication] attribute on the method level
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [BasicAuthentication]
        public IHttpActionResult Get(string gender = "All")
        {
            // the info of the userName that passed the BasicAuthentication
            string username = Thread.CurrentPrincipal.Identity.Name;

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (username.ToLower())
                {
                    case "male":
                        return Ok(entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Ok(entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return BadRequest();
                }
            }
        }
    }
}
