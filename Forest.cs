using ForestSim.Utils;
using System;

namespace ForestSim
{
    public class Forest
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

        public void ReplantTree(int x, int y)
        {
            Tree newTree;
            int randNum = GeneralUtils.GetRandomNumber(1, 15);

            //Ratio of 5:8:2 maple:fir:spurce so 1/3 is maple and other is split 4:1

            switch (randNum)
            {
                case 1:
                    newTree = new Fir();
                    break;

                case int i when (1 <= i && i <= 5):
                    newTree = new Maple();
                    break;

                case int i when (6 <= i && i <= 15):
                    newTree = new Spruce();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            _trees[x, y] = newTree;
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