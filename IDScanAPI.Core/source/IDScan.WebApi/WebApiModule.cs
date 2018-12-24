namespace IDScan.WebApi {
    using Autofac;

    public class WebApiModule : Autofac.Module {
        protected override void Load (ContainerBuilder builder) {
            //
            // Register all Types in IDScan.WebApi
            builder.RegisterAssemblyTypes (typeof (Startup).Assembly)
                .AsSelf ()
                .InstancePerLifetimeScope ();
        }
    }
}