using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class BreadItem : BaseItem
    {
        public BreadItem()
        {
            effect = new BreadEffect();
            Img = Properties.Resources.bread;
        }
    }
}
