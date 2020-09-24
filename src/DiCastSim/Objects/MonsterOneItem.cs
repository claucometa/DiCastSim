using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class MonsterOneItem : BaseItem
    {
        public MonsterOneItem()
        {
            effect = new MonsterOneEffect();
            Img = Properties.Resources.monsterOne;
        }
    }
}
