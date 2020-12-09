using System;

namespace ForestSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Fir fir1 = new Fir(0);
            Fir fir2 = new Fir(35);
            Fir fir3 = new Fir(75);
            Console.WriteLine("{0}, {1}; {2}, {3}; {4}, {5};", fir1.Age_Days, fir1.AgeCatagory, fir2.Age_Days, fir2.AgeCatagory, fir3.Age_Days, fir3.AgeCatagory);
        }
    }
}
