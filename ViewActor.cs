using System;
using Akka.Actor;

namespace SystemDot.Akka
{
    public abstract class ViewActor : ReceiveActor
    {
        protected void ProjectEvent<TEvent>(Action<TEvent> projection)
        {
            Context.System.EventStream.Subscribe(Self, typeof(TEvent));
            Receive<TEvent>(e => Project(e, projection));
        }

        private void Project<TEvent>(TEvent @event, Action<TEvent> projection)
        {
            projection(@event);
            Context.System.EventStream.Publish(new ViewChanged(this, @event));
        }
    }
}