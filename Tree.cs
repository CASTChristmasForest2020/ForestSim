using System;
using System.Collections.Generic;
using System.Text;

namespace ForestSim
{
    interface ICuttable
    {
        bool Cut();
    }
    interface ITapable
    {
        bool Tap();
    }
    class Tree
    {
        protected int _age;
        public int Age_Days
        {
            get { return _age; }
            protected set
            {
                if (value >= 0) { _age = value; }
                else { _age = 0; }
            }
        }
        public double Age_Years { get { return _age / (double)365; } }

        public Tree(int age_days) //TEMP! Should never create plain tree obj
        {
            Age_Days = age_days;
        }
    }
    //class Fir : Tree, ICuttable
    //{
    //    public bool Cut()
    //    {
    //        return true;
    //    }
    //}
    //class Spruce : Tree, ICuttable
    //{
    //    public bool Cut()
    //    {
    //        return true;
    //    }
    //}
    //class Maple : Tree, ICuttable, ITapable
    //{
    //    public bool Cut()
    //    {
    //        return true;
    //    }

    //    public bool Tap()
    //    {
    //        return true;
    //    }
    //}
}