using System;
using System.IO;
using System.Collections.Generic;

namespace AdvancePortfolio2

{
  
    class Program
    {
        const string FILE = @"C:\Users\bless\Documents\IT World\C#\AdvancePortfolio2\12345_transactions.csv";
        static void Main(string[] args)
        {
            List<BankAccount> bankAccountsList = new List<BankAccount>();
            int menuChoice = 0;
            int accountID = 0;
            char type = 'D';
            int transaction = 0;
            double annualInterestRate = 0;
            double balance = 0;
            double BankAccountCount = 0;
            double Withdrawal = 0;
            double DepositInput = 0;
            double InterestEarned = 0;
            double MonthlyInterestRate = 0;
            DateTime dateCreated = DateTime.Now;
                      
            do
            {
                Console.WriteLine("\nBank Account Menu");
                Console.WriteLine("\n1. Load Account & Transactions from File");
                Console.WriteLine("2. Create Bank Account");
                Console.WriteLine("3. Display Account Information");
                Console.WriteLine("4. Withdraw Funds");
                Console.WriteLine("5. Deposit Funds");
                Console.WriteLine("6. Add Interest");
                Console.WriteLine("7. Display Transactions");
                Console.WriteLine("8. Save Account & Transactions to File and Exit Program");
                Console.Write("Option: ");
                menuChoice = int.Parse(Console.ReadLine());

                switch (menuChoice)
                {
                    case 1:
                        // load
                        Console.WriteLine("\n1. Load Account & Transactions from File");

                        break;
                    case 2:       
                        //create
                            Console.WriteLine("Create Bank Account");
                            do
                            {
                                Console.WriteLine("Create Bank Account Menu");
                                Console.WriteLine("\n1. Enter Account ID");
                                Console.WriteLine("2. Enter Initial Account Balance");
                                Console.WriteLine("3. Set Annual Interest Rate");
                                Console.WriteLine("4. Exit Account Creation");
                                menuChoice = int.Parse(Console.ReadLine());
                                switch (menuChoice)
                                {
                                    case 1:
                                        Console.WriteLine();
                                        accountID = GetSafeInt("Enter account ID: ");
                                    if (accountID <= 0)
                                    {
                                        Console.WriteLine("Can't put lower than zero");
                                        accountID = 0;
                                    }
                                        BankAccountCount++;
                                        break;
                                    case 2:
                                        balance = GetSafeDouble("balance: ");
                                    if (balance <= 0)
                                    {
                                        Console.WriteLine("Can't put lower than zero");
                                        balance = 0;
                                    }
                                    break;
                                    case 3:
                                        annualInterestRate = GetSafeDouble("annual interest rate: ");
                                    if (annualInterestRate <= 0)
                                    {
                                        Console.WriteLine("Can't put lower than zero");
                                        annualInterestRate = 0;
                                    }
                                    break;
                                    case 4:
                                        dateCreated = DateTime.Now;
                                        break;
                                    default:
                                        break;                                  
                            }
                            StreamWriter writer = new StreamWriter(FILE);
                            writer.WriteLine("AccountID: {0} Balance: ${1:0.00} Annual Interest Rate: {2:0.00}% Date: {3:yyyy-MM-dd}", accountID, balance, annualInterestRate, dateCreated);
                            writer.Close();

                            BankAccount AddBankAccount = new BankAccount(accountID, balance, annualInterestRate, dateCreated);
                            bankAccountsList.Add(AddBankAccount);

                        } while (menuChoice != 4);                                                              
                        break;
                    case 3:
                        //display
                        Console.WriteLine("\nDisplay Bank Account");
                        DisplayInfo(accountID, balance, annualInterestRate, dateCreated);
                        break;
                    case 4:
                        //withdraw
                       balance = Withdraw(balance, Withdrawal, type);
                        type = 'W';
                        transaction++;

                        break;
                    case 5:
                        //deposit                      
                        balance = Deposit(balance, DepositInput, type);
                        type = 'D';
                        transaction++;
                        break;
                    case 6:
    
                        
                        MonthlyInterestRate = CalculateMonthlyInterestRate(annualInterestRate, MonthlyInterestRate);
                        Console.WriteLine(MonthlyInterestRate);
                        balance = CalculateMonthlyInterest(balance, InterestEarned, MonthlyInterestRate, type);
                        type = 'I';
                        transaction++;
                        break;
                    case 7:

                        DisplayTransaction(accountID, balance, annualInterestRate, dateCreated, type);


                        break;

                    case 8:
                        StreamWriter writerUpdate = new StreamWriter(FILE);
                        for (int i = 0; i < transaction; i++)
                        {
                            writerUpdate.WriteLine("AccountID: {0} Type: {1} Balance: ${2:0.00} Annual Interest Rate: {3:0.00}% Date: {4:yyyy-MM-dd}", accountID, type, balance, annualInterestRate, dateCreated);
                        }
                                          
                        Console.WriteLine("Good Bye...");
                        writerUpdate.Close();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            } while (menuChoice != 8);

            
        }

        static void DisplayInfo(int accountID, double balance, double annualInterestRate, DateTime dateCreated)
        {
                Console.WriteLine("Account ID: {0}", accountID);        
                Console.WriteLine("Created: {0:yyyy-MM-dd}", dateCreated);
                Console.WriteLine("Balance: ${0:0.00}", balance);
                Console.WriteLine("Annual Interest Rate: {0:0.00}%", annualInterestRate);
        }

        static void DisplayTransaction(int accountID, double balance, double annualInterestRate, DateTime dateCreated, char type)
        {
            Console.WriteLine("Account ID: {0}", accountID);
            Console.WriteLine("Type {0}", type);
            Console.WriteLine("Created: {0:yyyy-MM-dd}", dateCreated);
            Console.WriteLine("Balance: ${0:0.00}", balance);
            Console.WriteLine("Annual Interest Rate: {0:0.00}%", annualInterestRate);

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

        static double CalculateMonthlyInterestRate(double annualInterestRate, double MonthlyInterestRate)
        {
            MonthlyInterestRate = (annualInterestRate / 100) / 12;
            return MonthlyInterestRate;
        }

        static double CalculateMonthlyInterest(double balance, double InterestEarned, double MonthlyInterestRate, char type)
        {
            InterestEarned =   MonthlyInterestRate * balance;
            balance = balance + InterestEarned;
            Console.WriteLine("Added ${0:0.00} in interest", InterestEarned);
 
            return balance;
        }

        static double Withdraw(double balance, double Withdrawal, char type)
        {
            Withdrawal = GetSafeDouble("Enter withdrawal amount: ");

            if (Withdrawal > balance)
            {
                Console.WriteLine("Insuficient Funds");
                Withdrawal = 0;
            }else 
            {
                if (Withdrawal <= 0)
                {
                    Console.WriteLine("Cannot enter any lower than zero");
                }else
                {
                    balance = balance - Withdrawal;
                }
            }
        
            return balance;
        }

        static double Deposit(double balance, double DepositInput, char type)
        {
           DepositInput = GetSafeDouble("Enter deposit amount: ");
            if (DepositInput <= 0)
            {
                Console.WriteLine("Insuficient Funds");
                DepositInput = 0;
            }
            balance = balance + DepositInput;
            return balance;
        } 
    }

}
