using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    internal class NothingItem : BaseItem
    {        
        public NothingItem()
        {
            effect = new NothingEffect();
        }
    }
}
