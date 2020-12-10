using ForestSim.Utilities;
using System;

namespace ForestSim
{
    public class Forest
    {
        private Tile[,] _forest;

        public readonly int ForestWidth;
        public readonly int ForestHeight;

        public Forest(int ForestWidth, int ForestHeight)
        {
            this.ForestWidth = ForestWidth;
            this.ForestHeight = ForestHeight;
            _forest = CreateForestArray(ForestWidth, ForestHeight);
            DisplayForest();
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
                outputTree = new Spruce(90);
                return outputTree;
            }
            else
            {
                outputTree = new Fir(30);
                return outputTree;
            }
        }

        public void DisplayForest()
        {
            Console.SetCursorPosition(0, 0);
            Char ASCIIChar;
            // Column
            for (int i = 0; i < _forest.GetLength(1); i++)
            {
                // Row
                for (int j = 0; j < _forest.GetLength(0); j++)
                {
                    // Splits by tile type
                    if (_forest[j, i] is Tree tree)
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

        public void ReplantTree((int x, int y) coord)
        {
            ReplantTree(coord.x, coord.y);
        }

        public void ReplantTree(int x, int y)
        {
            if (_forest[x, y] is Tree)
            {
                int randNum = Utils.GetRandomNumber(1, 15);
                Tree newTree = randNum switch
                {
                    int i when (1 <= i && i <= 2) => new Spruce(),
                    int i when (3 <= i && i <= 6) => new Maple(),
                    int i when (7 <= i && i <= 15) => new Fir(),
                    _ => throw new InvalidOperationException(),
                };
                _forest[x, y] = newTree;
            }
        }

        private void MapToTrees(Action<Tree> action)
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

        public Tile GetTile(int x, int y)
        {
            return _forest[x, y];
        }
    }
}