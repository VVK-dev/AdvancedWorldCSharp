using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enumerables
{
    //ENUMERABLE

    //An enumerable is any object that implements the IEnumerable<T> interface, which allows it to be used with a foreach
    //The IEnumerable<T> interface defines a single method, GetEnumerator, which returns an object that implements the
    //IEnumerator<T> interface. The IEnumerator<T> interface defines methods for iterating through a sequence of values, including MoveNext,
    //which advances the iterator to the next element in the sequence, and Current, which returns the current element.

    private static void IEnum()
    {
        //IEnumerable is a collection interface

        //Instead of declaring a variable as a list we can declare it as an IEnumerable<<elementtype>>

        //When we declare something as IEnumerable what it does is save the variable as a list without actually
        //processing it into one. Only when we call on it does it get processed into a list. This is called
        //Lazy Loading. 


        List<int> nums = new List<int>() { 1, 2, 3, 4, 5 };

        //Most LINQ methods on lists actually return IEnumerables

        IEnumerable<int> list = nums.Where(n => n > 1);
    }




    //From here on out, this topic gets very in-depth at a level that I feel I'm not at yet.
    //I will continue this explanation at a later date when I am more experienced with all this.


}
