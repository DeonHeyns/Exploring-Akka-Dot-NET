using System;
using Akka.Actor;

namespace ExploringTypedActor.Actors
{
    // TypedActor is not the same as the Java / Scala implementation
    // In the JVM version TypedActor proxies calls to methods 
    // The .NET version of TypedActor requires the use of the IHandle interface
    // Akka.NET will route the message to the appropriate Handle method
    public class WhatsMyTypeAgainActor : TypedActor, IHandle<string>, IHandle<int>
    {
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
