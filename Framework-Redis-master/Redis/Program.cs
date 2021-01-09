using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            // setting server
            string host = "localhost";

            // setting the key for the value we want to insert into our server
            string key = "IDG";

            // Store data in the cache

            bool success = Save(host, key, "Hello World!");

            // Retrieve data from the cache using the key

            Console.WriteLine("Data retrieved from Redis Cache: " + Get(host, key));

            Console.ReadKey();
        }
        /// <summary>
        /// saving the info we want in our Redis server by key value
        /// </summary>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool Save(string host, string key, string value)

        {

            bool isSuccess = false;

            // setting connection to our server
            using (RedisClient redisClient = new RedisClient(host))
            {
                // if this key doesn't point to a value set this key with the value
                if (redisClient.Get<string>(key) == null)
                {
                    // set the key and the value
                    isSuccess = redisClient.Set(key, value);
                    
                    // removes the key
                    //redisClient.Remove(key);
                }

            }

            return isSuccess;

        }

        /// <summary>
        /// gets the value from the Redis server using the key
        /// </summary>
        /// <param name="host"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string Get(string host, string key)
        {
            // setting connection to our server
            using (RedisClient redisClient = new RedisClient(host))
            {
                // getting the info using the this key
                return redisClient.Get<string>(key);

            }

        }
    }
}
