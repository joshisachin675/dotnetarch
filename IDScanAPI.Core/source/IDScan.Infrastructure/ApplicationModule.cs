namespace IDScan.Infrastructure
{
    using Autofac;

    public class ApplicationModule : Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in IDScan.Application
            builder.RegisterAssemblyTypes (typeof (System.ApplicationException).Assembly)
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}