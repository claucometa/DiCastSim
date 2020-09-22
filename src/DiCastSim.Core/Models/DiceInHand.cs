using DiCastSim.Core.Enums;

namespace DiCastSim.Core.Models
{
    public class DiceInHand
    {
        public Dice Dice { get; set; }
        public int Index { get; set; }

        public DiceInHand(int index, Dice dice)
        {
            Index = index;
            Dice = dice;
        }
    }
}
