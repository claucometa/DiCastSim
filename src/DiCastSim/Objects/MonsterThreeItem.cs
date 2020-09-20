using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class MonsterThreeItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} Monster level III";
        }

        public MonsterThreeItem()
        {
            Img = Properties.Resources.monster3;
        }
    }
}
