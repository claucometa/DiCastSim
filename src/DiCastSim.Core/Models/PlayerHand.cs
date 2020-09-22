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

        public enum DiceType
        {
            NumberOnly,
            Any,
        }

        public Dice? AddNextDice(DiceType type)
        {
            var dice = type == DiceType.NumberOnly ?
                AddNumbericDice() : AddAnyDice();

            if (dice.HasValue) Add(dice.Value);

            return dice;
        }

        private Dice? AddNumbericDice()
        {
            if (Count == 5) return null;
            return dc.Get(player, true);
        }

        private Dice? AddAnyDice()
        {
            if (Count == 5) return null; 

            // There is some number
            if (this.Any(t => t >= Dice.One && t <= Dice.High))
                return dc.Get(player);

            // There is some number
            if (this.Any(t => t == Dice.MinusOne || t == Dice.MinusRandom))
                return dc.Get(player);

            // There is no number, so force next dice to be a number
            return dc.Get(player, true);
        }
    }
}
