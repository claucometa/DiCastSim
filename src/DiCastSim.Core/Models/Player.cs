using DiCastSim.Core.Services;
using System.Linq;

namespace DiCastSim.Core.Models
{
    public class Player
    {
        public int Coins { get; set; }
        public int Life { get; set; }
        public int Atack { get; set; }
        public int LastPosition { get; set; } = -1;
        public int Position { get; set; } = 0;
        public bool Imprisioned { get; set; } = false;
        public int ExitAttempts { get; set; } = 0;
        public int Level { get; set; } = 1;
        public string Name { get; set; }
        public int InitialPosition { get; set; }
        public int Turns { get; set; } = 0;
        public PlayerSpecialDices SpecialDices = new PlayerSpecialDices();
        public readonly PlayerHand Hand;
        Randomizer rand;

        public Player()
        {
            rand = IOC.Resolve<Randomizer>();
            Hand = new PlayerHand(this);
        }

        public static Player Build(string name, int init)
        {
            return new Player()
            {
                Name = name,
                Coins = 20,
                Life = 44,
                Atack = 15,
                LastPosition = -1,
                Position = init,
                InitialPosition = init,
            };
        }

        public void Stun()
        {
            Turns += 2;
        }

        public void AddLife(int v)
        {
            if (v < 0)
            {
                if (Hand.Any(t => t.Dice == Enums.Dice.Shield))
                {
                    v = 0;
                }
                else if (Hand.Any(t => t.Dice == Enums.Dice.GoldenShield))
                {
                    var rest = (int)(Coins / v);
                    Coins += v * 5;
                    v += rest;
                }
                else if (Hand.Any(t => t.Dice == Enums.Dice.BrokenShield))
                {
                    if (rand.Get(0, 2) == 0) v = 0;
                }
            }

            Life += v;
        }

        public void GoHome()
        {
            Position = InitialPosition;
        }
    }
}
