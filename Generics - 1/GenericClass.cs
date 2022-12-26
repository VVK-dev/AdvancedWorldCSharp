using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericClass<T>
    {

        //Here we have created a generic class that accepts a type T. The type T isn't an actual type of anything,
        //it is instead a placeholder type that will change depending on what the user inputs when calling
        //this class. It is similar to i in a for loop, i doesn't hold any value on it's own but is a placeholder
        //that changes with every iteration.

        //And similar to i, naming the placeholder type that your generic takes as t is another programming
        //convention. We can add more placeholder types after T by separating them with a comma.
        //eg: class GenericClass<T,U,V>

        //The value T stores is a type.

        public T Data; //Here we have created a variable of type T. T may be an int, a string or another class.

        public GenericClass(T data)
        {
            Data = data;
        }
        public void Printdata()
        {
            Console.WriteLine(Data);
        }
    }

    //Sometimes though, a generic class may be TOO generic. Let me show you what I mean:

    //Lets create a Hero class and a HeroHelper class which takes Hero objects and performs actions on them.

    public class Hero
    {
        public string Name;
        public int Dmg;

        public void Attack()
        {
            Console.WriteLine($"{Name} did {Dmg} damage.");
        }
    }

    public class Warrior : Hero
    {

    }

    public class Archer : Hero
    {

    }

    public class Monk : Hero
    {

    }

    public class Mage : Hero
    {

    }

    //Refer to Generics.cs to view example heros


    public class HeroHelper<T> where T : Hero
    {
        public T hero;

        public HeroHelper(T heroarg)
        {
            hero = heroarg;
        }
        
        
        //Lets create a forceattack method which forces the current Hero stored in Data to attack.

        public void ForceAttack()
        {
            //Data.Attack();

            //Although we want the Hero to attack when we try to execute the above line of code we get an error.
            //This is because the datatype of the Data variable could be anything. We have stored it
            //as T but it could be an int, string, list, bool,etc. and these dont have the Attack
            //method. Because it is a variable the compiler doesn't know what methods it has access to.

            //So to limit the types we can pass into the HeroHelper class we can do 1 of 2 things:

            //1) We can simply change it to take only Hero types instead of T => public class HeroHelper<Hero>{ stuff }
            
            //2) We can use something called a constraint. As the name suggests a constraint limits the
            //amount of types of the HeroHelper class. We can add a constraint to this class by using the where keyword after <T> and then typing T : <type>. In words,
            //we are making sure that whatever type T is it IMPLEMENTS the given <type>. So now, all Hero objects and Hero subclass objects
            //can use the HeroHelper.

            //NOTE: subclasses can use the HeroHelper even in option 1

            //Now we can use Hero.attack:

            hero.Attack();

            //Now because we have made sure that the HeroHelper only accepts Hero or it's subclasses like Monk or Warrior objects,
            //We cannot create a Herohelper of any other type like int or string.

            //Now Refer to point A in Generics.cs

        }

    }
}
