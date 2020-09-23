namespace DiCastSim.Objects
{
    internal class SwordItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} atack";
        }

        public SwordItem()
        {
            Img = Properties.Resources.swords;
        }
    }
}
