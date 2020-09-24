using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class StoreItem : BaseItem
    {
        public StoreItem()
        {
            effect = new StoreEffect();
            Img = Properties.Resources.store;
        }
    }
}
