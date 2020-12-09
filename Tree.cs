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
    enum AgeCatagory
    {
        Young,
        Mature,
        Elderly,
        Unknown
    }
    class Tree
    {
        //TODO: Make abstract
        protected (int yearStart, AgeCatagory ageCatagory)[] _ageRanges; // Array of tuples :D
        protected int _age;
        public int Age_Days
        {
            get { return _age; }
            protected set
            {
                if (value >= 0) { _age = value; }
                else { _age = 0; } //TODO: Throw error
            }
        }
        public double Age_Years { get { return _age / (double)365; } }
        protected void Increment_Age(int days)
        {
            Age_Days += days;
        }
        protected void Increment_Age()
        {
            Increment_Age(1);
        }
        public AgeCatagory AgeCatagory {
            get
            {
                for (int i = _ageRanges.Length - 1; i >= 0; i--)
                {
                    if (_age >= _ageRanges[i].yearStart)
                    {
                        return _ageRanges[i].ageCatagory;
                    }
                }
                return AgeCatagory.Unknown;
            }
        }
        public Tree(int age_days)
        {
            Age_Days = age_days;
        }
    }
    class Fir : Tree, ICuttable
    {
        public Fir(int age_days) : base(age_days)
        {
            _ageRanges = new (int yearStart, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (25, AgeCatagory.Mature),
                (70, AgeCatagory.Elderly)
            };
        }
        public bool Cut()
        {
            return true;
        }
    }
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