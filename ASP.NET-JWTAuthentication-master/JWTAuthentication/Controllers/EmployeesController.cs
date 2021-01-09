using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthentication.Controllers
{
    public class EmployeesController : ApiController
    {
        public IHttpActionResult Get(string gender = "male")
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (gender.ToLower())
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
