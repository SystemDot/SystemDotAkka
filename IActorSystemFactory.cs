using Akka.Actor;

namespace SystemDot.Akka
{
    public interface IActorSystemFactory
    {
        ActorSystem Create(string name);
    }
}