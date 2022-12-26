using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDelegates
{
    class Delegates_AnonymousMethods
    {
        //Let's start off by describing what an anonymous method is:
        //An anonymous method is, as the name suggests, a method without a name that functions exactly like a normal
        //method but can be created in much less code.
        //We can anonymous methods to assign a value to a delegate variable without the full creation of a method.

        //Lets create a delegate and a variable for it:

        public delegate bool numcheck(int i);
        private numcheck numcheckmethod;

        public void Start()
        {
            numcheckmethod = greaterthan5;

            Console.WriteLine(numcheckmethod(1));

            //This is a delegate that is assigned to a method that will check if the number given (1, here) is > 5.

            //Let us use an anonymous method to check if the number is < 5.

            //syntax: delegate (<parameters>) {<methodbody>};

            //note that in the above assignment we've used the delegate keyword before the method starts. This is because
            //effectively what we're doing is creating a method, saving it's signature as a delegate and then assigning
            //it to a delegate variable with the same signature

            numcheckmethod = delegate (int j) { return j < 5; };

            //What we've done here is create an anonymous method that takes an int parameter and returns a boolean
            //It's the same as writing a separate method lessthan5 and assigning numcheckmethod to it.

            Console.WriteLine(numcheckmethod(2));

            //LAMBDA

            //The lambda operator ( => ) is one which allows us to create an anonymous method in an even simpler way.
            //Thinking the operator functions like saying "goes to" or "such that" in simple english may help with
            //understanding it.

            //syntax: (<parameters>) => {methodbody};

            //Anonymous methods created usiing the lambda operator are called lambda expressions.

            numcheckmethod = (int number) => { return number == 5; };

            //Here we have created a lambda expression that takes and int parameter and returns a boolean using the
            //lambda operator. 
            //Anonymous methods that take only 1 parameter and have only 1 line of code in their body and that use the
            //lambda operator can be written with no brackets, making the method look like a simple expression.

            numcheckmethod = n => n == 5;

            Console.WriteLine(numcheckmethod(5));

            //With anonymous methods in general tho there is 1 major issue. If we add an anonymous method to a delegate
            //variable we won't actually be able to remove it, as anonymous methods are just that - anonymous. There is
            //no way to specifiy a particular anonymous method to remove it.

            numcheckmethod += j => j < 5;

            //Now we cant remove the j<5 method alone. We will have to re-assign the variable which will remove the
            //first anonymous method we added as well.

        }

        public bool greaterthan5(int num)
        {
            return num > 5;
        }
    }
}
