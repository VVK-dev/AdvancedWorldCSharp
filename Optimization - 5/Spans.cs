using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class Spans
    {

        //Spans are generic ref structs that are essentially the stack allocated version of arrays. They're
        //basically arrays that are allocated on the stack and never on the heap.

        //While spans are generally a little faster than arrays, that's not the main reason to use them.
        //The main reason is memory efficiency from being allocated on the stack and so having the garbage 
        //collector do less work. Remember, while the GC runs our program does not, so the less work the
        //gc does, the better.

        /*
        Syntax                                      Explanation

        Span<T> varname = new();                            Creates a new empty span

        Span<T> varname = new() Span<T>(T[]);               Creates a span from the given array.                                                            

        Span<T> varname = new Span<T>(T[], Int32, Int32)    Creates a span from the array. The span starts
                                                            at the given index (first int param) and has a
                                                            length equal to the second int param.

        */

        //Spans have indices for their elements like arrays.

        //Spans have a very useful method call .Slice() which returns a sub-span.

        /*
        Slice(Int32)            Forms a slice out of the current span that begins at a specified index
                                (inclusive).

        Slice(Int32, Int32)     Forms a slice out of the current span starting at a specified index for a 
                                specified length (both inclusive).
        */

        public static void spansexplanation()
        {
            char[] a = {'a','b','c','d','e','f'};
            Span<char> chars = new Span<char>(a);
            foreach (char c in chars)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine(chars[0]);

            foreach (char ch in chars.Slice(0, 2))
            {
                Console.WriteLine(ch);
            }
        }
    }
}
