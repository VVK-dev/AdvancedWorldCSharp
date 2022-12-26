//The System.Environment class provides information about, and means to manipulate, the current environment and
//platform. The current environment refers to this current .cs program. This class can be used to find out
//information about the current computer such as it's os or how long it has been on for.
//This class cannot be inherited.

/*
All methods start with Environment.<MethodName>()

PROPERTIES                      EXPLANATION  
 
CurrentDirectory	            Gets or sets the fully qualified path of the current working directory.
 
Is64BitOperatingSystem	        Gets a value that indicates whether the current operating system is a 64-bit 
                                operating system.

Is64BitProcess	                Gets a value that indicates whether the current process is a 64-bit process.

MachineName	                    Gets the NetBIOS name of this local computer.
 
OSVersion	                    Gets the current platform identifier and version number.

ProcessId	                    Gets the unique identifier for the current process.

ProcessorCount	                Gets the number of processors available to the current process.

ProcessPath	                    Returns the path of the executable that started the currently executing process. 
                                Returns null when the path is not available.
 
SystemDirectory	                Gets the fully qualified path of the system directory.

TickCount	                    Gets the number of milliseconds elapsed since the system started as a 32 bit integer.

TickCount64	                    Gets the number of milliseconds elapsed since the system started as a long 
                                (64 bit integer).

UserName	                    Gets the user name of the person who is associated with the current thread.

 */


//There are methods to this class as well but most are rather complicated and beyond my scope for now.


class EnvClassMain{
    public static void Main(string[] args) {

        Console.WriteLine(Environment.CurrentDirectory);

        Console.WriteLine(Environment.Is64BitOperatingSystem);

        Console.WriteLine(Environment.MachineName);

        Console.WriteLine(Environment.OSVersion.ToString());

        Console.WriteLine(Environment.ProcessPath);

        Console.WriteLine(Environment.SystemDirectory);

        Console.WriteLine(Environment.TickCount);

        Console.WriteLine(Environment.UserName);


        //From ValReftypesConstReadonly

        ValRefTypes.Do();

    }
}
