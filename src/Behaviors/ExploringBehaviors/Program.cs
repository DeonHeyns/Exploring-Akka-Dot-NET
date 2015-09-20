using System;
using System.Threading.Tasks;
using Akka.Actor;
using ExploringBehaviors.Actors;

namespace ExploringBehaviors
{
    class Program
    {
        private static ActorSystem ReceiveActorSystem;
        static void Main(string[] args)
        {
            // Akka prefers creation of objects via factories
            // this is due to the fact that internally Akka does a lot of system internally
            ReceiveActorSystem = ActorSystem.Create("ReceiveActorSystem");
            Console.WriteLine("Actor system created");

            // Akka uses the movie industry to name a few items
            // To create an Actor you use the Props class
            Props whatsMyTypeAgainProps = Props.Create<WhatsMyTypeAgainActor>();

            // ActorOf will create the Actor
            // You can get a reference to the Actor using the ActorOf which returns an IActorRef
            ReceiveActorSystem.ActorOf(whatsMyTypeAgainProps, "WhatsMyTypeAgain");
            
            // Alternatively you can use ActorSelection and a path to the Actor 
            ActorSelection whatsMyTypeAgainActor = ReceiveActorSystem.ActorSelection("/user/WhatsMyTypeAgain");

            // Tell is void
            whatsMyTypeAgainActor.Tell("I'm 30");
            whatsMyTypeAgainActor.Tell("I'm 31"); // This message is ignored since the Actor's behavior has changed
            whatsMyTypeAgainActor.Tell(30);

            Console.ReadKey();
            ReceiveActorSystem.Shutdown();
            ReceiveActorSystem.AwaitTermination();

            Console.ReadKey();
        }
    }
}