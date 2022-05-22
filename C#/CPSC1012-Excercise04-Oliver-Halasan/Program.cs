using System;
// Oliver Halasan
//2021-02-25
//CPSC1012-Execrsise04
namespace CPSC1012_Excercise04_Oliver_Halasan
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            int minimum, maximum, value, range;
            double average;
            //input   
            do
            {
                Console.Write("Please Enter the Value: ");
                value = int.Parse(Console.ReadLine());
                if (value <= 0)
                {
                    Console.WriteLine("Please enter the right value");
                    return;
                }


                minimum = value;
                maximum = value;

            }

            while (value > 0);
            {

            }



            //output
            average = (minimum + maximum) / 2;

            Console.WriteLine("The Average is: {0}", average);

        }
    }
}
