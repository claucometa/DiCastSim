namespace DiCastSim.Core.Objects
{
    public class PortalEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.Position += 12;

            return $"{game.Player.Name} TP";
        }
    }
}