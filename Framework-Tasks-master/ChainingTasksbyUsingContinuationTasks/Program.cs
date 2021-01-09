using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainingTasksbyUsingContinuationTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // starting task
            Task<string> task1 = Task.Run(() =>
            {
                // value
                return 12;
                // passing the value of task1 to another task to continue
            }).ContinueWith((antecedent) =>
            {
                // the finale value that task1 will hold
                return $"The Square of {antecedent.Result} is: {antecedent.Result * antecedent.Result}";
            });
            Console.WriteLine(task1.Result);

            Task<int> task = Task.Run(() =>
            {
                return 10;
            });
            task.ContinueWith((i) =>
            {
                Console.WriteLine("TasK Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = task.ContinueWith((i) =>
            {
                Console.WriteLine("Task Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();

            Console.ReadKey();
        }
    }
}
