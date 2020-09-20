using DiCastSim.Core;
using DiCastSim.Core.Models;

namespace DiCastSim.Objects
{
    internal class CastleItem : BaseItem
    {
        public Player Owner { get; set; }

        public override string Do()
        {
            if (game.Player == Owner)
                return $"{game.Player.Name} castle p1";
            else
                return $"{game.Player.Name} locked up";
        }

        public CastleItem()
        {
            Img = Properties.Resources.castle;
        }
    }
}
