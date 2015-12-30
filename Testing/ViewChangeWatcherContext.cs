
namespace SystemDot.Akka.Testing
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Immutable;

    public class ViewChangeWatcherContext
    {
        private ImmutableList<ViewChanged> events;
        private TaskCompletionSource<bool> expectedViewChangeOccurred;
        private Predicate<ViewChanged> isExpectedChange;

        public ViewChangeWatcherContext()
        {
            events = ImmutableList.Create<ViewChanged>();
            ExpectChange(changed => false);
        }

        public void AddViewChangedEvent(ViewChanged toAdd)
        {
            events = events.Add(toAdd);
            NotifyIfChangeIsExpected(toAdd);
        }

        private void NotifyIfChangeIsExpected(ViewChanged toAdd)
        {
            if (isExpectedChange(toAdd))
            {
                expectedViewChangeOccurred.SetResult(true);
            }
        }

        private void ExpectChange(Predicate<ViewChanged> toExpect)
        {
            ResetTaskCompletionSource();
            isExpectedChange = toExpect;
            events.ForEach(NotifyIfChangeIsExpected);
        }
        private void ResetTaskCompletionSource()
        {
            expectedViewChangeOccurred = new TaskCompletionSource<bool>();
        }

        private void WaitForChange(Predicate<ViewChanged> toExpect)
        {
            ExpectChange(toExpect);
            expectedViewChangeOccurred.Task.Wait(TimeSpan.FromSeconds(3));
        }

        public void WaitForChange<TExpectedView, TExpectedEvent>()
        {
            WaitForChange(vc => vc.View is TExpectedView && vc.Event is TExpectedEvent);
        }
        public void WaitForChange<TExpectedView, TExpectedEvent>(Predicate<TExpectedEvent> toExpect) where TExpectedEvent : class
        {
            WaitForChange(vc => vc.View is TExpectedView && vc.Event is TExpectedEvent && toExpect((TExpectedEvent) vc.Event));
        }
    }
}