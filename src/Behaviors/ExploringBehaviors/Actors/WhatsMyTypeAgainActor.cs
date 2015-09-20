using System;
using Akka.Actor;

namespace ExploringBehaviors.Actors
{
    // ReceiveActor when using the ReceiveActor you will need to put your message
    // handling code in the constructor.
    // 
    // Behaviors allow an actor to change which Messages it listens to.
    // This is quite Powerful as it allows you to change the implementation of the Actor
    // Actors are usually stateful and using this state the Actor can flip how it responds to
    // incoming messages
    public class WhatsMyTypeAgainActor : ReceiveActor
    {
        public WhatsMyTypeAgainActor()
        {
            HandleString();
        }

        private void HandleString()
        {
            Receive<string>(message => Handle(message));
        }

        private void HandleInt()
        {
            Receive<int>(message => Handle(message));
        }

        public void Handle(string message)
        {
            Console.WriteLine($"I received '{message}' which is of type {message.GetType()}");
            Become(HandleInt);
        }

        public void Handle(int message)
        {
            Console.WriteLine($"I received '{message}' which is of type {message.GetType()}");
            Become(HandleString);
        }
    }
}
