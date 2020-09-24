namespace DiCastSim.Objects
{

    class MonsterThreeItem : MonsterBase
    {
        public override string Do()
        {
            base.Do();
            game.Player.Life -= 3;
            return $"{game.Player.Name} Monster level III";
        }

        public MonsterThreeItem()
        {
            Img = Properties.Resources.monster3;
        }
    }
}
