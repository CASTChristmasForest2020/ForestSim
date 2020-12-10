using System;
using System.Collections.Generic;
using System.Text;

namespace ForestSim
{
    class Forest
    {
        private Tile[,] _forest;
        public Forest(int ForestWidth, int ForestHeight)
        {
            _forest = CreateForestArray(ForestWidth, ForestHeight);
            DisplayForest(_forest);
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

        private void DisplayForest(Tile[,] forest)
        {
            Char ASCIIChar;
            // Column
            for (int i = 0; i < forest.GetLength(1); i++)
            {
                // Row
                for (int j = 0; j < forest.GetLength(0); j++)
                {
                    // Splits by tile type
                    if (forest[j, i] is Tree tree)
                    {
                        // Checks tree attributes to output. Att.'s sooner in the foreground & background sections take precident.
                        
                        //FOREGROUND
                        if (tree.Has_Dove)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        //BACKGROUND
                        if (tree.GetType() == typeof(Spruce))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            ASCIIChar = 's';
                        }
                        else if (tree.GetType() == typeof(Fir))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            ASCIIChar = 'f';
                        }
                        else if (tree.GetType() == typeof(Maple))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            ASCIIChar = 'm';
                        }
                        else
                        {
                            ASCIIChar = ' ';
                        }
                    }
                    else
                    {
                        ASCIIChar = ' ';
                    }
                    
                    Console.Write(ASCIIChar);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        void MapToTrees(Action<Tree> action)
        {
            foreach (Tile tile in _forest)
            {
                if (tile is Tree tree)
                {
                    action(tree);
                }
            }
        }
        /* USAGE:
         * 
         * MapToTrees((Tree tree) => lambda function)
         * 
         * Eg. Single expression:
         * MapToTrees((Tree tree) => tree.var += 6)
         * 
         * Adds 6 to each tree's .var attribute
         * 
         * Eg. Block of code
         * MapToTrees((Tree tree) =>
         * {
         *      If (tree.var1 = true)
         *      {
         *          tree.var2 = "yes";
         *      }
         *      tree.var3 = 6;
         * });
         * 
         * 
         * You can also define an 'action' function elsewhere and pass it in
         */
    }
}
