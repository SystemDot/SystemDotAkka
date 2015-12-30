using Akka.Actor;

namespace SystemDot.Akka.Testing
{
    public class TestingActorSystemFactory : IActorSystemFactory
    {
        private readonly ViewChangeWatcherContext context;

        public TestingActorSystemFactory(ViewChangeWatcherContext context)
        {
            this.context = context;
        }

        public ActorSystem Create(string name)
        {
            ActorSystem system = ActorSystem.Create(name);
            system.ActorOf(Props.Create(() => new ViewChangeWatcher(context)));

            return system;
        }
    }
}