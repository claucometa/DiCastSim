using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class MonsterTwoItem : BaseItem
    {
        public MonsterTwoItem()
        {
            effect = new MonsterTwoEffect();
            Img = Properties.Resources.monsterTwo;
        }
    }
}
