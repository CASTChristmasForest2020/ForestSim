using System;

namespace ForestSim.Utils
{
    public static class GeneralUtils
    {
        private static readonly Random random = new Random();

        //Random number inclusive
        public static int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}