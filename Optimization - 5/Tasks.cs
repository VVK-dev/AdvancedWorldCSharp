using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class Tasks
    {
        /* PARTIALLY TAKEN FROM THE MICROSOFT DOCUMENTATION:

        //TASKS

        In many scenarios, you want to start several independent jobs immediately. Then, as each job
        finishes, you can continue other work that's ready. In the breakfast analogy, that's how you get
        breakfast done more quickly. You also get everything done close to the same time. You'll get a hot 
        breakfast.

        That's where tasks come in. The Task class represents any operation that can executes 
        asynchronously and is therefore awaitable.

        The reason we use tasks is because specifying an operation as a task gives us much more control over
        the execution of that operation. By specifying something as a task, we are able to use the task's
        class's methods to tell c# when to execute that part of the code and whether or not to do it
        synchronously and several other options.

        We basically just use tasks to turn a normal synchronous operation asynchronous and awaitable.
        The reason we speficially use tasks for this is because not every opertaion is awaitable.
        Only operations that return tasks are awaitable.        
        */

        static async Task<int> AddAsync1()
        {
            int num = 5;
            int num1 = num + 1;
            Task.Delay(10000).Wait();
            int num2 = num1 + 1;
            int num3 = num2 + 1;

            return num3;
        }
        async static Task<int> AddAsync2()
        {
            int num2 = await AddAsync1();
            int num3 = num2 + 1;
            return num3;
        }

        public static async Task Main(String[] args)
        {
            Console.WriteLine(await AddAsync2());

            //There is a specific method that converts any operation that returns something that is not a task
            //into an operation that does thus making is awaitable.

            //Task.Run(<method name>);

            //This statement makes the operation return a task that represents the operation
            //so we can use await with it.

            await Task.Run(() => Console.WriteLine(AddAsync2())); //This method already returns an awaitable type
                                                                  //(task) so this line of code is actually useless
                                                                  //but im just using it as an example.

            Spans.spansexplanation();

        }
    }
}
