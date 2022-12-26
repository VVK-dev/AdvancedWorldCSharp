namespace Optimization
{
    public static class AsynchronousProgramming
    {

        //NOTE: This entire chapter (Optimization) is super advanced stuff. So advanced, that it may not
        //even be that useful knowing any of it right now. I will (probably) be applying atleast some
        //of the stuff in this chapter to SpellMight, but idk how much or how useful it will actually be. I
        //assume that this chapter is going to be very important to me in the future, but not much right
        //now.

        //NOTE: Asynchronous programming is generally most useful only when dealing with input and output
        //situations like a GUI or writing/reading something to/from a disk. Other times it's best not
        //to use async as it may actually hinder performance if not used in these situations.

        /*ENITRELY TAKEN FROM THE MICROSOFT DOCUMENTATION:
         
        The goal of this syntax: enable code that reads like a sequence of statements, but executes in 
        a much more complicated order based on external resource allocation and when tasks complete. 
        It's analogous to how people give instructions for processes that include asynchronous tasks. 
        
        To explain this let's use an example of instructions for making a breakfast to see how the async 
        and await keywords make it easier to reason about code that includes a series of asynchronous 
        instructions. You'd write the instructions something like the following list to explain how to 
        make a breakfast:
        
        1) Pour a cup of coffee.
        2) Heat up a pan, then fry two eggs.
        3) Fry three slices of bacon.
        4) Toast two pieces of bread.
        5) Add butter and jam to the toast.
        6) Pour a glass of orange juice.
          
        If you have experience with cooking, you'd execute those instructions asynchronously. You'd start
        warming the pan for eggs, then start the bacon. You'd put the bread in the toaster, then start the
        eggs. At each step of the process, you'd start a task, then turn your attention to tasks that are 
        ready for your attention.

        Cooking breakfast is a good example of asynchronous work that isn't parallel. One person (or thread)
        can handle all these tasks. Continuing the breakfast analogy, one person can make breakfast 
        asynchronously by starting the next task before the first completes. The cooking progresses whether
        or not someone is watching it. As soon as you start warming the pan for the eggs, you can begin 
        frying the bacon. Once the bacon starts, you can put the bread into the toaster.

        For a parallel algorithm, you'd need multiple cooks (or threads). One would make the eggs, one the 
        bacon, and so on. Each one would be focused on just that one task. Each cook (or thread) would be 
        blocked synchronously waiting for bacon to be ready to flip, or the toast to pop.
        
        Now, consider those same instructions written as C# statements:


        namespace AsyncBreakfast
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Coffee cup = PourCoffee();
                    Console.WriteLine("coffee is ready");

                    Egg eggs = FryEggs(2);
                    Console.WriteLine("eggs are ready");

                    Bacon bacon = FryBacon(3);
                    Console.WriteLine("bacon is ready");

                    Toast toast = ToastBread(2);
                    ApplyButter(toast);
                    ApplyJam(toast);
                    Console.WriteLine("toast is ready");

                    Juice oj = PourOJ();
                    Console.WriteLine("oj is ready");
                    Console.WriteLine("Breakfast is ready!");
                }

                private static Juice PourOJ()
                {
                    Console.WriteLine("Pouring orange juice");
                    return new Juice();
                }

                private static void ApplyJam(Toast toast) => 
                    Console.WriteLine("Putting jam on the toast");

                private static void ApplyButter(Toast toast) => 
                    Console.WriteLine("Putting butter on the toast");

                private static Toast ToastBread(int slices)
                {
                    for (int slice = 0; slice < slices; slice++)
                    {
                        Console.WriteLine("Putting a slice of bread in the toaster");
                    }
                    Console.WriteLine("Start toasting...");
                    Task.Delay(3000).Wait();
                    Console.WriteLine("Remove toast from toaster");

                    return new Toast();
                }

                private static Bacon FryBacon(int slices)
                {
                    Console.WriteLine($"putting {slices} slices of bacon in the pan");
                    Console.WriteLine("cooking first side of bacon...");
                    Task.Delay(3000).Wait();
                    for (int slice = 0; slice < slices; slice++)
                    {
                        Console.WriteLine("flipping a slice of bacon");
                    }
                    Console.WriteLine("cooking the second side of bacon...");
                    Task.Delay(3000).Wait();
                    Console.WriteLine("Put bacon on plate");

                    return new Bacon();
                }

                private static Egg FryEggs(int howMany)
                {
                    Console.WriteLine("Warming the egg pan...");
                    Task.Delay(3000).Wait();
                    Console.WriteLine($"cracking {howMany} eggs");
                    Console.WriteLine("cooking the eggs ...");
                    Task.Delay(3000).Wait();
                    Console.WriteLine("Put eggs on plate");

                    return new Egg();
                }

                private static Coffee PourCoffee()
                {
                    Console.WriteLine("Pouring coffee");
                    return new Coffee();
                }
            }
        }


        NOTE: The Coffee, Egg, Bacon, Toast, and Juice classes are empty. They are simply marker classes 
        for the purpose of demonstration, contain no properties, and serve no other purpose.

        The code above demonstrates a bad practice: constructing synchronous code to perform asynchronous 
        operations. As written, this code blocks the thread executing it from doing any other work. 
        It won't be interrupted while any of the tasks are in progress. It would be as though you stared at
        the toaster after putting the bread in. You'd ignore anyone talking to you until the toast popped.

        Computers don't interpret these instructions the same way people do. The computer will block on 
        each statement until the work is complete before moving on to the next statement. That creates an 
        unsatisfying breakfast. The later tasks wouldn't be started until the earlier tasks had completed.
        It would take much longer to create the breakfast, and some items would have gotten cold before 
        being served.

        If you want the computer to execute the above instructions asynchronously, you must write 
        asynchronous code.

        These concerns are important for the programs you write today. When you write client programs, 
        you want the UI to be responsive to user input. Your application shouldn't make a phone appear 
        frozen while it's downloading data from the web. When you write server programs, you don't want 
        threads blocked. Those threads could be serving other requests. Using synchronous code when 
        asynchronous alternatives exist hurts your ability to scale out less expensively.

        //AWAIT

        Let's start by updating the previous code so that the thread doesn't block while tasks are running.
        The await keyword provides a non-blocking way to start a task: it lets another thread handle that 
        workload as the initial thread continues the execution of the rest of the program then comes back to
        that task when the it's complete.

                static async void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        This code doesn't block while the eggs or the bacon are cooking. This code won't start any other 
        tasks though. You'd still put the toast in the toaster and stare at it until it pops. But at least,
        you'd respond to anyone that wanted your attention. In a restaurant where multiple orders are 
        placed, the cook could start another breakfast while the first is cooking.
         */

        //Async is really just a modifier that we add to methods and stuff. Await is the actual keyword that
        //we use to tell c# to go do other stuff while something else is happening, i.e. asynchronous
        //programming.

    }
}