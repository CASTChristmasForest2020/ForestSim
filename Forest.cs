using System;
using System.Collections.Generic;
using System.Text;

namespace ForestSim
{
    class Forest
    {
        private Tree[,] _trees;
        public Forest(int ForestWidth, int ForestHeight)
        {
            _trees = CreateForestArray(ForestWidth, ForestHeight);
            DisplayForest(_trees);
        }

        private Tree[,] CreateForestArray(int width, int height)
        {
            Random rng = new Random();
            Tree[,] forest = new Tree[width, height];

            // Column
            for (int i = 0; i < forest.GetLength(1); i++)
            {
                // Row
                for (int j = 0; j < forest.GetLength(0); j++)
                {
                    forest[j, i] = DecideTree(rng);
                }

            }
            return forest;
        }

        // Decides which tree the index of an array will store
        // Ratio is 4:1 so getting random number out of 50
        private Tree DecideTree(Random rng)
        {
            Tree outputTree;
            int chosenNumber = rng.Next(50);
            if (chosenNumber <= 10)
            {
                outputTree = new Spruce();
                return outputTree;
            }
            else
            {
                outputTree = new Fir();
                return outputTree;
            }
        }

        private void DisplayForest(Tree[,] forest)
        {
            // Column
            for (int i = 0; i < forest.GetLength(1); i++)
            {
                // Row
                for (int j = 0; j < forest.GetLength(0); j++)
                {
                    // Checks tree type to output
                    if (forest[j, i].GetType() == typeof(Spruce))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("s", Console.ForegroundColor);
                    }
                    else if (forest[j, i].GetType() == typeof(Fir))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("f", Console.ForegroundColor);
                    }
                }
            }
        }
    }
}
