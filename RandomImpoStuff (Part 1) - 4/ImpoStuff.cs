
using System.Globalization;

class ImpoStuff
{
    public static void Main(string[] args)
    {
        //TRYPARSE

        //The advantage of using Parse is the TryParse method, which joins a try catch block and the parse method into
        //1.

        //The TryParse method returns a boolean and takes in 2 variables. The first one is the variable we want to be 
        //parsed and the second one is the variable to which the parsed value will be assigned. The returned boolean
        //is true if the Parse happend without issue or false if there was an error.

        string a = "1";

        bool d = int.TryParse(a,out int c);

        //The out keyword is similar to the ref keyword we used previously, instead of sending a copy of a variable
        //it sends a pointer to the result variable.

        Console.WriteLine(c);

        //OTHER STUFF:

        //DATETIME

        //The way we can find out the current timezone of a machine is by using the methods in the CultureInfo class
        //from System.Globalization

        string e = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
        
        //The above method returns the current machines current datetime pattern as a string.
        //CultureInfo AKA Locale

        Console.WriteLine(e);

        //CultureInfo has ALOT of different useful methods, go through them when needed.
        
        //DEFAULT VALUES

        //All built-in variable types have a default value.
        //Uninitialized variables store their default value. Each type has a different default value
        //for all number types like int, double, etc. it's 0 in that format - 0 for int, 0.0 for double
        //,etc.

        //For strings it's an empty string and for bool it's false.
    }
}