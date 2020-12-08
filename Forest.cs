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
            _trees = new Tree[ForestWidth, ForestHeight];
        }
    }
}
