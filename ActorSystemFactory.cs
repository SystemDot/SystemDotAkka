using Akka.Actor;

namespace SystemDot.Akka
{
    public class ActorSystemFactory : IActorSystemFactory
    {
        public ActorSystem Create(string name)
        {
            ActorSystem system = ActorSystem.Create(name);
            return system;
        }
    }
}