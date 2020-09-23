namespace DiCastSim.Objects
{
    internal class NothingItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} doing nothing";
        }

        public NothingItem()
        {
        }
    }
}
