namespace DiCastSim.Core.Objects
{
    public class BagTwoEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} got a bag II";
        }
    }
}