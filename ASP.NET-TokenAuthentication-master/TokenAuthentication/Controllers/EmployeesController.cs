using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TokenAuthentication.Controllers
{
    /// <summary>
    /// https://csharp-video-tutorials.blogspot.com/2016/11/aspnet-web-api-token-authentication.html
    /// https://csharp-video-tutorials.blogspot.com/2016/12/using-aspnet-identity-with-web-api.html
    /// https://csharp-video-tutorials.blogspot.com/2016/12/aspnet-web-api-google-authentication.html
    /// https://csharp-video-tutorials.blogspot.com/2017/02/aspnet-web-api-facebook-authentication.html
    /// </summary>
    [Authorize]
    public class EmployeesController : ApiController
    {
        public IHttpActionResult Get(string gender = "All")
        {

            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Ok(entities.Employees.ToList());
        
                    case "male":
                        return Ok(entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());

                    case "female":
                        return Ok(entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());

                    default:
                        return BadRequest("Value for gender must be Male, Female or All. " + gender + " is invalid.");
 
                }
            }
        }
    }
}
