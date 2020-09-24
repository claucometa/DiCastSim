using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    internal class SwordItem : BaseItem
    {
        public SwordItem()
        {
            effect = new SwordEffect();
            Img = Properties.Resources.swords;
        }
    }
}
