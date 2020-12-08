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
        protected bool _diseased;
    }
    class Fir : Tree, ICuttable
    {
        public bool Cut()
        {
            return true;
        }
    }
    class Spruce : Tree, ICuttable
    {
        public bool Cut()
        {
            return true;
        }
    }
    class Maple : Tree, ICuttable, ITapable
    {
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