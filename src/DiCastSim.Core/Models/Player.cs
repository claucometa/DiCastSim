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

        public Player()
        {
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
            Life += v;
        }

        public void GoHome()
        {
            Position = InitialPosition;
        }
    }
}
