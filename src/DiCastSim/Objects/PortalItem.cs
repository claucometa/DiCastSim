namespace DiCastSim.Objects
{
    internal class PortalItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} TP";
        }

        public PortalItem()
        {
            Img = Properties.Resources.portal;
        }
    }
}
