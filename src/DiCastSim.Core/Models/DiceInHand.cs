using DiCastSim.Core.Enums;

namespace DiCastSim.Core.Models
{
    public class DiceInHand
    {
        public Dice Dice { get; set; }
        public bool Enabled { get; set; } = false;
        public int Index { get; set; }
        public bool IsNumber { get => (int)Dice < 14; }

        public DiceInHand(int index, Dice dice)
        {
            Index = index;
            Dice = dice;
        }
    }
}
