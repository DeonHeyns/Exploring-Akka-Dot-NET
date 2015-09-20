using System;
using Akka.Actor;
using ExploringRemoting.Common.Messages;

namespace ExploringRemoting.Common.Actors
{
    public class RandomTextActor : ReceiveActor
    {
        public RandomTextActor()
        {
            Receive<RandomTextMessage>(message => HandleRandomText());
        }

        private void HandleRandomText()
        {
            var text = Guid.NewGuid().ToString("n").Substring(0, 20);
            ColorConsole.WriteLineCyan($"I created the random string '{text}'");
        }
    }
}
