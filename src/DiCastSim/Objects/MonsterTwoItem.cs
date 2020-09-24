namespace DiCastSim.Objects
{
    class MonsterTwoItem : MonsterBase
    {
        public override string Do()
        {
            base.Do();
            game.Player.Life -= 3;
            return $"{game.Player.Name} Monster level II";
        }

        public MonsterTwoItem()
        {
            Img = Properties.Resources.monsterTwo;
        }
    }
}
