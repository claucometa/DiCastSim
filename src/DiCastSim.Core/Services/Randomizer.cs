using System;

namespace DiCastSim.Core.Services
{
    public class Randomizer
    {
        private readonly Random r = new Random();

        public int Get(int start, int end)
        {
            return r.Next(start, end);
        }
    }
}