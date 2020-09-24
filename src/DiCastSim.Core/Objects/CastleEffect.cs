namespace DiCastSim.Core.Objects
{
    public class CastleEffect : ItemEffect
    {
        public override string Do()
        {
            var home = game.PlayerTurn == Game.Who.Player1 ? 0 : 12;

            if (game.Player.Position % 24 == home)
            {
                game.Player.Atack += 1;
                game.Player.Coins += 12;
                // TODO add special card
                // TODO Add base effect
                return $"{game.Player.Name} castle p1";
            }
            else
            {
                game.Player.Imprisioned = true;
                game.Opponent.Turns++;
                return $"{game.Player.Name} locked up";
            }
        }
    }
}