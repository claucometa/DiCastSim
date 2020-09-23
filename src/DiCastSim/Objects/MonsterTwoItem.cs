namespace DiCastSim.Objects
{
    class MonsterTwoItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} Monster level II";
        }

        public MonsterTwoItem()
        {
            Img = Properties.Resources.monsterTwo;
        }
    }
}
