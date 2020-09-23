namespace DiCastSim.Objects
{
    class SpikeOneItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} trap I";
        }

        public SpikeOneItem()
        {
            Img = Properties.Resources.trap1;
        }
    }
}
