namespace DiCastSim.Core.Objects
{
    public class AppleEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.Life += 8;
            return $"{game.Player.Name} eating an apple";
        }
    }
}