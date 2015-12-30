namespace SystemDot.Akka
{
    public abstract class AggregateEntity
    {
        protected AggregateRootActor Root { get; private set; }

        protected AggregateEntity(AggregateRootActor root)
        {
            Root = root;
        }

        protected void Publish<TEvent>(TEvent @event)
        {
            Root.Publish(@event);
        }
    }
}