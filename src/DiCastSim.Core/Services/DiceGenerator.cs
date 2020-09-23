using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;

namespace DiCastSim.Core.Services
{
    public class DiceGenerator
    {
        readonly Randomizer rand;        
        Dice NumberedDice => (Dice)rand.Get(0, 10);

        public DiceGenerator()
        {
            rand = IOC.Resolve<Randomizer>();
        }

        public Dice Get(Player player, bool forceNumbers = false)
        {
            if (forceNumbers) return NumberedDice;

            // Out of Special Dices
            if (player.SpecialDices.Count == 0)
                return NumberedDice;

            // A third possibility to get a special dice
            return rand.Get(0, 3) == 0 ?
                player.SpecialDices.Dequeue() : NumberedDice;
        }

        public int? EvaluateDice(Dice Tipo)
        {
            switch (Tipo)
            {
                case Dice.One:
                    return 1;
                case Dice.Two:
                    return 2;
                case Dice.Three:
                    return 3;
                case Dice.Four:
                    return 4;
                case Dice.Five:
                    return 5;
                case Dice.Six:
                    return 6;
                case Dice.MinusOne:
                    return -1;
                case Dice.MinusRandom:
                    return rand.Get(1, 6) * -1;
                case Dice.Even:
                    return new int[] { 2, 4, 6 }[rand.Get(0, 3)];
                case Dice.Odd:
                    return new int[] { 1, 3, 5 }[rand.Get(0, 3)];
                case Dice.Double:
                    return rand.Get(1, 6) * 2;
                case Dice.Random:
                    return rand.Get(1, 6);
                case Dice.High:
                    return new int[] { 4, 5, 6 }[rand.Get(0, 3)];
                case Dice.Low:
                    return new int[] { 1, 2, 3 }[rand.Get(0, 3)];
            }

            return null;
        }
    }
}