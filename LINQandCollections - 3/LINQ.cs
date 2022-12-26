class LINQ
{
    //LINQ stands for Language Integrated Query. The simplest way to define LINQ is that it's the ability to write
    //SQL code in C# to simplify how we interact with collections and enumerables.

    public static void Start()
    {
        //>>>A
        
        //B

        QueryStringArray();

        //Now let's try to incorporate what we've learnt so far into LINQ. If you recall earlier when we were first
        //introduced to lambda expressions, I said that thinking of the lambda operator (=>) as "goes to" or "such that"
        //will help in understanding it. Here in LINQ, specifically reading it as "such that" will help.

        List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };

        //Lets say we wanted to create a new list with all elements from the above list has elements that are >3.

        List<int> list2 = new();

        //In the conventional way we can use a simple foreach loop:

        /*

        foreach(int i in list)
        {
            if (i > 3) { list2.Add(i); }    
        }
        */

        //We can also use LINQ:

        /*
        
        list2 = from num in nums
                where num > 3
                select num;
        
         
         */ 

        //OR We can instead use LINQ and an anonymous method to significantly shorten this code even further

        List<int> list3 = nums.Where(n => n > 3).ToList();

        //Here we observe that the LINQ commands are also methods part of IEnumerable and so needn't be used separately

        //As you can see from the above code, the Where method doesn't actually return a list. It returns an IEnumerable
        //which we can save to a variable of type var as var basically means "any type"

        var list4 = nums.Where(n => n > 3);

        //For more info on IEnumerable >>>C

        //Lets try to find something out about the list nums, like if all of it's elements are >2 AND <4.
        //We can use the LINQ method ALL which checks for a certain condition using a lambda operator and returns
        //a boolean

        bool over2 = nums.All(n => n > 2 && n < 4);

        //Here we see that we can string multiple conditions together in a lambda expression like in an if statement.
        //Simililarly, we can also use || as 'or'.

        //We can also string multiple LINQ commands together.
        //Let's try to get the first 3 elements of a sublist of nums with all elements over 2 in descending order.     

        var over2multiplecommands = nums
            .Where(n => n > 2)
            .OrderByDescending(n => n)
            .Take(3);

        //Take(x) returns the first x elements in a list.
        
        //Another useful LINQ method is FirstOrDefault(<lambda expression>) which will return the first occurance
        //of an element satisfying the given condition or null if none satisfy.

        //If you hover over .All in nums.All you will notice that it's actually making use of the built-in generic
        //delegates func and predicate, which is why we are using lambda expressions to give our conditions.

        //If we type <anyEnumerable>. we can see all the different LINQ methods that make use of delegates including
        //methods like .Any, .Aggregate, .ForEach, .BinarySearch .etc .

        nums.BinarySearch(1);
    }

    //A
    static void QueryStringArray()
    {
        string[] dogs = {"K 9", "Brian Griffin",
            "Scooby Doo", "Old Yeller", "Rin Tin Tin",
            "Benji", "Charlie B. Barkin", "Lassie",
            "Snoopy"
        };

        // Let's try to get the strings with spaces in them and put them in reverse alphabetical order

        var dogSpaces = from dog in dogs
                        where dog.Contains(' ')
                        orderby dog descending
                        select dog;

        // from states where data comes from and where to store each piece as you cycle (here the current element of the
        // dogs list is stored as the variable 'dog')

        // where defines conditions that must be met

        // orderby defines what data is used for ordering results (ascending / descending)

        // select defines the variable that is checked against the condition


        //As you can see from the above code, LINQ is literally just SQL statements written in C#.
        //LINQ includes pretty much ALL SQL code including joins, groupby, having etc.


        foreach (var i in dogSpaces)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine();

    }
}