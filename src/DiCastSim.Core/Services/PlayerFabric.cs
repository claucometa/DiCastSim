using DiCastSim.Core.Models;

namespace DiCastSim.Core
{
    class PlayerFabric
    {
        public Player Build(string name, int init)
        {
            return new Player()
            {
                Name = name,
                Coins = 20,
                Life = 44,
                Atack = 15,
                InitialPosition = init,
            };
        }
    }
}
