using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class HashSets
    {

        //HASHSETS

        //A hashset is basically an unordered* list that can only contain unique elements. It does so by using the process
        //of Hashing. A HashSet creates a hashcode for every element, and then compares all those codes to that of an element
        //you are trying to add. If it finds the same hashcode in the set already, it throws an exception.

        //*Sets do actually keep the order of elements in which they are entered, but act differently than what you would
        //expect when elements are removed from the set. When you remove something from a set, it doesn't 'remove' the value
        //as such. It takes the element out of the set, then leaves that space as empty. When we then try to add something
        //to the set, it fills up that empty slot first. Only when all empty slots are filled, it starts appending elements
        //we try to add to the set. [THIS ONLY APPLIES TO C#, IDK ABOUT OTHER LANGUAGES]

        //Sets are also optimized for fast lookups and checking if certain elements are in the set, but do so at the cost
        //of losing order. Since they "lack" order, their elements don't have indices.

        //Sets are generally seen as fast collections, but are actually SLOWER than lists in certain cases:

        //1) When the collection is of type <string> and has <=5 elements

        //2) When the collection is of type object and has <=20 elements.

        //Sets are optimized for larger collections with many elements.

        public static void Sets()
        {

            HashSet<string> hs = new() { "a", "b" };

            foreach (string val in hs)
            {
                Console.WriteLine(val);
            }

            try
            {

                hs.Add("a");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            //Sets in C# are literally sets, i.e. mathematical sets of items. So they posses the .UnionWith(anotherset),
            //.IntersectWith(anotherset), .Exceptwith(anotherset), etc. as methods.

            HashSet<string> hs2 = new() { "c", "d" };

            hs.UnionWith(hs2);

            foreach (string val in hs)
            {
                Console.WriteLine(val);
            }


            //SORTED SETS

            //Like dictionaries, sets also have a sorted version.

            /*
            SYNTAX                                      EXPLANATION

            SortedSet<T>()	                            Initializes a new instance of the SortedSet<T> class.

            SortedSet<T>(ComparerMethod<T>)             Initializes a new instance of the SortedSet<T> class that uses a 
                                                        specified comparer.

            SortedSet<T>(IEnumerable<T>)	            Initializes a new instance of the SortedSet<T> class that contains 
                                                        elements copied from a specified enumerable collection.

            SortedSet<T>(IEnumerable<T>, Comparer<T>)	Initializes a new instance of the SortedSet<T> class that contains 
                                                        elements copied from a specified enumerable collection and that uses a 
                                                        specified comparer.
            */
        }
    }
}
