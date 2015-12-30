using Akka.Actor;

namespace SystemDot.Akka
{
    public abstract class AggregateRootActor : ReceiveActor
    {
        public void Publish<TEvent>(TEvent @event)
        {
            Context.System.EventStream.Publish(@event);
        }
    }
}