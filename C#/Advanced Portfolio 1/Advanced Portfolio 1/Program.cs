using System;
using System.Collections.Generic;


namespace Advanced_Portfolio_1
{
    class Program
    {
      
        static void Main(string[] args)
        {
            List<Pets> Petlist = new List<Pets>();
            double weight = 0;
            int age = 0;
            string name = "";
            int type = 1;

            Console.WriteLine(" *****Welcome to the Pet Medication Calculator *****\n");
            AddPet(Petlist,name,age,weight,type);
            Service(Petlist, weight,type);
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

        static void AddPet(List<Pets> Petlist, string name, int age, double weight, int type)

        {
            //variables
            char ans, AnsPet;
            string typeOfPet = null;
            bool redo = false;

           do
            {
 
                Console.Write("\tEnter the name of your pet: ");
                name = (Console.ReadLine());
                age = GetSafeInt("\tEnter the age in years of your pet: ");
                //age = int.Parse(Console.ReadLine());
                weight = GetSafeDouble("\tEnter the weight in pounds of your pet: ");
                

                Console.Write("\tEnter D for Dog, or C for cat: \t");
                AnsPet = char.Parse(Console.ReadLine());
                if (AnsPet == 'D' || AnsPet == 'd')
                {
                    typeOfPet = "Dog";
                    type = 1;
                }
                if (AnsPet == 'c' || AnsPet == 'C')
                {
                    typeOfPet = "Cat";
                    type = 2;
                }

                    Console.WriteLine("Name: {0}, Age: {1} years, Weight: {2} lbs, Type: {3}", name, age, weight,typeOfPet);

                

                Console.Write("Is the information above about your pet correct (Y/N): \t");
                ans = char.Parse(Console.ReadLine());

                if (ans == 'y' || ans == 'Y')
                {
                    Pets newPets = new Pets(name, age, weight,type);

                    newPets.SetPetname(name);
                    newPets.SetPetage(age);
                    newPets.SetPetweight(weight);
                    newPets.SetTypes(type);


                    Petlist.Add(newPets);
                    redo = true;
                }
                else
                {
                    if (ans == 'N' || ans == 'n')
                    {
                        redo = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection");
                        
                    }
                }
                
               
               
            } while (!redo);


        }

        static void Service(List<Pets> Petlist, double weight, int type)
        {
           
            int menuchoice = 0;
            Console.WriteLine("Enter the service required for your pet:");

            Console.WriteLine("\t1. Pain Killer");
            Console.WriteLine("\t2. Sedative");
            Console.WriteLine("\t3. Both Pain Killer and Sedative");

            menuchoice = GetSafeInt("Option: ");
            switch (menuchoice)
            {
                case 1:
                    if (type == 1)
                    {

                        AcepromazineDog(Petlist, weight);
                    }
                    else
                        if(type == 2)
                    {
                        AcepromazineCat(Petlist, weight);
                    }
                    break;
                case 2:
                    if (type == 1)
                    {

                        carprofenDog(Petlist, weight);
                    }
                    else
                      if (type == 2)
                    {
                        carprofenCat(Petlist, weight);
                    }
                    break;
                case 3:
                    if (type == 1)
                    {
                        AcepromazineDog(Petlist, weight);
                        carprofenDog(Petlist, weight);
                    }
                    else
                     if (type == 2)
                    {
                        AcepromazineCat(Petlist, weight);
                        carprofenCat(Petlist, weight);
                    }
                    break;
                default:
                    break;
            }

        }

        static double AcepromazineDog(List<Pets> Petlist, double weight)
        {
            double dosage = 2.20462;
            double AcepromazineDog = 0.03;
            double AcepromazineMl = 10;
            double answer;

            for (int i = 0; i < Petlist.Count; i++)
            {
                weight = Petlist[i].GetPetweight();
            }
            
          
            answer = (weight / dosage) * (AcepromazineDog / AcepromazineMl);

            Console.WriteLine("Your pet requires {0:0.0000}ml of acepromazine", answer);

            return answer;
        }

        static double AcepromazineCat(List<Pets> Petlist, double weight)
        {
            double dosage = 2.20462;
            double AcepromazineCat = 0.002;
            double AcepromazineMl = 10;
            double answer;

            for (int i = 0; i < Petlist.Count; i++)
            {
                weight = Petlist[i].GetPetweight();
            }


            answer = (weight / dosage) * (AcepromazineCat / AcepromazineMl);

            Console.WriteLine("Your pet requires {0:0.0000}ml of acepromazine", answer);

            return answer;
        }

        static double carprofenDog(List<Pets> Petlist, double weight)
        {
            double dosage = 2.20462;
            double CarprofenMl = 12;
            double CarprofenDog = 0.5;

            double answer;

            for (int i = 0; i < Petlist.Count; i++)
            {
                weight = Petlist[i].GetPetweight();
            }


            answer = (weight / dosage) * (CarprofenDog / CarprofenMl);

            Console.WriteLine("Your pet requires {0:0.0000}ml of carprofen", answer);

            return answer;
        }

        static double carprofenCat(List<Pets> Petlist, double weight)
        {
            double dosage = 2.20462;
            double CarprofenMl = 12;
            double CarprofenCat = 0.25;

            double answer;

            for (int i = 0; i < Petlist.Count; i++)
            {
                weight = Petlist[i].GetPetweight();
            }


            answer = (weight / dosage) * (CarprofenCat / CarprofenMl);

            Console.WriteLine("Your pet requires {0:0.0000}ml of carprofen", answer);

            return answer;
        }
    }
}
