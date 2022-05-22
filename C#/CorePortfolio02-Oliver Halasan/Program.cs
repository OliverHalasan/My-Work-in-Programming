//John Oliver Halasan
//CPSC1012 Core Porfolio 2
//March 7 2021


using System;

namespace CorePortfolio02_Oliver_Halasan
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu, sideUp = 0, toss = 0;
            Random rand = new Random();
            do
            {
                Console.WriteLine("\n1. Run Coin Toss Simulator\n2. Run Slot Machine Simulator\n3. Quit Program\n\n");


                menu = GetSafeInt("Please select a Simulator: ");

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("\n\n**********Coin Toss Simulator**********\n");
                        CoinToss(rand, sideUp, toss);
                        break;
                    case 2:
                        Console.WriteLine("\n\n***********Slot Machine Simulator************\n");
                        SlotMachine(rand);
                        break;
                    case 3:
                        Console.WriteLine("Good Bye! Thank You For Playing");
                        break;
                    default:
                        Console.WriteLine("invalid Selection");
                        break;
                } 
            } while (menu != 3);


        }

        // result for every image
        static bool slot1(Random rand, int image1)
        {
            
            if (image1 == 1 )
            {
                Console.WriteLine("Cherries");
            }

            if (image1 == 2 )
            {
                Console.WriteLine("Oranges");
            }

            if (image1 == 3)
            {
                Console.WriteLine("Plums");

            }

            if (image1 == 4)
            {
                Console.WriteLine("Bells");

            }

            if (image1 == 5)
            {
                Console.WriteLine("Melons");

            }

            if (image1 == 6)
            {
                Console.WriteLine("Bars");

            }




            return true;
        }
        static bool slot2(Random rand, int image2)
        {
           
            if (image2 == 1)
            {
                Console.WriteLine("Cherries");
            }

            if (image2 == 2)
            {
                Console.WriteLine("Oranges");
            }

            if (image2 == 3)
            {
                Console.WriteLine("Plums");

            }

            if (image2 == 4)
            {
                Console.WriteLine("Bells");

            }

            if (image2 == 5)
            {
                Console.WriteLine("Melons");

            }

            if (image2 == 6)
            {
                Console.WriteLine("Bars");

            }




            return true;
        }

        static bool slot3(Random rand, int image3)
        {
            
            if (image3 == 1)
            {
                Console.WriteLine("Cherries");
            }

            if (image3 == 2)
            {
                Console.WriteLine("Oranges");
            }

            if (image3 == 3)
            {
                Console.WriteLine("Plums");

            }

            if (image3 == 4)
            {
                Console.WriteLine("Bells");

            }

            if (image3 == 5)
            {
                Console.WriteLine("Melons");

            }

            if (image3 == 6)
            {
                Console.WriteLine("Bars");

            }




            return true;
        }

        //Slot machince
        static bool SlotMachine(Random rand)
        {
            double deposit, reward, youlose;
            int  image1, image2, image3;
            char play;


            do
            {
                Console.WriteLine("This Program simulates a slot machine.\n");
                deposit = GetSafeDouble("Enter the amount to deposit into the slot machine: ");
                image1 = rand.Next(1, 7);
                image2 = rand.Next(1, 7);
                image3 = rand.Next(1, 7);
                slot1(rand, image1);
                slot2(rand, image2);
                slot3(rand, image3);

                if (image1 == image2 && image2 == image3)
                {
                    deposit = deposit * 3;
                    reward = deposit * 3;
                    Console.WriteLine("You won ${0}", reward);

                }
                else
                    if (image1 == image2)
                {
                    deposit = deposit + deposit;
                    reward = deposit + deposit;
                    Console.WriteLine("You won ${0}", reward);

                }
                else
                    if (image1 == image3)
                {
                    deposit = deposit + deposit;
                    reward = deposit + deposit;
                    Console.WriteLine("You won ${0}", reward);

                }
                else
                    if (image2 == image3)
                {
                    deposit = deposit + deposit;
                    reward = deposit + deposit;
                    Console.WriteLine("You Won! ${0}", reward);

                }
                else
                {
                   deposit = deposit - deposit;
                    Console.WriteLine("You Lose!");

                }

                Console.WriteLine("Total amount won: ${0}",deposit);

                play = GetSafechar("Do you want to play again (y/n): ");

            }
            while (play != 'n');
            return true;
        }
        // coin toss
        static bool CoinToss(Random rand, int sideUp,int toss)
        {
            int index = 0, heads = 0, tails = 0;
            
            
                Console.WriteLine("This program simulates tossing a coing multiple times.\n");
                toss = GetSafeInt("How many tosses: ");

                for (index = 0; index < toss; index++)
                {
                sideUp = rand.Next(1, 3);
                if (sideUp == 1)
                    {
                        Console.WriteLine("\nToss #{0}: Heads",index);
                    ++heads;
                    }
                    else
                    if (sideUp == 2)
                    {
                        Console.WriteLine("\nToss #{0}: Tails", index);
                    ++tails;
                    
                    }
                }while (index < toss);
            Console.WriteLine("\nNumber of Heads: {0}",heads);
            Console.WriteLine("Number of Tails: {0}", tails);

            return true;
        }

        //get safe int
        static int GetSafeInt(string promt)
        {
            int number = 0;
            bool isValid = false;

            do
            {
                try
                {
                    Console.Write(promt);
                    number = int.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            }
            while (isValid == false);

            return number;
        }
        // get safe double
        static double GetSafeDouble(string promt)
        {
            double number = 0;
            bool isValid = false;

            do
            {
                try
                {
                    Console.Write(promt);
                    number = double.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            }
            while (isValid == false);

            return number;
        }
        // get safe char
        static char GetSafechar(string promt)
        {
            char number = 'n';
            bool isValid = false;

            do
            {
                try
                {
                    Console.Write(promt);
                    number = char.Parse(Console.ReadLine());
                    isValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }
            }
            while (isValid == false);

            return number;
        }
    }
}
