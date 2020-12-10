using ForestSim.Utilities;
using System.Collections.Generic;

namespace ForestSim.Models
{
    public class Forester
    {
        public void CutTree(Forest forest, Queue<ICuttable> loggingQueue, Queue<(int x, int y)> replantQueue)
        {
            while (true)
            {
                int x = Utils.GetRandomNumber(0, forest.ForestWidth - 1);
                int y = Utils.GetRandomNumber(0, forest.ForestHeight - 1);
                Tile tile = forest.GetTile(x, y);

                if (tile is ICuttable t && t.IsCuttable())
                {
                    loggingQueue.Enqueue(t);
                    replantQueue.Enqueue((x, y));
                    break;
                }
            }
        }
    }
}