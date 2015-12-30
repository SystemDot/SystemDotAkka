using System;
using Akka.Actor;

namespace SystemDot.Akka
{
    public abstract class ProcessManagerActor : ReceiveActor
    {
        private readonly IActorRef commandProcessor;

        protected ProcessManagerActor(IActorRef commandProcessor)
        {
            this.commandProcessor = commandProcessor;
        }

        protected void When<TEvent>(Action<TEvent> onWhen)
        {
            Context.System.EventStream.Subscribe(Self, typeof (TEvent));
            Receive(onWhen);
        }

        protected void Then<TCommand>(TCommand command)
        {
            commandProcessor.Tell(command);
        }
    }
}