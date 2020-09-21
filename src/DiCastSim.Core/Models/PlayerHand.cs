using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace DiCastSim.Core.Models
{
    public class PlayerHand : List<Dice>
    {
        readonly DiceGenerator dc;
        readonly Player player;

        public PlayerHand(Player player)
        {
            this.player = player;
            dc = IOC.Resolve<DiceGenerator>();
            Add(dc.Get(player));
            Add(dc.Get(player));
        }

        public void GetNumberDice()
        {
            if (Count == 5) return;
            Add(dc.Get(player, true));
        }

        public void GetNextDice()
        {
            if (Count == 5) return;

            // There is some number
            if (this.Any(t => t >= Dice.One && t <= Dice.High))
            {
                Add(dc.Get(player));
                return;
            }

            // There is some number
            if (this.Any(t => t == Dice.MinusOne || t == Dice.MinusRandom))
            {
                Add(dc.Get(player));
                return;
            }

            // There is no number, so force next dice to be a number
            Add(dc.Get(player, true));
        }
    }
}
