namespace DiCastSim.Objects
{
    class SpikeTwoItem : BaseItem
    {
        public override string Do()
        {
            game.Player.AddLife(-6);

            return $"{game.Player.Name} trap II";
        }

        public SpikeTwoItem()
        {
            Img = Properties.Resources.trap2;
        }
    }
}
