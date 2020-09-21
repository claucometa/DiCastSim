using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace DiCastSim.Core.Models
{
    public class PlayerHand
    {
        public List<Dice> x = new List<Dice>();
        readonly DiceGenerator dc;
        readonly Player player;

        public PlayerHand(Player player)
        {
            this.player = player;
            dc = IOC.Resolve<DiceGenerator>();
            x.Add(dc.Get(player));
            x.Add(dc.Get(player));
        }

        public void GetNumberDice()
        {
            if (x.Count == 5) return;
            x.Add(dc.Get(player, true));
        }

        public void GetNextDice()
        {
            if (x.Count == 5) return;

            // There is some number
            if (x.Any(t => t >= Dice.One && t <= Dice.High))
            {
                x.Add(dc.Get(player));
                return;
            }

            // There is some number
            if (x.Any(t => t == Dice.MinusOne || t == Dice.MinusRandom))
            {
                x.Add(dc.Get(player));
                return;
            }

            // There is no number, so force next dice to be a number
            x.Add(dc.Get(player, true));
        }

        public Dice Last() => x.Last();
    }
}
