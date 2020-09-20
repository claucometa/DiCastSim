using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class BreadItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life += 6;

            return $"{game.Player.Name} eating a bread";
        }

        public BreadItem()
        {
            Img = Properties.Resources.bread;
        }
    }
}
