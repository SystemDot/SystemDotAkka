using SystemDot.Akka;
using SystemDot.Bootstrapping;

namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    public class AkkaBuilderConfiguration<TAkkaBuilderConfiguration> : BootstrapBuilderConfiguration
        where TAkkaBuilderConfiguration : AkkaBuilderConfiguration<TAkkaBuilderConfiguration>
    {
        protected IActorSystemFactory Factory = new ActorSystemFactory();

        protected AkkaBuilderConfiguration(BootstrapBuilderConfiguration @from) : base(@from)
        {
        }

        public TAkkaBuilderConfiguration UsingActorSystemFactory<TActorSystemFactory>()
            where TActorSystemFactory : IActorSystemFactory, new()
        {
            Factory = new TActorSystemFactory();
            return this as TAkkaBuilderConfiguration;
        }
    }
}