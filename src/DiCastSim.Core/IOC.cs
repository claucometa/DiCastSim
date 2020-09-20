using Autofac;

namespace DiCastSim.Core
{
    public static class IOC
    {
        private static readonly IContainer x;

        public static T Resolve<T>() => x.Resolve<T>();

        static IOC()
        {
            var c = new ContainerBuilder();
            c.RegisterModule<AppModule>();
            x = c.Build();
        }
    }
}
