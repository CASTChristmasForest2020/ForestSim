using ForestSim.Interfaces;
using ForestSim.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ForestSim
{
    internal class LoggerScheduler : Scheduler
    {
        private readonly List<Forester> foresters;
        private readonly Queue<ICuttable> loggingQueue = new Queue<ICuttable>();
        private readonly Queue<(int x, int y)> replantQueue = new Queue<(int x, int y)>();
        private Dictionary<Type, int> overflowTruckItems = new Dictionary<Type, int>();
        private int trucks;

        public LoggerScheduler(Forest forest, List<Forester> foresters) : base(forest)
        {
            if (foresters == null)
                throw new ArgumentNullException(nameof(foresters));

            this.foresters = foresters;
        }

        public override void OnDay(object sender, EventArgs e)
        {
            foreach (var forester in foresters)
            {
                forester.CutDaysTree(forest, loggingQueue, replantQueue);
            }
        }

        public override void OnPostDay(object sender, EventArgs e)
        {
            // Used to track items in last trucks
            while (loggingQueue.Count > 0)
            {
                ICuttable item = loggingQueue.Dequeue();
                if (item is ITruckable t)
                {
                    Type tType = t.GetType();

                    int overflowCount;
                    if (overflowTruckItems.TryGetValue(tType, out overflowCount))
                    {
                        // If overflow limit add new truck and wrap round to overflow of 1
                        if (overflowCount + 1 > t.maxTruckCapacity)
                        {
                            trucks++;
                            overflowTruckItems[tType] = 1;
                        }
                        else
                        {
                            // Fill current truck
                            overflowTruckItems[tType]++;
                        }
                    }
                    else
                    {
                        // Create new truck if no truck of type already
                        overflowTruckItems[tType] = 1;
                    }
                }
            }

            while (replantQueue.Count > 0)
            {
                forest.ReplantTree(replantQueue.Dequeue());
            }
        }

        public override void OnMonth(object sender, EventArgs e)
        {
            //Adds a additional truck for each type as they will at minimum have 1 item which requires a truck
            trucks += overflowTruckItems.Count;

            overflowTruckItems.Clear();
        }

        public override void OnYear(object sender, EventArgs e)
        {
            foreach (var forester in foresters)
            {
                forester.ResetDaysWorked();
            }
        }
    }
}