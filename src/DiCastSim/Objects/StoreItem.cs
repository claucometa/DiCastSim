using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class StoreItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} shop";
        }

        public StoreItem()
        {
            Img = Properties.Resources.store;
        }
    }
}
