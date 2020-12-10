using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestSim.Models;

namespace ForestSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Forest forest = new Forest(100, 100);
            List<Scheduler> schedulers = new List<Scheduler>();

            Forester[] foresters = new Forester[3];
            for (int i = 0; i < foresters.Length; i++) foresters[i] = new Forester();

            schedulers.Add(new LoggerScheduler(forest, foresters.ToList()));

            Simulator sim = new Simulator(schedulers);
            sim.Month += (object sender, EventArgs e) =>
            {
                forest.DisplayForest();
            };
            sim.EventLoop();
        }
    }
}
