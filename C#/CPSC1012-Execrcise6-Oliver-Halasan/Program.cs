using System;
using System.IO;

namespace CPSC1012_Execrcise6_Oliver_Halasan
{
    class Program
    {
        const int ARRAY_SIZE = 10;
        const string FILE = @"C:\Users\bless\Documents\IT World\C#\CPSC1012-Execrcise6-Oliver-Halasan\StudentInfo.csv";
        static void Main(string[] args)
        {
            // declare variables
            int studentCount = 0, HighestMark = 0;
            int[] grades = new int [ARRAY_SIZE];
            string[] names = new string[ARRAY_SIZE];
            int[] marks = new int[ARRAY_SIZE];

            Console.WriteLine("This program determines the grades of each student on a quiz.\n");

            EnterNamesAndMarks(names, grades, studentCount);
            DisplayGrades(names, marks, studentCount, HighestMark, grades);


          
           

        }

        static void EnterNamesAndMarks(string[] names, int[] grades, int studentCount)
        {
          


            int i = 0;

            Console.Write("Enter the number of students to grade: ");
            studentCount = int.Parse(Console.ReadLine());

            for (i = 0; i < studentCount; i++)
            {
                Console.Write("Eneter the name for student #{0}\t", i);
                names[studentCount] = Console.ReadLine();
                Console.Write("Enter the mark for student #{0}\t", i);
                grades[studentCount] = int.Parse(Console.ReadLine());
                

            }
            
           


        }

        static int HighestMark(int[] marks, int[] grades)
        {
            marks = grades;
            for (int i = 1; i < grades.Length; i++)
            {
               
            }
            

            Console.WriteLine("The highest mark in class is {0}",grades );

            return 0;
        }

        static void DisplayGrades(string[] names, int[] marks, int studentCount, int highestMark, int[] grades)
        {
            Console.WriteLine("Display the Grades");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("{0} mark is {1} and grade is{2}",names[i],grades[i],marks[i]);
            }
        }

        static char AssignGrade(int mark)
        {
            if(mark >= 80)
            {
                Console.WriteLine('A');
            }else
            if (mark >= 80)
            {
                Console.WriteLine('B');
            }else
            if (mark >= 80)
            {
                Console.WriteLine('C');
            }else
            if (mark >= 80)
            {
                Console.WriteLine('D');
            }
            else
            {
                Console.WriteLine('F');
            }
            return 'f';
        }

        //static void MainMenu()
        //{
        //    Console.WriteLine("This program determines the grades of each student on a quiz.\n");
        //    Console.WriteLine("1. Enter the Name and Mark");
        //    Console.WriteLine("2. Display Student Result");
        //    Console.WriteLine("3. Read from File");
        //    Console.WriteLine("4. Write to File");
        //    Console.WriteLine("5.Exit");
        //    Console.Write("\nPlease choose a selection: ");
        //}

        static void WriteToFile(string[] names, int[] grades, int studentCount)
        {
            //write whats in the array to the file
            StreamWriter writer = new StreamWriter(FILE);

            Console.WriteLine("\n******Writing to file*****\n");

            //write top file
            for (int i = 0; i < studentCount; i++)
            {
                writer.WriteLine("Name: {0} Mark: {1}", names[i], grades[i]);
            }
            Console.WriteLine();

            //close file stream
            writer.Close();

        }

        static int ReadFromFile(string[] names, int[] grades)
        {
            string line;
            int studentCount = 0;

            StreamReader reader = new StreamReader(FILE);

           
            while (reader.EndOfStream == false)
            {
                //read line from file
                line = reader.ReadLine();

                string[] parts = line.Split(',');
                names[studentCount] = parts[0];

                grades[studentCount] = int.Parse(parts[1]);

                studentCount++;

                Console.WriteLine(line);
            }

            reader.Close();

            return studentCount;


        }
    }
}
