using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class SpikeOneItem : BaseItem
    {
        public SpikeOneItem()
        {
            effect = new SpikeOneEffect();
            Img = Properties.Resources.trap1;
        }
    }
}
