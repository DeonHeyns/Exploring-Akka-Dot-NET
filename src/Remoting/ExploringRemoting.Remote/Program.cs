using Akka.Actor;
using ExploringRemoting.Common;

namespace ExploringRemoting.Remote
{
    class Program
    {
        private static ActorSystem _exploringRemotingActorSystem;
        static void Main(string[] args)
        {
            _exploringRemotingActorSystem = ActorSystem.Create("ExploringRemotingActorSystem");
            ColorConsole.WriteLineGreen("Created the Remote ExploringRemotingActorSystem. Actors will deployed here...");
            _exploringRemotingActorSystem.AwaitTermination();
        }
    }
}
