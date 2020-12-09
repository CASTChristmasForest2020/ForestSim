using System;

namespace ForestSim
{
    public abstract class Scheduler
    {
        protected Forest forest;
        public Scheduler(Forest forest)
        {
            this.forest = forest;
        }

        abstract public void OnDay(object sender, EventArgs e);

        abstract public void OnPostDay(object sender, EventArgs e);

        abstract public void OnMonth(object sender, EventArgs e);

        abstract public void OnYear(object sender, EventArgs e);
    }
}