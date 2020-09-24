namespace DiCastSim.Objects
{
    class BagItemTwo : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} got a bag";
        }

        public BagItemTwo()
        {
            Img = Properties.Resources.bag;
        }
    }
}
