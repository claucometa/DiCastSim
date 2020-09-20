using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class BagItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} got a bag";
        }

        public BagItem()
        {
            Img = Properties.Resources.bag;
        }
    }
}
