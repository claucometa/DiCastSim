namespace DiCastSim.Core.Objects
{
    public class NothingEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} doing nothing";
        }
    }
}