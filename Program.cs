using System;

namespace ForestSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree1 = new Tree(378);
            Tree tree2 = new Tree(-38);
            Console.WriteLine("{0}, {1}; {2}, {3};", tree1.Age_Days, tree1.Age_Years, tree2.Age_Days, tree2.Age_Years);
        }
    }
}
