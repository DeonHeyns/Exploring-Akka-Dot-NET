using System;
using Akka.Actor;

namespace ExploringReceiveActor.Actors
{
    // ReceiveActor when using the ReceiveActor you will need to put your message
    // handling code in the constructor. 
    public class WhatsMyTypeAgainActor : ReceiveActor
    {
        public WhatsMyTypeAgainActor()
        {
            Receive<string>(message => Handle(message));
            Receive<int>(message => Handle(message));
        }

        public void Handle(string message)
        {
            Console.WriteLine($"I received '{message}' which is of type {message.GetType()}");
            if (message == "Hey what's my age again?")
                Sender.Tell(30);
        }

        public void Handle(int message)
        {
            Console.WriteLine($"I received '{message}' which is of type {message.GetType()}");
        }
    }
}
