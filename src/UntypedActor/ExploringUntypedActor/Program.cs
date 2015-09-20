using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using ExploringUntypedActor.Actors;

namespace ExploringUntypedActor
{
    class Program
    {
        private static ActorSystem UntypedActorSystem;
        static void Main(string[] args)
        {
            // Akka prefers creation of objects via factories
            // this is due to the fact that internally Akka does a lot of system internally
            UntypedActorSystem = ActorSystem.Create("UntypedActorSystem");
            Console.WriteLine("Actor system created");

            // Akka uses the movie industry to name a few items
            // To create an Actor you use the Props class
            Props whatsMyTypeAgainProps = Props.Create<WhatsMyTypeAgainActor>();

            // ActorOf will create the Actor
            // You can get a reference to the Actor using the ActorOf which returns an IActorRef
            UntypedActorSystem.ActorOf(whatsMyTypeAgainProps, "WhatsMyTypeAgain");
            
            // Alternatively you can use ActorSelection and a path to the Actor 
            ActorSelection whatsMyTypeAgainActor = UntypedActorSystem.ActorSelection("/user/WhatsMyTypeAgain");

            // Tell is void
            whatsMyTypeAgainActor.Tell("I'm 30");

            // Ask with return a value (request response)
            var askTask = whatsMyTypeAgainActor.Ask<int>("Hey what's my age again?");
            Task.WaitAll(askTask);
            Console.WriteLine(askTask.Result);

            Console.ReadKey();
            UntypedActorSystem.Shutdown();
            UntypedActorSystem.AwaitTermination();
            
        }
    }
}
