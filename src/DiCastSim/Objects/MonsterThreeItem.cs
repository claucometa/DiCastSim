using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class MonsterThreeItem : BaseItem
    {
        public MonsterThreeItem()
        {
            effect = new MonsterThreeEffect();
            Img = Properties.Resources.monster3;
        }
    }
}
