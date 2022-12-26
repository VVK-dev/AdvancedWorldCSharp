namespace Generics {
    class Generics
    {
        //Generics are anything in c# that allow us to define what type(s) the parameter being passed into said thing
        //can be.

        //We have already used several generics extensively up until this point like lists, arrays, etc.

        //In order to create a list we have to specify the type of contents the list will hold, like list<string>
        //or list<int>

        public static void Main(string[] args)
        {

            List<string> games = new List<string>(); //we have created a list that can only hold strings

            games.Add("Smite");

            //If we try to add something of type other than string in there we get an error

            //The angular brackets signify that it is a generic.

            //To understand generics in more detail let's create a generic class. Refer to GenericClass.cs

            var myclass = new GenericClass<string>("Zoinks");

            //myclass is of type GenericClass. It takes a type and an argument Data of the same type.  

            Console.WriteLine(myclass.Data);

            var myclass2 = new GenericClass<int>(69); //As myclass2 is a GenericClass object of type int, the
            //argument we pass into it must also be of type int

            //Now things get even more interesting. We can also have generic methods. Refer to Print method below.

            Print(420);
            Print<string>("Jinkies"); //Both ways work
            Print(new Hero()); //This will print GenericsandDelegates.Hero

            //If the print method wasn't a generic then we would have to create severl separate method overloads for ints, strings, etc.
            //Thats where generics come in, they simplify this whole process allowing us to only create the same method once and still have
            //it function with all types.

            //Refer to GenericClass.cs

            //Example Heros:
                
            Monk VVk = new Monk()
            {
                Name = "VVk",
                Dmg = 420
            };

            VVk.Attack();

            var helper = new HeroHelper<Monk>(VVk);

            helper.ForceAttack();

            //REFER TO GENERICCLASS.CS AND POINT A BEFORE PROCEEDING

            var ArcherCreator = HeroFactory<Archer>("Shooter");

            Console.WriteLine(ArcherCreator);

        }

        static void Print<T>(T input)
        {
            Console.WriteLine(input);
            
            //Here we have created a method called print which takes a type, an argument of the same type and writes the input to the console.
            
            //The most interesting thing here is that because the method is also taking an argument of the same type as it's own, we don't
            //actually have to declare the type when we call the method, we can just pass the variable and the variable's type will be auto
            //assigned to the method.
        }
    
        
        //POINT A

        //Now let's create a Method called HeroFactory which will produce Heros for us.

        static T HeroFactory<T>(string HeroName) where T : Hero , new() {
                                                         //when we create a method we give the type of value it will return, here this method
                                                         //returns a variable of type T where T is the type passed in by the user and has to
                                                         //implement Hero.
                                                         //T newhero = new T();

            //The above line of code is the obvious way to go about it, we create a newhero of type T which is Hero.

            //But this actually gives us an error. This is because since we are specifying that T implements Hero, this method will also
            //accept Hero subclasses like Monk, Warrior, Archer, etc. Here, each subclass may have it's own separate constructor,
            //the mage may take 5 paramaters, the Monk 4 and the archer 3. So since each subclass has its own constructor each taking
            //a different type of and number of parameters, simply saying T newhero = new T(); makes no sense.

            //So here we have to specify which constructor we want the method to use. To do so we have to add an additional constraint
            //after where T : Hero specifying said constructor. See method constructor above for example.

            //Here we have specified that this method will only work with paramters of the Hero type and have no parameters in their constructor

            T newhero = new T(); // now this works
            newhero.Name = HeroName;

            return newhero;
        }
    }
}