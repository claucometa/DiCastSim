namespace DiCastSim.Objects
{
    class BagItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} got a bag";
        }

        public BagItem()
        {
            Img = Properties.Resources.bag;
        }
    }
}
