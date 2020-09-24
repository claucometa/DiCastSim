namespace DiCastSim.Core.Objects
{
    public class BagEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} got a bag";
        }
    }
}