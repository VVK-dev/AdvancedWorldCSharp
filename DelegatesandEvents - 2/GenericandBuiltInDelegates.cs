using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesandEvents
{
    public class GenericandBuiltInDelegates
    {
        //Generic delegates are rather simple, they are simply delegates that can take any type of input/output, i.e. they
        //are generics.

        public delegate T GenericDelegate1<T>(T data);

        //The above delegate accepts methods with any return type BUT the parameter type must be THE SAME as the return
        //type.

        //We can allieviate this issue by simply adding more variable in the <>, the same as with all generics.

        public delegate Q GenericDelegate2<T,Q>(T data);

        //BUILT-IN DELEGATES (finish GDMain1 below then come here)

        private Action TestAction;
        //This version of action takes no paramters and returns void

        private Action<int, double, string> TestAction2;

        public Func<string> TestFunc;
        //This Func takes no paramters and returns a string

        public Func<int,string> TestFunc2;
        //This Func takes 1 parameter of type int and returns a string 

        protected Predicate<int> TestPredicate;

        public void GDMain1()
        {

            GenericDelegate1<int> gd1var = i => i;
            //takes an int and returns the same int
            GenericDelegate2<int, string> gd2var = i => " ";
            //takes an int and returns a whitespace

            //BUILT-IN DELEGATES

            //C# has 3 built-in generic delegates:

            //Action - The Action delegate can only take methods with a return type of void and can take no/any number of
            //parameters (max 16) of any type. See above current method for creation example.

            TestAction = () => { Console.WriteLine("TestAction, 0 paramters, returns void"); };

            TestAction2 = (int i, double j, string k) => { Console.WriteLine(" ");};

            //Func - The Func delegate can take methods only with some return type that isn't void and upto 16 paramters
            //of any type. For Func the last type within the <> is actually the return type, so if we say func<string>
            //this func takes methods that have 0 paramters and return a string.

            TestFunc = () => " ";

            TestFunc2 = (int i) => { return " "; };

            //Predicate - Predicate can take methods with only 1 paramter of any type and that return only booleans.
            //We don't have to specify the return type in predicate as it will only accept methods that return bool.

            TestPredicate = i => true;

            Dosomething(() => { return 1; });

        }

        //Methods can also take Delegates as parameters

        public static void Dosomething(Func<int> a)
        {
            Console.WriteLine(a);
        }

    }
}
