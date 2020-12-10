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

        virtual public void OnDay(object sender, EventArgs e) { }

        virtual public void OnPostDay(object sender, EventArgs e) { }

        virtual public void OnMonth(object sender, EventArgs e) { }

        virtual public void OnYear(object sender, EventArgs e) { }
    }
}