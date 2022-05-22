using System;

namespace CPSC1012_Execrise03_Oliver_Halasan
{
    class Program
    {
        static void Main(string[] args)
        {

            //variables
            double inches = 0, cm = 0, yards = 0, meter = 0, km = 0, miles = 0;
            char unitIn;

            // input
            Console.Write("\nA.\tCentimeters to inches");
            Console.Write("\nB.\tYards to Meters");
            Console.Write("\nC.\t Miles to Kilometers\n\n");

            Console.Write("Please choose your solution: ");
            unitIn = char.Parse(Console.ReadLine());

            
         

           


            //output and solution
            switch (unitIn)
            {
                case 'A':
                case 'a':
                    cm = inches / 0.39370;
                    Console.WriteLine("\nThe Convertion of Inches {0:0.00} is {1:0.00}Centimeters.", inches,cm );
                    break;

                case 'B':
                case 'b':
                    meter = yards / 1.0936;
                    Console.WriteLine("\nThe Convertion of Yards {0:0.00} is {1:0.00} Meter.", yards, meter);
                    break;

                case 'C':
                case 'c':
                    km = miles / 0.62137;
                    Console.WriteLine("\nThe Convertion of Miles {0:0.00} is {1:0.00} Kilometer.", miles ,km );
                    break;

                default:
                    Console.WriteLine("invalid Entry");
                    break;


            }

        }

    }
}