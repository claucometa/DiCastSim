namespace DiCastSim.Objects
{
    class SpikeOneItem : BaseItem
    {
        public override string Do()
        {
            game.Player.AddLife(-3);

            return $"{game.Player.Name} trap I";
        }

        public SpikeOneItem()
        {
            Img = Properties.Resources.trap1;
        }
    }
}
