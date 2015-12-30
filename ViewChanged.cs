using System;

namespace SystemDot.Akka
{
    public class ViewChanged
    {
        public ViewActor View { get; private set; }
        public object Event { get; private set; }

        public ViewChanged(ViewActor view, object @event)
        {
            View = view;
            Event = @event;
        }
    }
}