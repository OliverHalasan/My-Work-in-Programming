using System;
using System.IO;

namespace CorePortfolio03_Oliver_Halasan
{
    class Program
    {
        const int ARRAY_SIZE = 10;
        const string FILE = @"C:\Users\bless\Documents\IT World\C#\CorePortfolio03-Oliver-Halasan\EmployeeInfo.csv";
        static void Main(string[] args)         
        {
            string[] Name = new string[ARRAY_SIZE];
            double[] Salary = new double[ARRAY_SIZE];
            GetMenuChoice();
        }

       
        //menu choices
        static int GetMenuChoice()
        {
            int menu;
            string[] Name = new string[ARRAY_SIZE];
            double[] Salary = new double[ARRAY_SIZE];
            int EmployeeCount = 0;
            do
            {
                Console.WriteLine("*********Employee Salary Record********\n");
                Console.WriteLine("1. Enter the Name and Salary of an Employee");
                Console.WriteLine("2. Display Employee Salaries");
                Console.WriteLine("3. Read Salaries from File");
                Console.WriteLine("4. Write Salaries to File");
                Console.WriteLine("5. Exit");

                menu = GetSafeInt("\nPlease choose a selection: ");

                switch (menu)
                {
                    case 1:
                        if(EmployeeCount < ARRAY_SIZE)
                        {
                            EmployeeInput(Name, Salary, EmployeeCount);
                            EmployeeCount++;
                        }
                        else
                        {
                            Console.WriteLine("Sorry array is full");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Display");

                        DisplayEmployeeInfo(Name, Salary, EmployeeCount);
                        break;
                    case 3:
                        ReadFromFile(Name, Salary);
                        break;
                    case 4:
                        Console.WriteLine("Writing to the file");
                        WriteToFile(Name, Salary, EmployeeCount);
                        break;
                    case 5:
                        Console.WriteLine("Good Bye!");
                        break;
                    default:
                        Console.WriteLine("invalid Selection");
                        break;
                }
            } while (menu != 5);
           
           
            return 0;
        }

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

        static void EmployeeInput(string[] Name, double[] Salary, int EmployeeCount)
        {

            Console.Write("Please Enter Employee Name: ");
            Name[EmployeeCount] = Console.ReadLine();                      
            Salary[EmployeeCount] = GetSafeDouble("Please Enter Employee Salary: $");
        }

        static void DisplayEmployeeInfo(string[] Name, double[] Salary, int EmployeeCount)
        {
            Console.WriteLine("Employee Info");
            for (int i = 0; i < EmployeeCount; i++)
            {
                Console.WriteLine("Name: {0} Salary: ${1}", Name[i], Salary[i]);
            }
        }

        static void WriteToFile(string[] Name, double[] Salary, int EmployeeCount)
        {
            //write whats in the array to the file
            StreamWriter writer = new StreamWriter(FILE);

            Console.WriteLine("\n******Writing to file*****\n");

            //write top file
            for (int i = 0; i < EmployeeCount; i++)
            {
                writer.WriteLine("Name: {0} Invoice Total: {1}", Name[i], Salary[i]);
            }
            Console.WriteLine();

            //close file stream
            writer.Close();

        }

        static int ReadFromFile(string[] Name, double[] Salary)
        {
            string line;
            int EmployeeCount = 0;

            StreamReader reader = new StreamReader(FILE);
     
            while (reader.EndOfStream == false)
            {
                //read line from file
                line = reader.ReadLine();

                //split the string into parts based on ,
                string[] parts = line.Split(',');
                Name[EmployeeCount] = parts[0];
                
                EmployeeCount++;

                Console.WriteLine(line);
            }//end while

            reader.Close();

            return EmployeeCount;


        }



    }
}
