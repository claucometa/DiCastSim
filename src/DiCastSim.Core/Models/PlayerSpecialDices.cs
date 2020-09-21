using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace DiCastSim.Core.Models
{
    public class PlayerSpecialDices : Queue<Dice>
    {
        readonly RandomContext rc = new RandomContext();

        public PlayerSpecialDices()
        {
            MountRandomSpecialDiceQueue();
        }

        private void MountRandomSpecialDiceQueue()
        {
            var specials = new List<Dice>
            {
                Dice.MinusRandom,
                Dice.MinusOne,
                Dice.Home,
                Dice.Home,
                Dice.Home,
                Dice.Stunt,
                Dice.Stunt,
                Dice.Shuffle,
                Dice.Shuffle,
            };

            do
            {
                var n = rc.Get(0, specials.Count);
                var x = specials.ElementAt(n);
                Enqueue(x);
                specials.RemoveAt(n);
            } while (specials.Count > 0);
        }
    }
}
