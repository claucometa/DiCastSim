namespace DiCastSim.Core.Objects
{
    public class SwordEffect : ItemEffect
    {
        public override string Do()
        {
            game.Opponent.AddLife(-game.Player.Atack);
            return $"{game.Player.Name} atack";
        }
    }
}