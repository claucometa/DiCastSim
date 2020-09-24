using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class AppleItem : BaseItem
    {                
        public AppleItem()
        {
            effect = new AppleEffect();
            Img = Properties.Resources.apple;            
        }
    }
}
