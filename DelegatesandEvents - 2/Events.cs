using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesandEvents
{
    public class Events
    {
        //A

        //Events are simply just a way for classes to notify other classes and objects that an event has occured.
        //In all honesty they're pretty much the exact same as delegates except for 2 key differences:

        //1)Unlike delegates we can't use <eventvariable> = <method> . We can only use <eventvariable> += <method> or
        //<eventvariable> -= <method> . This stops us and others using our code from effectively resetting the value of
        //the event to a single method.
        //2)They can't be called or fired from another class (but can still have other methods added to or 'subscribed'
        //to them from other classes).

        //All in all, other than the lingual difference between events and delegates (delegates are essentially just
        //method signatures whereas events are things that are meant notify other things), events are just delegates
        //but with less functionality.

        //Note: Methods that are added to events are called 'subscribers' and the event itself is called a 'publisher'.

        //To provide an example of events let's assume this: We are making an rpg and this part of the code handles
        //how a new member is added to one of the many guild halls.

        //>>> B

        //C

        //The EventHandler delegate is a built-in delegate that is generally the main way to create an event:

        public event EventHandler Number1;

        //it's signature is that of a method that returns void and accepts object sender, EventArgs e .

        //EventArgs is an empty class that is meant to hold all arguments for an event as properties inside itself.
        //We'll get back to it later.

        //When the EventHandler event is invoked, it will pass sender and e to all subscribers.

        int i = 1;

        public void Isnumber1()
        {
            if (i == 1)
            {
                Number1?.Invoke(this,EventArgs.Empty); //EventArgs has only 1 default field: Empty
            }
        }

        //The EventHandler delegate also has a generic version.
        //In EventHandler<T>, T will replace the type of the second variable when invoking from EventArgs to T
        //So then all methods subscribed to this event will have to accept an obejct of type T as a parameter
        //rather than EventArgs.

        //We can create a class that implements EventArgs and set T to that class. We can create fields in that
        //class and thus use it to send more information.
        
        public event EventHandler<MoreInfo> Number2; //see below for moreinfo class creation

        public void Invokeevent()
        {
            Number2?.Invoke(this,new MoreInfo { colour = "blue", num = 2 });
        }


        //>>>Example.cs - B for eventhandler example

    }

    public class MoreInfo : EventArgs
    {
        public string colour;
        public int num;
    }

    //B
    public class Guild{
        
        List<string> members = new();

        //Events require delegates to function.

        public event Action<string> NewMemberAdded;

        //When we try to create an event it must be a delegate type like action, func, custom delegate, etc.

        public void AddMember(string name)
        {
            members.Add(name);

            NewMemberAdded?.Invoke(name);

        }
    }

    public class MemberWelcomer
    {
        public static void Welcome(string name)
        {
            Console.WriteLine($"Welcome {name}!");
        } 
    }

    public class GuildHall
    {
        string guildname;
        string guildcolour;

        public GuildHall(string guildname, string guildcolour)
        {
            this.guildname = guildname;
            this.guildcolour = guildcolour;
        }

        public void AddBedroom(string name)
        {
            Console.WriteLine($"A bedroom was added for {name} in {guildname}.");
        }

        //>>> Example.Cs - A
    }
}
