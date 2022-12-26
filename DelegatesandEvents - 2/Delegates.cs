using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesandEvents
{
    public class Delegates
    {
        //A(1)

        //A delegate is a variable that can store a method.

        //To create a delegate, we follow the same process as creating a method:

        //syntax: <accessmodifier> delegate <methodreturntype> <delegatename>(<formalparameters>);

        public delegate void TestDelegate();

        //By creating a delegate what we've done is essentially saved the "signature" of that particular type of method.
        //The signature of a method is it's return type + type and number of paramters it takes.

        //To actually use it as a variable that can store methods, we must create a variable of that delegate type.

        public TestDelegate testdelmethod;


        //B(1)

        //Lets create a delegate with a different signature

        public delegate bool TestDelegate2(int i);

        //Varibles of this delegate hold methods that return bool and take 1 integer parameter

        public TestDelegate2 boolintdel;


        public void Start1()
        {
            //A(2)

            testdelmethod = delmethod;

            //The method delmethod returns void and takes no parameters, so it can be assigned to the testdelmethod
            //variable as it's signature is the same as the delegate on which testdelmethod is based - TestDelegate.

            testdelmethod();

            //This functions exactly the same as simply calling delmethod.

            //If we dont remove any of the above code and change the value of testdelmethod to delmethod2 and call it
            //again it will execute delmethod2 after it executes delmethod1. It functions exactly as a normal variable
            //would.

            //Delegates can also be multi-cast, meaning that 1 delegate can hold multiple methods.

            testdelmethod += delmethod2;

            testdelmethod();

            //This will execute both delmethod1 and delmethod2

            testdelmethod -= delmethod2;

            testdelmethod();

            //This will execute only the first method - delmethod1

            //Note that this may lead to some issues. If we try to call a delegate with no methods assigned to it,
            //it will raise an error. So to ensure an error is not raised even if we call a null delegate, we must use
            //the following syntax:

            testdelmethod?.Invoke();

            //This is pretty much the exact same as just calling the delegate but the nullablity operator allows it to be
            //null and the invoke method will check whether's it's null or not and will only call the delegate if it
            //isn't null.

            //B(2)

            boolintdel = boolintmethod;

            boolintdel?.Invoke(3);
        }

        public void delmethod()
        {
            Console.WriteLine("delmethod");
        }

        public void delmethod2()
        {
            Console.WriteLine("delmethod2");  
        }

        public bool boolintmethod(int num)
        {
            return num > 5;
        }  
    }
}
