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
    class Tile
    {

    }
    class Tree : Tile
    {
        //TODO: Make abstract
        public Tree(int age_days)
        {
            Random r = new Random();

            Age_Days = age_days;
            
            if (r.Next(0, 51) == 0) { Has_Dove = true; }
            else { Has_Dove = false; }
        }

        public void Daily()
        {
            Increment_Age(_ageQuickly ? 3 : 1);
        }

        //AGE:
        protected int _age;
        protected (int minAge, AgeCatagory ageCatagory)[] _ageRanges; // Array of tuples :D

        public int Age_Days
        {
            get { return _age; }
            protected set
            {
                if (value >= 0) { _age = value; }
                else {
                    throw new ArgumentOutOfRangeException("Age_Days", String.Format("{0} is a negative age.", value));
                }
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
                    if (_age >= _ageRanges[i].minAge)
                    {
                        return _ageRanges[i].ageCatagory;
                    }
                }
                return AgeCatagory.Unknown;
            }
        }
        protected bool _ageQuickly;

        //DOVES
        public bool Has_Dove
        {
            get;
            protected set;
        }
    }
    class Fir : Tree, ICuttable
    {
        public Fir (int age_days = 0) : base (age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
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
    class Spruce : Tree, ICuttable
    {
        public Spruce(int age_days = 0) : base (age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (90, AgeCatagory.Mature),
                (150, AgeCatagory.Elderly)
            };
        }
        public bool Cut()
        {
            return true;
        }
    }
    class Maple : Tree, ICuttable, ITapable
    {
        public Maple(int age_days = 0) : base(age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (4, AgeCatagory.Mature) //Tapable at mature, instead of cuttable
            };
        }
        public bool Cut()
        {
            return true;
        }

        public bool Tap()
        {
            return true;
        }
    }
}
