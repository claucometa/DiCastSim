namespace DiCastSim.Objects
{
    internal class CastleItem : BaseItem
    {
        public override string Do()
        {
            var home = game.PlayerTurn == Core.Game.Who.Player1 ? 0 : 12;

            if (Index == home)
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

        public CastleItem()
        {
            Img = Properties.Resources.castle;
        }
    }
}
