using System;
using Akka.Actor;

namespace ExploringUntypedActor.Actors
{
    // UntypedActor will accept messages of any type and it is 
    // the responsibility of the OnReceive method to decide how
    // a message will be processed
    public class WhatsMyTypeAgainActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Console.WriteLine($"I received '{message}' which is of type {message.GetType()}");

            if(message.ToString() == "Hey what's my age again?")
                Sender.Tell(30);
        }
    }
}
