/*
CPSC1012_Exercise02
Oliver Halasan
*/
using System;

namespace CPSC1012_Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare virable
            double Area, Radius, Cirumference, Pi;
            const double PI = 3.14;

            // input
            Console.WriteLine("Please eneter the Radius: ");
            Radius = double.Parse(Console.ReadLine());

            Pi = 3.14;

            //Solution
            Cirumference = 2 * PI * (Radius);
            Area = Pi * Radius * Radius;

            // Result
            Console.WriteLine("The Cirumference is {0:0.00} ", Cirumference);
            Console.WriteLine("The Area is {0:0.00} ", Area);



        }
    }
}
