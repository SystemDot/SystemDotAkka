using Akka.Actor;

namespace SystemDot.Akka.Testing
{
    public class ViewChangeWatcher : ReceiveActor
    {
        public ViewChangeWatcher(ViewChangeWatcherContext context)
        {
            Context.System.EventStream.Subscribe(Self, typeof (ViewChanged));

            Receive<ViewChanged>(e =>
            {
                context.AddViewChangedEvent(e);
            });
        }
    }
}