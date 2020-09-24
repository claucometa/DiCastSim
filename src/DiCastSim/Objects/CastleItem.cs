using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    internal class CastleItem : BaseItem
    {
        public CastleItem()
        {
            effect = new CastleEffect();
            Img = Properties.Resources.castle;
        }
    }
}
