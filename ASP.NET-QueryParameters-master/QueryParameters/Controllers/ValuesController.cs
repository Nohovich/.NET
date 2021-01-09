using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataAccess;

namespace QueryParameters.Controllers
{
    /// <summary>
    /// Query parameters are a defined set of parameters attached to the end of a url.
    /// They are extensions of the URL that are used to help define specific content or actions based on the data being passed.
    /// To append query params to the end of a URL, a ‘?’ Is added followed immediately by a query parameter.
    /// To add multiple parameters, an ‘&’ is added in between each. These can be created by any variation of object types or lengths such as String, Arrays and Numbers
    /// example for 1 Parameter http://localhost/api/student?id=1
    /// example for a few Parameters http://localhost/api/student?id=1&name=steve
    /// </summary>
    public class ValuesController : ApiController
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
