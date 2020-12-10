using System;

namespace ForestSim.Utilities
{
    public static class Utils
    {
        private static readonly Random random = new Random();

        //Random number inclusive
        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}