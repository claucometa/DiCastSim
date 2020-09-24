using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    internal class PortalItem : BaseItem
    {
        public PortalItem()
        {
            effect = new PortalEffect();
            Img = Properties.Resources.portal;
        }
    }
}
