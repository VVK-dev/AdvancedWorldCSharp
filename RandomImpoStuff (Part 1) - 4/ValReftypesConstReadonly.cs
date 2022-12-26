using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ValReftypesConstReadonly
{
    //A constant is a variable whose value can never be changed. Constants must have their value assigned during
    //declaration itself, they cannot be created then have a value assigned to them later.

    const int a = 1;

    //A readonly variable is a variable whose value can only be assigned either during declaration or in a constructor
    //method.
    //Readonly variables must be declared within the scope of the class; it cannot be declared in a method.
    
    readonly int b = 2;

    public ValReftypesConstReadonly()
    {
        b = 3; //We can assign a value to readonly variables in a constructor method, even if it already has a value
               //during declaration. 
    }
}

//Now let's get into something rather simple yet very important, Value and Reference types.

//NOTE: FOR MORE INFO ON VAL AND REF TYPES REFER TO MemoryAllocation.cs IN Optimization - 5

//All types are generally put into 2 categories: Value or reference.

//Value types are types that directly contain their data, whereas reference types are those that contain references
//(aka pointers) to their data.

//Examples of value types are int, float, bool,etc. Examples of reference types are strings, classes, arrays, objects,
//etc.

//Note: Although strings are reference types, they function like value types when we try to change their values and stuff.
//They are still stored in memory the same way as other reference types though (refer to MemoryAllocation.cs in
//Optimization - 5 for more info).

//Note: Value types cannot be inherited nor can inherit other value or reference types.
//They can only inherit interfaces.

//Lets see an example of the reference type, classes:

public class MyClass{

    public int val;

    public MyClass(int val)
    {
        this.val = val;
    }
}

public class ValRefTypes
{
    public static void Do()
    {

        MyClass c = new MyClass(5);
        MyClass d = c;
        d.val = 6;

        //We have created 2 myclass objects, where the 2nd is equal to the 1st. We have also changed the value of the
        //2nd's val field to a different number.

        Console.WriteLine(c.val);

        //But upon printing the val of c we see that it's value has also changed to 6! This is because both c and d
        //don't actually hold any content but instead references to the actual object which here is new MyClass(5).

        //So upon changing the value of d, and since d referred to c, the complier went to c. But since c referred
        //to the actual object, new MyClass(5), the object itself was changed to new MyClass(6) which in turn changed
        //both c and d.


        //Now let's talk about structs.
        //Structs are basically the MUCH faster value type brother of classes. They are they exact same in every way
        //except that structs are value type whereas classes are reference types AND that structs are much faster as
        //they are stored on the stack rather than the heap.

        //Let's see an example. (see much below for struct creation)

        stru first = new stru(5);
        stru second = first;

        second.value = 6;

        Console.WriteLine(first.value);

        //Here we see that the first's value did not change upon changing the second's. This is because structs are
        //value types, so when we say stru second = first; instead of creating an object that references the first,
        //a separate copy of the first is created and assinged to the second. So the first and second are actually
        //totally unrelated!

        //Now, what happens if we have to use a value type but need it to act like a reference type?

        int i = 1;

        //Let's say we have to increment the above int with a method.
        
        Increment1(i);

        Console.WriteLine(i);

        //Upon executing the above cw we see that instead of printing 2, it prints 1. The value of i did not
        //change but the value of the copy of i recieved by the method did.

        //We can fix this by using the ref keyword during method call and in the formal parameter of the method.

        //The ref keyword sends a pointer to the passed variable (aka reference) instead of a copy.

        int j = 1;

        Increment2(ref j);

        Console.WriteLine(j);

        //This prints 2 as what we passed into the method was a reference to j, so j gets 1 added to it instead
        //of a copy being created and that increasing by 1.


        //NOTE: Structs are a value type, which means that it cannot be inherited by other structs or 
        //classes. Structs can only inherit interfaces.
    }

    public static int Increment1(int n)
    {
        return n++;
    }

    public static int Increment2(ref int n)
    {
        return n++;
    }

}

public struct stru
{
    public int value;

    public stru(int value)
    {
        this.value = value;
    }
}
