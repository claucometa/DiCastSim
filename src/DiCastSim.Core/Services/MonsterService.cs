using System;
using System.Collections.Generic;
using System.Linq;

namespace DiCastSim.Core.Services
{
    public class MonsterService
    {
        List<int> monsterNumbers = new List<int>();

        public int Coins { get; internal set; }
        public int Atack { get; internal set; }

        public bool AtackMonster(int v)
        {
            return monsterNumbers.Contains(v);
        }

        public int[] GetMonterDices(int total)
        {
            if (total == 1)
            {
                Coins = 20;
                Atack = 15;
            }
            else if (total < 3)
            {
                Coins = 10;
                Atack = 7;
            }
            else
            {
                Coins = 5;
                Atack = 3;
            }

            Random r = new Random();

            var allNumbers = new List<int>();
            monsterNumbers = new List<int>();

            for (int i = 1; i <= 6; i++)
                allNumbers.Add(i);

            for (int i = 0; i < total; i++)
            {
                var n = r.Next(allNumbers.Count);
                monsterNumbers.Add(allNumbers[n]);
                allNumbers.RemoveAt(n);
            }

            return monsterNumbers.OrderBy(t => t).ToArray();
        }
    }
}
