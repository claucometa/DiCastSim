namespace DiCastSim.Core.Objects
{
    public class CoinEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.Coins += 12;

            return $"{game.Player.Name} got money";
        }
    }
}