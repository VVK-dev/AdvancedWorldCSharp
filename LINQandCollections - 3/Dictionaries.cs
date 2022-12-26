using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dictionaries {

    //HASHING

    //Hashing is a pretty in-depth topic, so I will only go over the very basics of it here. I may continue this
    //explanation of hashing at a later date in another file.

    //Hashing is the process of mapping some data to a fixed-size (usually numerical) value. The value can then be
    //used to point to that data. This value is generally called a hash code.
    //Hash codes of identical data are the same: "a" and "a" will have the same hash code, but "a" and "A" will not.

    //Data types that use hashing to store data start with the word hash, eg: hashmap, hashtable, hashset, etc.

    //Here I will be going over HashMaps, i.e. HashTables AKA Dictionaries.

    //A hashmap is the java equivalent of a dictionary, and hashtables are the c# equivalent of them (but it is
    //non-generic and outdated. C# has a more modern, generic version just called 'dictionary' in its place)


    //DICTIONARIES

    //Taken from TutorialsTeacher.com (but heavily modified by me)
    /*
    Dictionaries are collection that stores key-value pairs in no particular order.

    1)Keys must be unique and cannot be null.
    2)Values can be null or duplicate.
    3)Elements are stored as KeyValuePair<<typeofkey>, <typeofvalue>> objects.
    */

    /*
    CONSTRUCTORS                                         EXPLANATION
    
    Dictionary<TKey,TValue>()	                        Initializes a new instance of the Dictionary<TKey,TValue> class
                                                        that is empty

    Dictionary<TKey,TValue>(Dictionary<TKey,TValue>)	Initializes a new instance of the Dictionary<TKey,TValue> class 
                                                        that contains elements copied from the specified 
                                                        Dictionary<TKey,TValue>

    Dictionary<TKey,TValue>(Int32)	                    Initializes a new instance of the Dictionary<TKey,TValue> class 
                                                        that is empty, has the specified initial capacity, and uses the 
                                                        default equality comparer for the key type.     
    */


    public static void Dictionaries1() {


        Dictionary<string, int> d = new() { { "a", 1 }, { "b", 2 }, { "c", 3 } };

        //each key-value pair is declared within its own brackets within the brackets of the dictionary itself

        //We can access individual values in a dictionary the same way as in an array but just with the key instead of an index

        Console.WriteLine(d["a"]);

        //we can use the .keys property to get the keys of the dictionary

        foreach (string key in d.Keys)
        {
            Console.WriteLine(key);
        }

        //we can use the .values property to get the values of the dictionary
        //we can use the .count property to get the number of key-value pairs in the dictionary

        //dictionaries have the .add(key,value) and .tryadd(key,value) method to add elements, and .remove(key) to
        //remove them
        //they also have .containskey(key) and .containsvalue(value) methods and a trygetvalue(key,value) method
        //they also have the general collection methods like .clear(), .ToString(), .Equals(), etc.

        //One thing about dictionaries is that they are unordered. While this may not be apparent when simply adding
        //elements into the dictionary, once you remove an element the entire thing gets jumbled.


        //OREDERED DICTIONARIES

        //To keep the order of the elements we can use an OrderedDictionary
        //BUT, unlike dictionaries and most other classes we've come across so far, OrderedDictionaries are NOT GENERIC 
        //This means that the type for the key-value pairs is not a requirement when creating an OD, and elements
        //can have key and value types that differ from element to element.

        //Another thing is that ODs store elements in the DictionaryEntry type, which are essentially the same as
        //key-value pairs

        OrderedDictionary od = new();

        foreach (KeyValuePair<string,int> element in d) {
            
            od.Add(element.Key, element.Value);
        }

        od.Add(true, "maybe");

        foreach (DictionaryEntry element in od)
        {
            Console.WriteLine(element.Key);
            Console.WriteLine(element.Value);
        }

        //ODs possess all the same methods as dictionaries + the ability to get the value of a key at a specified
        //index, like an array.

        Console.WriteLine(od[0]);

        //@@@!!! Non-generic data types are not really recommended for use. They are generally slower than
        //their generic counterparts (explained in MemoryAllocation in Optimization - 5) @@@!!!


        //SORTED DICTIONARIES

        //A sorted dictionary is a collection of key/value pairs that are sorted on the key.

        //In order to sort values, the dictionary implements the IComparer Interface. This interface contains the
        //Compare(T? val1, T? val2) method which is the one used for comparisions. This method returns -1 if val1<val2,
        //0 if val1 == val2, or 1 if val1>val2.


        /*
        SYNTAX (1)                                                        EXPLANATION

        SortedDictionary<TKey,TValue> varname = new()                           Initializes a new instance of the 
                                                                                SortedDictionary<TKey,TValue> class that 
                                                                                is empty and uses the default Compare 
                                                                                method to sort the keys.

        SortedDictionary<TKey,TValue> varname = new(Dictionary<TKey,TValue>)    Initializes a new instance of the 
                                                                                SortedDictionary<TKey,TValue> class that 
                                                                                contains elements copied from the 
                                                                                specified IDictionary<TKey,TValue> and 
                                                                                uses the default Compare method 
                                                                                to sort the keys.

        */

        //Instead of using the default Compare method, we can declare our own Compare method that can be used to sort
        //the dictionary. We can do this by creating a class that implements the class Compare<T>, then override the
        //Compare method to take in 2 values and output either 1,0 or -1 depending on the comparsion result.

        /*
        SYNTAX (2)                                                                          EXPLANATION

        SortedDictionary<TKey,TValue> varname = new(CompareMethod)                          Initializes a new instance of 
                                                                                            the SortedDictionary<TKey,TValue> 
                                                                                            class that is empty and uses the
                                                                                            specified Comparer method to
                                                                                            compare keys.                                                                                            

        SortedDictionary<TKey,TValue> varname = new(IDictionary<TKey,TValue>,CompareMethod) Initializes a new instance of 
                                                                                            the SortedDictionary<TKey,TValue> 
                                                                                            class that contains elements 
                                                                                            copied from the specified 
                                                                                            Dictionary and uses the 
                                                                                            specified Comparer method to
                                                                                            compare keys.
        */


        SortedDictionary<string,string> sorteddict= new(StringComparer.CurrentCultureIgnoreCase);

        SortedDictionary<string, int> sorteddict2 = new(d);
    }

    public static void Main() { Dictionaries1();}
}
