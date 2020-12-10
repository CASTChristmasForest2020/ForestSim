using System;
using System.Collections.Generic;

namespace ForestSim
{
    internal class Simulator
    {
        public event EventHandler Day;

        public event EventHandler PostDay;

        public event EventHandler Month;

        public event EventHandler Year;

        private List<Scheduler> schedulers;
        private DateTime currentDate;

        public Simulator() : this(new List<Scheduler>())
        {
        }

        public Simulator(List<Scheduler> Schedulers)
        {
            if (Schedulers == null)
                throw new ArgumentNullException(nameof(Schedulers));

            currentDate = new DateTime(1970, 1, 1);
            foreach (var schedular in Schedulers)
            {
                Day += schedular.OnDay;
                PostDay += schedular.OnPostDay;
                Month += schedular.OnMonth;
                Year += schedular.OnYear;
            }
        }

        public void EventLoop()
        {
            while (true)
            {
                DateTime oldDate = currentDate;
                currentDate = currentDate.AddDays(1);

                if (oldDate.Month != currentDate.Month)
                {
                    Month(this, EventArgs.Empty);
                }

                if (oldDate.Year != currentDate.Year)
                {
                    Year(this, EventArgs.Empty);
                }

                Day(this, EventArgs.Empty);
                PostDay(this, EventArgs.Empty);
            }
        }
    }
}