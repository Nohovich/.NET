using IHttpActionResultAndResponseType.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace IHttpActionResultAndResponseType.Controllers
{
    /// <summary>
    ///  How to add Swagger in Web API Application:
    ///  https://dotnettutorials.net/lesson/how-to-use-swagger-in-web-api/
    ///  
    /// 
    /// The IHttpActionResult interface was introduced in Web API 2.
    /// Essentially, it defines an HttpResponseMessage factory.
    /// Some advantages of using the IHttpActionResult interface:
    /// (1) Simplifies unit testing your controllers
    /// (2) Moves common logic for creating HTTP responses into separate classes
    /// (3) Makes the intent of the controller action clearer, by hiding the low-level details of constructing the response.
    /// </summary>
    public class FoodController : ApiController
    {
        // just for demo
        private static List<Food> foods = new List<Food>();
        private static int counter = 0;
        static FoodController()
        {
            foods.Add(new Food() { Id = 1, Name = "Chips" });
            foods.Add(new Food() { Id = 2, Name = "Burger" });
            foods.Add(new Food() { Id = 3, Name = "Pizza" });
            counter = foods.Count;
        }

        /// <summary>
        /// Get all food items - GET main route
        /// </summary>
        /// <returns>IHttpActionResult</returns>

        /// ResponseType attribute is helpful for autogenerating documentation in tools like Swagger / Swashbuckle
        [ResponseType(typeof(Food))]

        // after using the  [HttpGet] attribute we can name this method the way we want 
        [HttpGet]
        public IHttpActionResult Get()
        {
            if (foods.Count == 0)
            {
                return NotFound();
            }
            return Ok(foods);
        }

        /// <summary>
        /// Get aspecific food item
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Food))]

        // this attribute is divided by 2 parts
        // part 1: the Route(part of the URL)
        // part 2: a name to call this Route in the code
        [Route("api/food/{id}", Name = "GeById")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Food food = foods.FirstOrDefault(f => f.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutFood(int id, [FromBody] Food food)
        {
            if (food.Id == 0)
            {
                return BadRequest(ModelState);
            }

            if (foods.FirstOrDefault(f => f.Id == id) == null)
            {
                return NotFound();
            }
            else
            {
                // update
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /// <summary>
        /// CreatedAtRoute method is intended to return a URI to the newly created resource when you invoke a POST method to store some new object.
        /// So if you POST an order item for instance, you might return a route like ‘api/order/11’ (11 being the id of the new order)
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        // POST: api/Foods
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood([FromBody] Food food)
        {
            // posting work...

            food.Id = ++counter;
            foods.Add(food);

            // after POST return the URL of the 
            //  use - return CreatedAtRoute( ... );
            // we are passing our api "GeById" method and then passing the data this method needs id and content
            return CreatedAtRoute("GeById", new { id = food.Id }, food);
        }
    }
}