using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MemoryAllocation
{
    //STACKS AND HEAPS

    //The stack is basically an array of memory which use the LIFO (Last In First Out) system. Think of the Stack as a
    //series of boxes stacked one on top of the next.  We keep track of what's going on in our application by stacking
    //another box on top every time we call a method (called a frame). We can only use what's in the top box on the stack.
    //When we're done with the top box (the method is done executing) we throw it away and proceed to use the stuff in the
    //previous box on the top of the stack. The Heap is similar except that its purpose is to hold information
    //(not keep track of execution most of the time) so anything in our Heap can be accessed at any time.

    //The Heap contains all objects we create, while the stack only contains the references to these objects. Simply put,
    //the heap contains all reference types and the stack contains the references to those reference types (aka pointers,
    //pointers are generally the memory address of the reference type on the heap that they point to) as well as all value
    //types. But this has some exceptions: if a value type is created as part of a reference type (eg: property of a class),
    //it will be allocated on the heap along with the object it is a property of. This however doesn't apply to methods
    //part of a class. Formal and actual value type parameters are allocated on the stack.

    //But why does this all matter? This is because of the way many languages (including c#) handle memory management.
    //You see, after a method finishes executing, all of its local variables will not be used any longer and so they must
    //be deleted. To do this, c# (and other langs) use what's called a garbage collector (GC). The garbage collector is 
    //what runs after a code block stops executing and gets rid of each of its now-unusable local variables. The big thing
    //with this is that OUR PROGRAM IS PAUSED WHILE THE GC IS RUNNING. WHEN THE GC RUNS, OUR PROGRAM DOES NOT!

    //The GC only runs on the heap. It does not clean the stack. This is because the stack is automatically emptied
    //everytime it leaves a frame. The heap is not, and so requires the GC.

    //Overall:
    /*
    Stack allocation: Temporary, cheap storage for local variables. Stack allocations are almost completely free - about as
    expensive as a single assignment. However, in C#, you can only store primitive types, structs, and the reference itself
    on the stack. 

    Heap allocation: Expensive, garbage-collected storage for any kind of variable. Heap allocations are very expensive 
    (can be 20 times as expensive as a single assignment), and accessing things that are allocated on the heap is slower 
    than accessing things from the stack (locality of reference, etc etc advanced performance stuff).
    */

    //So in order to make our program faster and smoother, we should write in such a way that the GC is barely used at all
    //thereby minimizing dead time while we wait for the GC to do its job, i.e. we should write code in such a way that 
    //we allocate as little memory on the heap as possible. We can do this by using mainly value types and very few
    //reference types in our code.

    //But do note that the stack has a size limit. The default stack size for 64bit processes is 4MB, and 1MB for 32bit
    //processes. While a normal program will probably never actually hit this limit as even 1 MB is a MASSIVE amount
    //of storage for value types and pointers, it's good to remember this in case the situation ever arises
    //(it probably wont).

    //Before we can start implementing this newfound knowledge into our code, we must first know somwthing else.
    //Sometimes, even when we use a value type, it may get converted into a reference type and put on the heap:

    //BOXING AND UNBOXING

    //Boxing is the process of coverting a value type to a reference type, specifically an object.

    public static void boxing()
    {
        int x = 0;

        object xobj = x; //what happens in this line is boxing

        //the value type x is stored on the stack. We created a reference type xobj and set it to the value of x,
        //which has created the object with x's value on the heap and has created a pointer to that object on the stack.

        //This process is called boxing because the value type is put in a box of the reference type and stored on the heap.
        //Here, the value type x is put into a box called xobj of reference type object, and then stored on the heap.

        //As you can tell from the example above, boxing is an implicit conversion process.
    }

    //Unboxing is the exact reverse of boxing. Unboxing is the process of coverting a reference type to a value type.

    public static void unboxing()
    {
        int y = 0;

        object yobj = y; //boxing

        int z = (int) yobj; //what happens in this line is unboxing

        //the value type y is stored on the stack, then we box it as yobj and store it on the heap with a pointer to yobj
        //on the stack. Then we create a new value type z and set it to yobj after converting it to a value type.

        //the data stored in yobj was taken out of its box and set to be the data of the value type z. 

        //As you can tell from the example above, unboxing is an explicit conversion process.
    }

    //So basically, we should try and use value types instead of reference types whenever and where ever possible. But this
    //extends to farther than just individual variables we declare. We know about generic and non-generic types, and that
    //most built-in classes in c# are generic. This is actually becuase of boxing. If we use a non-generic class like an
    //OrderedDictionary for example, every key and value in every key-value pair is stored as an object. This means that
    //all of it stored on the heap, and when we want to perform operations with any element we have to unbox it. This leads
    //to alot of excess time and memory being used. This is why generic types are always much more preferred than
    //non-generic types.

    //Apart from sticking to generic types, we can also improve performance by using some value type counterparts of
    //reference types, like spans (explained in Spans.cs) and structs instead of arrays and classes. But these
    //types do have their own restrictions and so this may not be possible all the time. So only use whenever
    //possible and actually beneficial.

    //Tidbit: String interpolation really does string.format behind the scenes, which uses objects for its parameters and
    //can lead to boxing. This can be avoided by using the .ToString() method on every variable, BUT this may actually be
    //slower than boxing in many cases. There doesn't seem to be a good solution to this atm, so I guess just keep using
    //regular interpolation.

    //Tidbit: The ref keyword used with the struct keyword creates a ref struct. A ref struct is a type of struct that can
    //NEVER be allocated on the heap in any case (even through boxing), only on the stack.

    public static void refstruct()
    {
        abc ex = new abc(1);

        Console.WriteLine(ex.geta());

    }
}

ref struct abc 
{
    private int a = 0;

    public abc(int q)
    {
        a = q;
    }

    public int geta()
    {
        return a;
    }
}
