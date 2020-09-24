using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class CoinItem : BaseItem
    {        
        public CoinItem()
        {
            effect = new CoinEffect();
            Img = Properties.Resources.coin;
        }
    }
}
