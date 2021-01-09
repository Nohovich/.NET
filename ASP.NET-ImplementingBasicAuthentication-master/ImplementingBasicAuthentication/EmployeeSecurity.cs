using EmployeeDB;
using System;
using System.Linq;


namespace ImplementingBasicAuthentication
{
    public class EmployeeSecurity
    {
        /// <summary>
        /// checking if the username and the password exist in the data base
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string username, string password)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Users.Any(user =>
                       user.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.Password == password);
            }
        }
    }
}