using ForestSim.Models;
using System;
using System.Collections.Generic;

namespace ForestSim
{
    internal class LoggerScheduler : Scheduler
    {
        private readonly List<Forester> foresters;
        private readonly Queue<Tree> loggingQueue = new Queue<Tree>();
        private readonly Queue<(int x, int y)> replantQueue = new Queue<(int x, int y)>();

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
                forester.CutTree(loggingQueue, replantQueue);
            }
        }

        public override void OnPostDay(object sender, EventArgs e)
        {
            while (loggingQueue.Count > 0)
            {

            }

            while (replantQueue.Co)
        }

        public override void OnMonth(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnYear(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}