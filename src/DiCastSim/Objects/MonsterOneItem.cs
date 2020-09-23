namespace DiCastSim.Objects
{
    class MonsterOneItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} Monster level I";
        }

        public MonsterOneItem()
        {
            Img = Properties.Resources.monsterOne;
        }
    }
}
