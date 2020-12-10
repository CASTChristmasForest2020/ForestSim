using ForestSim.Interfaces;
using System;

namespace ForestSim
{
    public interface ICuttable
    {
        bool IsCuttable();
    }

    public interface ITapable
    {
        bool Tap();
    }

    public enum AgeCatagory
    {
        Young,
        Mature,
        Elderly,
        Unknown
    }

    public class Tile
    {
    }

    public abstract class Tree : Tile
    {
        //TODO: Make abstract
        public Tree(int age_days)
        {
            Random r = new Random();

            Age_Days = age_days;

            if (r.Next(0, 51) == 0) { Has_Dove = true; }
            else { Has_Dove = false; }
        }

        //AGE:
        protected int _age;

        protected bool _diseased;
        protected (int minAge, AgeCatagory ageCatagory)[] _ageRanges; // Array of tuples :D

        public int Age_Days
        {
            get { return _age; }
            protected set
            {
                if (value >= 0) { _age = value; }
                else
                {
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

        public AgeCatagory AgeCatagory
        {
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

        //DOVES
        public bool Has_Dove
        {
            get;
            protected set;
        }
    }

    public class Fir : Tree, ICuttable, ITruckable
    {
        public Fir(int age_days = 0) : base(age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (25, AgeCatagory.Mature),
                (70, AgeCatagory.Elderly)
            };
        }

        public int maxTruckCapacity => 35;

        public bool IsCuttable()
        {
            if (_diseased) { return true; }
            if (this.AgeCatagory != AgeCatagory.Mature) { return false; }
            if (Has_Dove) { return false; }

            return true;
        }
    }

    public class Spruce : Tree, ICuttable, ITruckable
    {
        public Spruce(int age_days = 0) : base(age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (90, AgeCatagory.Mature),
                (150, AgeCatagory.Elderly)
            };
        }

        public int maxTruckCapacity => 15;

        public bool IsCuttable()
        {
            if (_diseased) { return true; }
            if (this.AgeCatagory != AgeCatagory.Mature) { return false; }
            if (Has_Dove) { return false; }

            return true;
        }
    }

    public class Maple : Tree, ICuttable, ITapable
    {
        public Maple(int age_days = 0) : base(age_days)
        {
            _ageRanges = new (int minAge, AgeCatagory ageCatagory)[] {
                (0, AgeCatagory.Young),
                (4, AgeCatagory.Mature) //Tapable at mature, instead of cuttable
            };
        }

        public bool IsCuttable()
        {
            return _diseased;
        }

        public bool Tap()
        {
            return true;
        }
    }
}