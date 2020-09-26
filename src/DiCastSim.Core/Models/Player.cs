using DiCastSim.Core.Base;
using DiCastSim.Core.Castles;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System;
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
        private CastleFabric CastleFabric { get; set; }
        public CastleTypes CastleType { get; set; } = CastleTypes.Atack;
        private IBaseCastle castle;
        private IBaseCastle Castle
        {
            get
            {
                if (castle == null) castle = CastleFabric.Build(CastleType);
                return castle;
            }
        }

        internal void LevelUp()
        {
            Atack += 1;
        }

        bool _Imprisioned { get; set; } = false;
        public bool Imprisioned
        {
            get => _Imprisioned;
            set
            {
                if (value)
                {
                    var key = Hand.First(x => x.Dice == Dice.Key);
                    value = key == null;
                    if (key != null) Hand.Remove(key);
                }
                _Imprisioned = value;
            }
        }

        public int ExitAttempts { get; set; } = 0;
        public int Level { get; set; } = 1;
        public string Name { get; set; }
        public int InitialPosition { get; set; }
        public int Turns { get; set; } = 0;
        public bool LockEven { get; set; }
        public bool LockOdd { get; set; }

        public PlayerSpecialDices SpecialDices = new PlayerSpecialDices();
        public readonly PlayerHand Hand;
        readonly Randomizer rand;

        public Player()
        {
            rand = IOC.Resolve<Randomizer>();
            CastleFabric = IOC.Resolve<CastleFabric>();
            Hand = new PlayerHand(this);
        }

        public static Player Build(string name, int init, CastleTypes castleType)
        {
            return new Player()
            {
                Name = name,
                CastleType = castleType,
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

        public void LandOnBase(Game game)
        {
            Castle.LandOnBase(game);
        }
    }
}
