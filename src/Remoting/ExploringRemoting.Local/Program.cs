using System;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using ExploringRemoting.Common;
using ExploringRemoting.Common.Actors;
using ExploringRemoting.Common.Messages;

namespace ExploringRemoting.Local
{
    class Program
    {
        private static ActorSystem _exploringRemotingActorSystem;
        static void Main(string[] args)
        {
            _exploringRemotingActorSystem = ActorSystem.Create("ExploringRemotingActorSystem");
            ColorConsole.WriteLineGreen("Created the Local ExploringRemotingActorSystem. " +
                                        "RandomTextCoordinatorActor will live here and deploy RandomTextActors to the remote instance");

            Props randomTextActorCoordinatorProps = Props.Create<RandomTextCoordinatorActor>();
            _exploringRemotingActorSystem.ActorOf(randomTextActorCoordinatorProps, "RandomTextCoordinator");
            ColorConsole.WriteLineGreen("Created RandomTextCoordinator");

            var random = new Random(0);

            do
            {
                Thread.Sleep(500);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                ColorConsole.WriteLineGray("Hit enter to receive random text...");

                var input = Console.ReadLine();
                if (input == "q")
                {
                    return;
                }

                for (int i = 0; i < 10000; i++)
                {
                    Task.Run(() =>
                    {
                        RandomTextMessage rtm = new RandomTextMessage(random.Next(0, 5));
                        _exploringRemotingActorSystem.ActorSelection("/user/RandomTextCoordinator").Tell(rtm);
                    });
                }
            } while (true);
        }
    }
}
