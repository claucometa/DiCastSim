using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class BagTwoItem : BaseItem
    {        
        public BagTwoItem()
        {
            effect = new BagTwoEffect();
            Img = Properties.Resources.bag;
        }
    }
}
