namespace DiCastSim.Core.Objects
{
    public class BreadEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.Life += 6;

            return $"{game.Player.Name} eating a bread";
        }
    }
}