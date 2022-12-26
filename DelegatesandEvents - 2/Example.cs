using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesandEvents
{
    public class Example
    {
        public static void Main(string[] args)
        {
            //A

            Guild guild = new Guild();
            GuildHall RavenCrest = new GuildHall("RavenCrest","Purple");

            guild.NewMemberAdded += MemberWelcomer.Welcome;
            guild.NewMemberAdded += RavenCrest.AddBedroom;

            guild.AddMember("King");

            //>>> Events.Cs - C
        
            //B

            Events events = new Events();

            events.Number2 += Numtwotrue;

            events.Invokeevent();
        
        }

        public static void Numtwotrue(object sender, MoreInfo e)
        {
            Console.WriteLine(e.colour);
            Console.WriteLine(e.num);
        }

    }
}
