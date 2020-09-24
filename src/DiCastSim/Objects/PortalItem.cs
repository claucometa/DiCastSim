namespace DiCastSim.Objects
{
    internal class PortalItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Position += 12;

            return $"{game.Player.Name} TP";
        }

        public PortalItem()
        {
            Img = Properties.Resources.portal;
        }
    }
}
