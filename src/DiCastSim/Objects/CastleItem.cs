namespace DiCastSim.Objects
{
    internal class CastleItem : BaseItem
    {
        public override string Do()
        {
            if (game.Player == game.GetPlayer(Core.Game.Who.Player1))
                return Index == 0 ? $"{game.Player.Name} castle p1" :
                    $"{game.Player.Name} locked up";

            return Index == 12 ? $"{game.Player.Name} castle p1" :
                 $"{game.Player.Name} locked up";
        }

        public CastleItem()
        {
            Img = Properties.Resources.castle;
        }
    }
}
