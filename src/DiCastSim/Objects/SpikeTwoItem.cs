using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class SpikeTwoItem : BaseItem
    {
        public SpikeTwoItem()
        {
            effect = new SpikeTwoEffect();
            Img = Properties.Resources.trap2;
        }
    }
}
