namespace DiCastSim.Core.Objects
{
    public abstract class ItemEffect
    {
        protected readonly Game game;

        public ItemEffect()
        {
            game = IOC.Resolve<Game>();
        }

        public abstract string Do();
    }
}
