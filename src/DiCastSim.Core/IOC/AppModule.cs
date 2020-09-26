using Autofac;
using DiCastSim.Core.Services;

namespace DiCastSim.Core
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Game>().SingleInstance();
            builder.RegisterType<CastleFabric>().SingleInstance();
            builder.RegisterType<DiceGenerator>().SingleInstance();
            builder.RegisterType<Randomizer>().SingleInstance();
            builder.RegisterType<MonsterService>().SingleInstance();
        }
    }
}