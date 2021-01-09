using JWTAuthentication.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTAuthentication.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(string username, string password)
        {
            User user = new User();
            user.Username = username;
            bool testUserName;
            bool testPasswordMachUserName = false;
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                testUserName = entities.Users.Any(usere =>
                       usere.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (testUserName)
                {
                    testPasswordMachUserName = entities.Users.Any(usere =>
                      usere.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                         && usere.Password == password);
                }
            }
            if (testPasswordMachUserName)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                 TokenManager.GenerateToken(user.Username));
            }
           
            
            if (testUserName && !testPasswordMachUserName) return Request.CreateResponse(HttpStatusCode.Forbidden,
                "The username/password combination was wrong.");

            else
                return Request.CreateResponse(HttpStatusCode.NotFound,
                     "The user was not found.");

        }
       
    }
}
