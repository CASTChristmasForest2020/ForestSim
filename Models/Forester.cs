using System.Collections.Generic;

namespace ForestSim.Models
{
    public class Forester
    {
        private int DaysWorked = 0;

        public void ResetDaysWorked()
        {
            DaysWorked = 0;
        }

        public void CutDaysTree(Forest forest, Queue<ICuttable> loggingQueue, Queue<(int x, int y)> replantQueue)
        {
            DaysWorked++;

            if (DaysWorked> 30) { return; }

            int firsCut = 0;
            int sprucesCut = 0;

            for (int x = 0; x < forest.ForestWidth; x++)
            {
                for (int y = 0; y < forest.ForestHeight; y++)
                {
                    Tile tile = forest.GetTile(x, y);
                    if (tile is ICuttable t && t.IsCuttable())
                    {
                        switch (t)
                        {
                            case Spruce _:
                                // Don't cut any more if spruce at limit. Moves to next tree
                                if (sprucesCut >= 4) { continue; }

                                sprucesCut++;
                                break;

                            case Fir _:
                                // Don't cut any more if fir at limit
                                if (firsCut >= 10) { continue; }

                                firsCut++;
                                break;
                        }

                        loggingQueue.Enqueue(t);
                        replantQueue.Enqueue((x, y));
                    }
                }
            }
        }
    }
}