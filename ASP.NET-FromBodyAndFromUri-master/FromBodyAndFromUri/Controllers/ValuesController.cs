using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDB;

namespace FromBodyAndFromUri.Controllers
{
    public class ValuesController : ApiController
    {
        /// <summary>
        /// sending all data from body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        //public HttpResponseMessage Put(int id, Employee employee)
        //{
        //    try
        //    {
        //        using (EmployeeDBEntities entities = new EmployeeDBEntities())
        //        {
        //            var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
        //            if (entity == null)
        //            {
        //                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
        //                    "Employee with Id " + id.ToString() + " not found to update");
        //            }
        //            else
        //            {
        //                entity.FirstName = employee.FirstName;
        //                entity.LastName = employee.LastName;
        //                entity.Gender = employee.Gender;
        //                entity.Salary = employee.Salary;

        //                entities.SaveChanges();

        //                return Request.CreateResponse(HttpStatusCode.OK, entity);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        /// <summary>
        /// sending the sensitive data from body and the rest of the data using uri(query parameters)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public IHttpActionResult Put([FromBody]int id, [FromUri]Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return BadRequest("Employee with Id " + id.ToString() + " not found to update");                      
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        entities.SaveChanges();

                        return Ok(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
