using System.Collections.Generic;
using Akka.Actor;
using ExploringRemoting.Common.Messages;

namespace ExploringRemoting.Common.Actors
{
    public class RandomTextCoordinatorActor : ReceiveActor
    {
        private readonly Dictionary<int, IActorRef> users;
        private int count = 0;

        public RandomTextCoordinatorActor()
        {
            users = new Dictionary<int, IActorRef>();

            Receive<RandomTextMessage>(message =>
            {
                CreateChildActorIfNotExists(message.UserId);
                IActorRef childActorRef = users[message.UserId];
                count++;
                childActorRef.Tell(message);
                ColorConsole.WriteLineMagenta($"Sending message to Actor with Id: {message.UserId}");
                ColorConsole.WriteLineRed($"Count: {count}");
            });
        }

        private void CreateChildActorIfNotExists(int userId)
        {
            if (users.ContainsKey(userId)) return;
            IActorRef childActorRef = Context.System.ActorOf(Props.Create(() => new RandomTextActor()), "RandomTextActor" + userId);
            users.Add(userId, childActorRef);
        }
    }
}