using EmployeeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace BasicAuthenticationUsingJqueryAjax.Controllers
{
    /// <summary>
    /// https://csharp-video-tutorials.blogspot.com/2016/10/call-web-api-service-with-basic.html
    /// </summary>
    public class EmployeeController : ApiController
    {
        [BasicAuthentication]
        public IHttpActionResult Get(string gender = "All")
        {
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
