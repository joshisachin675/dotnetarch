namespace IDScan.Infrastructure.InMemoryDataAccess {
    using Autofac;

    public class InMemoryModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            builder.RegisterType<IDScanContext> ()
                .As<IDScanContext> ()
                .SingleInstance ();
            //
            // Register all Types in InMemoryDataAccess namespace
            builder.RegisterAssemblyTypes (typeof (InfrastructureException).Assembly)
                .Where (type => type.Namespace.Contains ("InMemoryDataAccess"))
                .AsImplementedInterfaces ()
                .InstancePerLifetimeScope ();
        }
    }
}