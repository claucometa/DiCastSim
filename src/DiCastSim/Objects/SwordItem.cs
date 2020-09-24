namespace DiCastSim.Objects
{
    internal class SwordItem : BaseItem
    {
        public override string Do()
        {
            game.Opponent.AddLife(-game.Player.Atack);
            return $"{game.Player.Name} atack";
        }

        public SwordItem()
        {
            Img = Properties.Resources.swords;
        }
    }
}
