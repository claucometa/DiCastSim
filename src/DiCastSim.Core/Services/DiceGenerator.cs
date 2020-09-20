using Autofac;
using DiCastSim.Core.Enums;
using System;

namespace DiCastSim.Core.Services
{
    public class DiceGenerator
    {
        readonly RandomContext rc;

        public DiceGenerator()
        {
            rc = IOC.Resolve<RandomContext>();
        }

        public Dice Get(bool forceNumbers = false)
        {
            return forceNumbers ?
                (Dice)rc.Get(0, 11)
            : (Dice)rc.Get(0, Enum.GetValues(typeof(Dice)).Length);
        }

        public int? Get(Dice Tipo)
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
                case Dice.NegativeOne:
                    return -1;
                case Dice.NegativeRandom:
                    return rc.Get(1, 6) * -1;
                case Dice.Even:
                    return new int[] { 2, 4, 6 }[rc.Get(0, 3)];
                case Dice.Odd:
                    return new int[] { 1, 3, 5 }[rc.Get(0, 3)];
                case Dice.Double:
                    return rc.Get(1, 6) * 2;
                case Dice.Random:
                    return rc.Get(1, 6);
            }

            return null;
        }
    }
}