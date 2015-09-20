using System;
using System.Threading.Tasks;
using Akka.Actor;
using ExploringTypedActor.Actors;

namespace ExploringTypedActor
{
    class Program
    {
        private static ActorSystem TypedActorSystem;
        static void Main(string[] args)
        {
            // Akka prefers creation of objects via factories
            // this is due to the fact that internally Akka does a lot of system internally
            TypedActorSystem = ActorSystem.Create("TypedActorSystem");
            Console.WriteLine("Actor system created");

            // Akka uses the movie industry to name a few items
            // To create an Actor you use the Props class
            Props whatsMyTypeAgainProps = Props.Create<WhatsMyTypeAgainActor>();

            // ActorOf will create the Actor
            // You can get a reference to the Actor using the ActorOf which returns an IActorRef
            TypedActorSystem.ActorOf(whatsMyTypeAgainProps, "WhatsMyTypeAgain");
            
            // Alternatively you can use ActorSelection and a path to the Actor 
            ActorSelection whatsMyTypeAgainActor = TypedActorSystem.ActorSelection("/user/WhatsMyTypeAgain");

            // Tell is void
            whatsMyTypeAgainActor.Tell("I'm 30");
            whatsMyTypeAgainActor.Tell(30);

            // Ask with return a value (request response)
            var askTask = whatsMyTypeAgainActor.Ask<int>("Hey what's my age again?");
            Task.WaitAll(askTask);
            Console.WriteLine(askTask.Result);

            Console.ReadKey();
            TypedActorSystem.Shutdown();
            TypedActorSystem.AwaitTermination();
            
        }
    }
}
