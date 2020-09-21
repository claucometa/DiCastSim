using Autofac;
using DiCastSim.Core.Services;

namespace DiCastSim.Core
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Game>().SingleInstance();
            builder.RegisterType<DiceGenerator>().SingleInstance();
            builder.RegisterType<RandomContext>().SingleInstance();
            builder.RegisterType<MonsterService>().SingleInstance();
        }
    }
}