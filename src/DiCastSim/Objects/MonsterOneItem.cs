namespace DiCastSim.Objects
{
    class MonsterOneItem : MonsterBase
    {
        public override string Do()
        {
            base.Do();
            game.Player.Life -= 3;
            return $"{game.Player.Name} Monster level I";
        }

        public MonsterOneItem()
        {
            Img = Properties.Resources.monsterOne;
        }
    }
}
